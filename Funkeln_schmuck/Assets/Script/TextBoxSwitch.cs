using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxSwitch : MonoBehaviour
{
    [SerializeField] GameObject TextBox1;
    [SerializeField] GameObject TextBox2;
    [SerializeField] GameObject TextBox3;
    [SerializeField] GameObject TextBox4;
    [SerializeField] int min;
    [SerializeField] int max;
    int value = 0;
    int ran = 0;
    // Start is called before the first frame update
    public void OnTapTextSwitch()
    {
        value = ran;

        while(value == ran)
        {
            ran = Random.Range(min, max);
        }
        switch (ran)
        {
            case 1:
                TextBox1.SetActive(true);
                TextBox2.SetActive(false);
                TextBox3.SetActive(false);
                TextBox4.SetActive(false);
                Debug.Log("Text1");
                break;
            case 2:
                TextBox1.SetActive(false);
                TextBox2.SetActive(true);
                TextBox3.SetActive(false);
                TextBox4.SetActive(false);
                Debug.Log("Text2");
                break;
            case 3:
                TextBox1.SetActive(false);
                TextBox2.SetActive(false);
                TextBox3.SetActive(true);
                TextBox4.SetActive(false);
                Debug.Log("Text3");
                break;
            case 4:
                TextBox1.SetActive(false);
                TextBox2.SetActive(false);
                TextBox3.SetActive(false);
                TextBox4.SetActive(true);
                Debug.Log("Text4");
                break;
            default:
                break;
        }
    }

}


