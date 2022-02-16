using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story_Log : MonoBehaviour
{
    [SerializeField] private Text LogName;
    [SerializeField] private Text LogText;
    
    List<Text> list_LogName = new List<Text>();
    List<Text> list_LogText = new List<Text>();

    [SerializeField] private int Max = 0;
    [SerializeField] private float Lognum;
    [SerializeField] private Scrollbar _scroll;
    
    public void isScroll()
    {
        //Lognum = Log_Slider.value * -100*Max;
        Lognum = 100+(((Max-2)*-300)* _scroll.value);
        this.gameObject.transform.localPosition = new Vector3(100,Lognum);
    }

    public void DrawLog(string name,string text,int num)
    {
        var parent = this.transform;
        Max = num;
        if (Max > 2){
            _scroll.size = (float)1 / (Max -1);
        }
       
        list_LogName.Add(Instantiate(LogName,Vector3.zero, Quaternion.identity, parent));
        list_LogText.Add(Instantiate(LogText,Vector3.zero, Quaternion.identity, parent));
        
        list_LogName[num].text = name;
        list_LogText[num].text = text;
    
        list_LogName[num].transform.localPosition = new Vector2(-750f,-220f+300*num);
        list_LogText[num].transform.localPosition = new Vector2(-100f,-350f+300*num);
        _scroll.value = 1;
        isScroll();
        if (num <= 4)
        {
            _scroll.enabled = true;
        }

    }
}
