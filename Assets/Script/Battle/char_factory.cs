using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_factory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GManager.Player player_data;
    [SerializeField]
    private GameObject []_character = new GameObject[4];
    void Start()
    {

        for (int i = 0; i < player_data.character_pos.Length; i++)
        {
            
            if (player_data.character_pos[i] != 0)
            {
                
                _character[i] = (GameObject)Resources.Load ("Characters/"+player_data.character_pos[i]);
                Instantiate(_character[i],this.transform);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
