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
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        totals_mobs = enemies_alive_count + allies_alive_count;
    }
}
