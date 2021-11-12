using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Present_Data : MonoBehaviour
{
    // Start is called before the first frame update
    
    private CharacterData sn;
    [SerializeField] private int _id;
    public int _ID
    {
        get { return _id; }
    }
    private float _maxHp;
    [SerializeField]
    private float _hp;
    private float _attack;
    private float _def;
    [SerializeField]
    private bool _alive = true;


    
    private void Start()
    {
        sn = this.gameObject.GetComponentInChildren<CharacterData>();
        _maxHp = sn.CharacterStatus.HP;
        _hp = sn.CharacterStatus.HP;
        _attack = sn.CharacterStatus.Attack;
        _def = sn.CharacterStatus.Defence;
        
    }

    
    public void getDamage(float damage)
    {
        _hp -= damage;
    }
    
    void Update()
    {
        if (_hp <= 0)
        {
            _alive = false;
        }
        else
        {
            _alive = true;
        }    
    }
}
