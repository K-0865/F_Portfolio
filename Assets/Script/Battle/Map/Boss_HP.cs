using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HP : MonoBehaviour
{
    // Start is called before the first frame update
    public float _hp;
    public float _maxHp;
    [SerializeField] public GameObject Boss_Slider;
    public Slider _slider;
    public bool boss;
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(boss);
        if (boss)
        {
            Boss_Slider.SetActive(true);
            //_slider.value = _hp / _maxHp * 1;
        }
        else
        {
            Boss_Slider.SetActive(false);
        
        }
    }
}
