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
    void Start()
    {
        _slider = gameObject.GetComponentInChildren<Slider>();
        _data = _data2.GetComponent<Character_Present_Data>();
        
        
    }
    
    //HPが満タン時の表示、非表示の切り替え
    void Update()
    {
        _hp = _data._hp;
        _Maxhp = _data._maxHp;
        _slider.value = _hp / _Maxhp * 1;
        //Debug.Log(_slider.value);
        if (_hp == _Maxhp || _hp <= 0)
        {
            _slider.gameObject.SetActive(false);
        }
        else
        {
            _slider.gameObject.SetActive (true);
        }
    }
}
