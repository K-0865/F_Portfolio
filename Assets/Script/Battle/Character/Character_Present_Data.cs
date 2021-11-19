using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character_Present_Data : MonoBehaviour
{
    // Start is called before the first frame update
    
    private CharacterData sn;
    [SerializeField] private GameObject damagepop;
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

    private TextMeshPro damage_get;

    
    private void Start()
    {
        sn = this.gameObject.GetComponentInChildren<CharacterData>();
        _maxHp = sn.CharacterStatus.HP;
        _hp = sn.CharacterStatus.HP;
        _attack = sn.CharacterStatus.Attack;
        _def = sn.CharacterStatus.Defence;
        damage_get = damagepop.gameObject.GetComponent<TextMeshPro>();
    }

    
    public void getDamage(float damage)
    {
        float sum = damage - this._def;
        _hp -= sum;
        damage_get.SetText(sum.ToString());
        GameObject pop = Instantiate(damagepop, new Vector3(this.transform.position.x,this.transform.position.y + 1f),Quaternion.identity);
        float_popup(pop);
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
