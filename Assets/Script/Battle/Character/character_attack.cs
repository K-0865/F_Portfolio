using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_attack : MonoBehaviour
{
    private Character_Movement _c_move;
   
    // Start is called before the first frame update　
    [SerializeField] GameObject _data;
    private CharacterData data_char_sc;
    private Character_Movement data_move;
    public float attack;
    public bool _isAttack;
    void Start()
    {

        data_char_sc = _data.GetComponent<CharacterData>();
        _c_move = this.gameObject.GetComponentInParent<Character_Movement>();
        data_move = this.gameObject.GetComponentInParent<Character_Movement>();
        attack = data_char_sc.CharacterStatus.Attack;

//        Debug.Log(data_char_sc);
    }

    private void Update()
    {
        //Debug.Log(data_move.isAttack);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (data_move.isAttack)
        // {
        //     Debug.Log("IN");
            if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Player")
            {
                if (other.gameObject.GetComponent<Character_Present_Data>()._alive == true)
                {
                    other.gameObject.GetComponent<Character_Present_Data>().getDamage(attack);
                }
                // else
                // {
                //     Debug.Log("Out_Damge");
                //     _c_move._found_enemy = false;
                //
                // }
            }
            
    }

    
}
