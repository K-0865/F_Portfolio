using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//Enemyの生成
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

    private SortingGroup _sortingGroup;
    //マップデータから敵の生成数とIDを確認
    private void Awake()
    {
        _battleManager = GetComponentInParent<Transform>().GetComponentInParent<BattleManager>();
        now_wave = GetComponentInParent<Transform>().GetComponentInParent<BattleManager>().stage_count;
        _stageTable = GetComponentInParent<MapManager>().get_PreviewData();
        Enemy_data = GetComponentInParent<MapManager>().get_EnemyData();
        Enemy_Stage_Count = GetComponentInParent<MapManager>().get_Enemy_Stage_Count();
        
    }

    //Wave毎の生成数を確認し対応数生成する
    void Start()
    {
        if (now_wave == 0)
        {
            for (int i = 0; i < Enemy_Stage_Count[0]; i++)
            {
                //Enemyのprefab生成
                _enemy[i] = (GameObject)Resources.Load ("Enemy/"+Enemy_data[i]);
                _enemy_clone[i] = Instantiate(_enemy[i]);
                _enemy_clone[i].transform.parent = transform;
                _sortingGroup = _enemy_clone[i].GetComponent<SortingGroup>();
                float posx = 6f;
                float posy = 0f;
                switch (i)
                {
                    case 0:
                        posy = 0.75f;
                        posx = 6f;
                        _sortingGroup.sortingOrder = 2;
                        break;
                    case 1:
                        posy = -1f;
                        posx = 6f;
                        _sortingGroup.sortingOrder = 4;
                        break;
                    case 2:
                        posy = 1.75f;
                        posx = 8f;
                        _sortingGroup.sortingOrder = 1;
                        break;
                    case 3:
                        posy = 0.25f;
                        posx = 8f;
                        _sortingGroup.sortingOrder = 4;
                        break;
                    case 4:
                        posy = -1.75f;
                        posx = 8f;
                        _sortingGroup.sortingOrder = 5;
                        break;
                    
                }
                Vector3 pos_e = new Vector3(posx,posy,0f);
                
                _enemy_clone[i].transform.position = pos_e;
                _battleManager.enemies_alive_count++;
            }
        }else if (now_wave == 1) //現在のWave数が１の場合
        {
            for (int i = Enemy_Stage_Count[0]-1; i < Enemy_Stage_Count[0]+Enemy_Stage_Count[1]; i++)
            {
                     
                _enemy[i] = (GameObject)Resources.Load ("Enemy/"+Enemy_data[i]);
                Instantiate(_enemy[i] );
            }
        }else if (now_wave == 2) //現在のWave数が2の場合
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
