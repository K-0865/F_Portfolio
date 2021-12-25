using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_factory : MonoBehaviour
{
    //プレイヤーデータの読み込み
    [SerializeField]
    private GManager player_data;
    [SerializeField]
    private int [] player_pos;
    private BattleManager _battleManager;
    //[SerializeField]
    private GameObject []_character = new GameObject[4];
    private GameObject []_character_clone = new GameObject[4];

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
                float pos = (10 + ((i + 1) * 2))*-1;
                float posy = 0;
                if (i % 2 == 0)
                {
                    posy = -1.3f;
                }
                if (i % 3 == 0)
                {
                    posy = 1.3f;
                }
                Vector3 pos_e = new Vector3(pos,posy -1.3f,0f);
                _character_clone[i].transform.position = pos_e;
                _battleManager.allies_alive_count++;
                //Debug.Log(_battleManager.allies_alive_count);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
