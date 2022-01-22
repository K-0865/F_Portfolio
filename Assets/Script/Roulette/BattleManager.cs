using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum GameState{
        WAIT,READY,READY2, BATTLE,WIN
    }

    [SerializeField] private GameObject battle_start_text; 
    [SerializeField] private GameObject win_text; 
    [SerializeField] private GameObject lose_text; 
    public GameState State = GameState.WAIT;
    public int stage_count = 0;
    public int hit_count;
    public int allies_alive_count;
    public int enemies_alive_count;
    public List<int> _AliveID;
    public int totals_mobs;
    public bool isPause;
    public bool _start_player;
    public bool _ready_player;
    public bool _ready_enemy;
    public bool _start_enemy;
    public bool _gamestart;
    public bool battleFin = false;
    public int _GageMax;
    public bool boss = true;
    [SerializeField] private GameObject Roulette;
    [SerializeField] private GameObject Clear;
    [SerializeField] private Canvas Canvas;
    void Start()
    {
        //GameObject.Find("BattleManger").GetComponent<BattleManager>().isPause = true;

    }

    // Update is called once per frame
    void Update()
    {
        totals_mobs = enemies_alive_count + allies_alive_count;
        
        //一定回数敵＋味方キャラの攻撃が当たったらRouletteを呼び出す
        if (hit_count > _GageMax)
        {
            StartCoroutine("callRoulette",16f) ;
            //Canvas.enabled = false;
        }

        //敵か味方のキャラの残数がゼロになったらテキストを表示してクエスト選択に戻る（暫定的な処理）
        if (enemies_alive_count == 0)
        {
            StartCoroutine("StageClear", 4f);
        }else if (allies_alive_count == 0)
        {
            StartCoroutine("Failed", 4f);

        }

        if (_start_player && _start_player && State == GameState.WAIT)
        {
            State = GameState.READY;
        }

        if (State == GameState.READY)
        {
            StartCoroutine("_BattleStart");
        }
    }

    IEnumerator _BattleStart()
    {
        State = GameState.READY2;
        yield return new WaitForSeconds(3f);
        GameObject battleStartText = Instantiate(battle_start_text);
        battleStartText.transform.position = Vector3.zero;
        State = GameState.BATTLE;
        _gamestart = true;
    }
    //スロット呼び出し部
    public IEnumerator callRoulette(float sec)
    {
        isPause = true;
        hit_count = 0;
        Roulette.GetComponent<Roulette>().Roul_main(); 
        yield return 0;
        // isPause = false;
    }

    //バトル終了処理
    public IEnumerator StageClear(float sec)
    {
        State = GameState.WIN;
        win_text.SetActive(true);        
        lose_text.SetActive(false);

        GManager.instance.player.Exp += 5;
        //GameObject battleStartText = Instantiate(win_text);
        Clear.SetActive(true);
        yield return new WaitForSeconds(sec);
        Clear.GetComponent<SceneLoad>().OnClickLoadScene();
        battleFin = true;
    }
    public IEnumerator Failed(float sec)
    {
        State = GameState.WIN;
        win_text.SetActive(false);
        lose_text.SetActive(true);
        //GManager.instance.player.Exp += 5;
        //GameObject battleStartText = Instantiate(win_text);
        Clear.SetActive(true);
        yield return new WaitForSeconds(sec);
        Clear.GetComponent<SceneLoad>().OnClickLoadScene();
        battleFin = true;
    }
    public void BattleFinish()
    {
        if (battleFin)
        {
            //Result.
        }
    }
    
    //ポーズ処理
    public void OnclickPause()
    {
        if (isPause)
        {
            isPause = false;
        }
        else
        {
            isPause = true;
        }
    }

    
}
