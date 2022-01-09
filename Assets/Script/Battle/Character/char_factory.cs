using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class char_factory : MonoBehaviour
{
    //プレイヤーデータの読み込み
    [SerializeField]
    private GManager player_data;
    [SerializeField]
    private int [] player_pos;
    private BattleManager _battleManager;
    //[SerializeField]
    private GameObject []_character = new GameObject[5];
    [SerializeField]
    public GameObject []_character_clone = new GameObject[5];
    private SortingGroup _sortingGroup;

    //マップデータのデータテーブルにある分キャラクターの生成
    void Start()
    {
        
        player_data = GManager.instance;
        //player_pos = GameObject.Find("GameManeger").GetComponent<GManager.Player>().character_pos;
        player_pos = GManager.instance.get_char_pos();
        
        
        _battleManager = GetComponentInParent<BattleManager>();
        //Debug.Log(player_pos.Length);
        for (int i = 0; i < player_data.character_pos.Length; i++)
        {
            
            if (player_data.character_pos[i] != 0)
            {
                
                _character[i] = (GameObject)Resources.Load ("Characters/"+player_data.character_pos[i]);
                _character_clone[i] = Instantiate(_character[i]);
                _character_clone[i].transform.parent = this.transform;
                _sortingGroup = _character_clone[i].GetComponent<SortingGroup>();
                float posx = -12f;
                float posy = 0f;
                switch (i)
                {
                    case 0:
                        posy = 0.75f;
                        posx = -12f;
                        _sortingGroup.sortingOrder = 2;
                        break;
                    case 1:
                        posy = -1f;
                        posx = -12f;
                        _sortingGroup.sortingOrder = 4;
                        break;
                    case 2:
                        posy = 1.75f;
                        posx = -14f;
                        _sortingGroup.sortingOrder = 1;
                        break;
                    case 3:
                        posy = 0.25f;
                        posx = -14f;
                        _sortingGroup.sortingOrder = 4;
                        break;
                    case 4:
                        posy = -1.75f;
                        posx = -14f;
                        _sortingGroup.sortingOrder = 5;
                        break;
                    
                }
                Vector3 pos_e = new Vector3(posx,posy,0f);
                _character_clone[i].transform.position = pos_e;
                _battleManager.allies_alive_count++;
                _battleManager._AliveID.Add(player_data.character_pos[i]);
                //Debug.Log(_battleManager.allies_alive_count);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
