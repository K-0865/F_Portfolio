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
        WAIT,READY, BATTLE
    }

    [SerializeField] private GameObject battle_start_text; 
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
    [SerializeField] private int _GageMax;
    public bool boss = true;
    [SerializeField] private GameObject Roulette;
    [SerializeField] private GameObject Clear;
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
        }

        //敵か味方のキャラの残数がゼロになったらテキストを表示してクエスト選択に戻る（暫定的な処理）
        if (allies_alive_count == 0 || enemies_alive_count == 0)
        {
            StartCoroutine("StageClear", 4f);
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
        State = GameState.BATTLE;
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
        yield return new WaitForSeconds(sec);
        isPause = false;
    }

    //バトル終了処理
    public IEnumerator StageClear(float sec)
    {
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
