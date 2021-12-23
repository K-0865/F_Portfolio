using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int stage_count = 0;
    public int hit_count;
    public int allies_alive_count;
    public int enemies_alive_count;
    public int totals_mobs;
    public bool isPause;
    [SerializeField] private int _GageMax;

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
