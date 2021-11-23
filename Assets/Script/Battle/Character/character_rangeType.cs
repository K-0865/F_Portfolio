using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_rangeType : MonoBehaviour
{
    private Character_Movement _c_move;
   
    // Start is called before the first frame update　
    [SerializeField] GameObject _data;
    private CharacterData data_char_sc;
    private Character_Movement data_move;
    public float attack;
    public bool _isAttack;
    [SerializeField] private GameObject bullet;
    void Start()
    {

        data_char_sc = _data.GetComponent<CharacterData>();
        _c_move = this.gameObject.GetComponentInParent<Character_Movement>();
        data_move = this.gameObject.GetComponentInParent<Character_Movement>();
        attack = data_char_sc.CharacterStatus.Attack;

        Debug.Log(data_char_sc);
    }

    public void Range_bullet()
    {
        GameObject obj = Instantiate(bullet);
        obj.transform.parent = this.transform;
        obj.transform.position = this.transform.position;
    }
    private void Update()
    {
        //Debug.Log(data_move.isAttack);
    }

    
    
    
}