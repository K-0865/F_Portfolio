using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fac : MonoBehaviour
{
    // Start is called before the first frame update
    private StageTable _stageTable;
    [SerializeField]
    private int[] Enemy_data;
    private int[] Enemy_Stage_Count;
    private int now_wave;
    [SerializeField]
    private GameObject []_enemy = new GameObject[4];
    private GameObject []_enemy_clone = new GameObject[4];
    private BattleManager _battleManager;

    private void Awake()
    {
        _battleManager = GetComponentInParent<Transform>().GetComponentInParent<BattleManager>();
        now_wave = GetComponentInParent<Transform>().GetComponentInParent<BattleManager>().stage_count;
        _stageTable = GetComponentInParent<MapManager>().get_PreviewData();
        Enemy_data = GetComponentInParent<MapManager>().get_EnemyData();
        Enemy_Stage_Count = GetComponentInParent<MapManager>().get_Enemy_Stage_Count();
        
    }

    void Start()
    {
        if (now_wave == 0)
        {
            for (int i = 0; i < Enemy_Stage_Count[0]; i++)
            {
                _enemy[i] = (GameObject)Resources.Load ("Enemy/"+Enemy_data[i]);
                float pos = 10 + ((i + 1) * 2);
                Vector3 pos_e = new Vector3(pos,0f,0f);
                _enemy_clone[i] = Instantiate(_enemy[i]);
                _enemy_clone[i].transform.parent = transform;
                _enemy_clone[i].transform.position = pos_e;
                _battleManager.enemies_alive_count++;
            }
        }else if (now_wave == 1)
        {
            for (int i = Enemy_Stage_Count[0]-1; i < Enemy_Stage_Count[0]+Enemy_Stage_Count[1]; i++)
            {
                     
                _enemy[i] = (GameObject)Resources.Load ("Enemy/"+Enemy_data[i]);
                Instantiate(_enemy[i] );
            }
        }else if (now_wave == 2)
        {
            for (int i = Enemy_Stage_Count[1]-1; i < Enemy_Stage_Count[0]+Enemy_Stage_Count[1]+Enemy_Stage_Count[2]; i++)
            {
                     
                _enemy[i] = (GameObject)Resources.Load ("Enemy/"+Enemy_data[i]);
                Instantiate(_enemy[i] );
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
