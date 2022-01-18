using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar_value : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider _slider;
    [SerializeField]private Character_Present_Data _characterPresentData;
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _slider.value = _characterPresentData._hp;
    }

    public void set_data_C(Character_Present_Data a)
    {
        _characterPresentData = a;
    }
}
