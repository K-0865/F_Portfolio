using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HP : MonoBehaviour
{
    // Start is called before the first frame update
    public float _hp;
    public float _maxHp;
    public string _name;
    public int _lvl;
    [SerializeField] public GameObject Boss_Slider;
    public Slider _slider;
    public bool boss;
    [SerializeField] private TextMeshProUGUI Hp_text;

    [SerializeField] private TextMeshProUGUI Boss_Name;
    [SerializeField] private TextMeshProUGUI Boss_Lvl;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(boss);
        if (boss)
        {
            Boss_Slider.SetActive(true);
            Hp_text.text = _hp + "/" + _maxHp;
            Boss_Name.text = _name;
            Boss_Lvl.text = "Lv."+_lvl.ToString();
        }
        else
        {
            Boss_Slider.SetActive(false);
        }
    }
}
