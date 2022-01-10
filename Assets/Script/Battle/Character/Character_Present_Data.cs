using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

//データテーブルから取得したキャラクターのデータを各キャラクターのprefabに渡す
public class Character_Present_Data : MonoBehaviour
{
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
    public int _lvl;
    private float _attack;
    private float _def;
    [SerializeField]
    public bool _alive = true;
    public bool _dead = false;
    public bool _found_enemy = false;
    public int attack_step;
    private dmg_ct _sdmg;
    public float _attack_speed;
    public string _name;
    public List<Buff_list> _buffs;
    public List<Buff_list> _debuffs;
    [SerializeField] private GameObject effect_buff;
    private void Start()
    {
        _battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        sn = this.gameObject.GetComponentInChildren<CharacterData>();
        _sdmg = this.gameObject.GetComponentInChildren<dmg_ct>();
        _name = sn.CharacterStatus.CharacterName;
        _lvl = sn.CharacterStatus.Level;
        _maxHp = sn.CharacterStatus.HP;
        _hp = sn.CharacterStatus.HP;
        _attack = sn.CharacterStatus.Attack;
        _def = sn.CharacterStatus.Defence;
        _attack_speed = sn.CharacterStatus.AttackSpeed;
        // damage_get = damagepop.gameObject.GetComponent<TextMeshPro>();
        //_sDMG.Init(123,new Vector3(0,0,0));
        //_sDMG.Init(124,new Vector3(0,0,0));
    }

    //ダメージ計算(攻撃力-防御力 = ダメージ、暫定式)
    public void setBuff(Skill_Data skill)
    {
        
        Buff_list buff = new Buff_list();
        buff.Atk = skill.Atk;
        buff.Def = skill.Def;
        buff.Eva = skill.Eva;
        buff.Sec = skill.Sec;
        _buffs.Add(buff);
    }public void set_deBuff(Skill_Data skill)
    {
        
        Buff_list debuff = new Buff_list();
        debuff.Atk = skill.Atk;
        debuff.Def = skill.Def;
        debuff.Eva = skill.Eva;
        debuff.Sec = skill.Sec;
        _debuffs.Add(debuff);
    }

    void removeBuff_debuff()
    {
        for (int i = 0; i < _buffs.Count; i++)
        {
            if (_buffs[i].Sec < 0)
            {
                _buffs.RemoveAt(i);
            }
        } 
        for (int i = 0; i < _debuffs.Count; i++)
        {
            if (_debuffs[i].Sec < 0)
            {
                _debuffs.RemoveAt(i);
            }
        }   
    }
    public void getDamage(float damage)
    {
        float total_def = 0;
        float total_buff = 0;
        for (int i = 0; i < _buffs.Count; i++)
        {
            total_buff += _buffs[i].Def;
        }
        for (int i = 0; i < _debuffs.Count; i++)
        {
            total_buff -= _debuffs[i].Def;
        }

        total_def = _def * (total_buff / 100);
        float sum = damage - total_def;  // Damage Formula
        if (sum <= 0)
        {
            sum = 1;
        }
        _hp -= sum;
        
        _sdmg.Init((int)sum,new Vector3(this.transform.position.x,this.transform.position.y+0.5f,0));
        GameObject.Find("BattleManager").GetComponent<BattleManager>().hit_count++;

    }
    
    //キャラクターが生きているかどうか
    void Update()
    {
        if (_buffs.Count > 0)
        {
            effect_buff.SetActive(true);
        }
        else
        {
            effect_buff.SetActive(false);
        }
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

        if (_dead && this.gameObject.GetComponent<Collider2D>())
        {
            for (int i = 0; i < _battleManager._AliveID.Count; i++)
            {
                if (_ID == _battleManager._AliveID[i])
                {
                    _battleManager._AliveID.RemoveAt(i);
                }
            }
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Destroy(this.gameObject.GetComponentInChildren<Collider2D>());
            _found_enemy = false;
            if (this.tag == "Player")
            {
                _battleManager.allies_alive_count--;
            }
            else
            {
                _battleManager.enemies_alive_count--;
            }
        }
    }
}
