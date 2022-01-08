using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ready_line : MonoBehaviour
{
    // Start is called before the first frame update
    private BattleManager _battleManager;
    void Start()
    {
        _battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();

    }

    // Update is called once per frame
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player");
            _battleManager._start_player = true;
            _battleManager._ready_player = true;
        }else if(other.tag == "enemy")
        {
            Debug.Log("Enemy");
            _battleManager._start_enemy = true;
            _battleManager._ready_enemy = true;

        }

        
    }
}
