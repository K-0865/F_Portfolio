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
    void Start()
    {
        //GameObject.Find("BattleManger").GetComponent<BattleManager>().isPause = true;

    }

    // Update is called once per frame
    void Update()
    {
        totals_mobs = enemies_alive_count + allies_alive_count;
        if (hit_count > _GageMax)
        {
            callRoulette();
        }
    }

    public void callRoulette()
    {
        isPause = true;
        Roulette.GetComponent<Roulette>().Roulette_main();
        isPause = false;
    }
    
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
