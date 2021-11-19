using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_attack : MonoBehaviour
{
    // Start is called before the first frame update　
    [SerializeField] private GameObject _data;
    private CharacterData data_char_sc;
    public float attack;
    void Start()
    {
        data_char_sc = _data.GetComponent<CharacterData>();
        attack = data_char_sc.CharacterStatus.Attack;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<Character_Present_Data>().getDamage(attack);
        }
    }

    
}
