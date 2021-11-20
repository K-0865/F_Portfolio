using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public float _maxHp;
    [SerializeField]
    public float _hp;
    private float _attack;
    private float _def;
    [SerializeField]
    public bool _alive = true;
    public bool _dead = false;

    private dmg_ct _sdmg;
    
    private void Start()
    {
        sn = this.gameObject.GetComponentInChildren<CharacterData>();
        _sdmg = this.gameObject.GetComponentInChildren<dmg_ct>();
        _maxHp = sn.CharacterStatus.HP;
        _hp = sn.CharacterStatus.HP;
        _attack = sn.CharacterStatus.Attack;
        _def = sn.CharacterStatus.Defence;
        // damage_get = damagepop.gameObject.GetComponent<TextMeshPro>();
        //_sDMG.Init(123,new Vector3(0,0,0));
        //_sDMG.Init(124,new Vector3(0,0,0));
    }

    
    public void getDamage(float damage)
    {
        float sum = damage - this._def;
        _hp -= sum;
        _sdmg.Init((int)sum,new Vector3(0,0,0));
    }

    void float_popup(GameObject pop)
    {
        Destroy(pop,1);
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
