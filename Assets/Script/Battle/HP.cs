using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        _hp = _data._hp;
        _Maxhp = _data._maxHp;
        _slider.value = _hp / _Maxhp * 1;
        Debug.Log(_slider.value);
        if (_hp == _Maxhp)
        {
            _slider.gameObject.SetActive(false);

        }
        else
        {
            _slider.gameObject.SetActive (true);

        }
    }
}
