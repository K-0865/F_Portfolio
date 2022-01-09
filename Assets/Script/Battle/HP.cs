using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//各キャラクターの頭上のHPバー
public class HP : MonoBehaviour
{
    //初期化
    private Slider _slider;
    private Character_Present_Data _data;
    [SerializeField]
    private GameObject _data2;
    public float _hp;
    public float _Maxhp;
    public bool boss;
    private GameObject Boss_S;
    private Boss_HP _Boss_HP;
    void Start()
    {
        _slider = gameObject.GetComponentInChildren<Slider>();
        _data = _data2.GetComponent<Character_Present_Data>();
        Boss_S = GameObject.Find("Boss");
        _Boss_HP = Boss_S.GetComponent<Boss_HP>();


    }
    
    //HPが満タン時の表示、非表示の切り替え
    void Update()
    {

        _hp = _data._hp;
        _Maxhp = _data._maxHp;
        _slider.value = _hp / _Maxhp * 1;
        //Debug.Log(_slider.value);
        
        if (!boss)
        {
            if (_hp == _Maxhp || _hp <= 0)
            {
                _slider.gameObject.SetActive(false);
            }
            else
            {
                _slider.gameObject.SetActive (true);
            }
        }
        else
        {
            _slider.gameObject.SetActive (false);
            _Boss_HP.boss = true;
            //Debug.Log(_Boss_HP.boss);
            _Boss_HP._slider.value = _hp / _Maxhp * 1;
            //Boss_S.GetComponent<Boss_HP>()._slider.value = _hp / _Maxhp * 1;
            // Boss_S.GetComponent<Boss_HP>()._hp = _hp;
            // Boss_S.GetComponent<Boss_HP>()._maxHp = _Maxhp;
        }
        
    }
}
