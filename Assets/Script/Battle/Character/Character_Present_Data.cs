using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Character_Present_Data : MonoBehaviour
{
    // Start is called before the first frame update
    
    public CharacterData sn;
    [SerializeField] private int _id;
    private BattleManager _battleManager;
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
    public bool _found_enemy = false;
    public int attack_step;
    private dmg_ct _sdmg;
    public float _attack_speed;
    private void Start()
    {
        _battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        sn = this.gameObject.GetComponentInChildren<CharacterData>();
        _sdmg = this.gameObject.GetComponentInChildren<dmg_ct>();
        _maxHp = sn.CharacterStatus.HP;
        _hp = sn.CharacterStatus.HP;
        _attack = sn.CharacterStatus.Attack;
        _def = sn.CharacterStatus.Defence;
        _attack_speed = sn.CharacterStatus.AttackSpeed;
        // damage_get = damagepop.gameObject.GetComponent<TextMeshPro>();
        //_sDMG.Init(123,new Vector3(0,0,0));
        //_sDMG.Init(124,new Vector3(0,0,0));
    }

    
    public void getDamage(float damage)
    {
        float sum = damage - this._def;
        _hp -= sum;
        _sdmg.Init((int)sum,new Vector3(this.transform.position.x,this.transform.position.y+0.5f,0));
        GameObject.Find("BattleManager").GetComponent<BattleManager>().hit_count++;

    }
    
    void Update()
    {
        if (_hp <= 0)
        {
            _dead = true;
            _alive = false;
        }
        else
        {
            _dead = false;
            _alive = true;
        }

        if (_dead)
        {
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Destroy(this.gameObject.GetComponentInChildren<Collider2D>());
            _found_enemy = false;
            if (this.tag == "Player")
            {
                _battleManager.allies_alive_count++;
            }
            else
            {
                _battleManager.enemies_alive_count--;
            }
        }
    }
}
