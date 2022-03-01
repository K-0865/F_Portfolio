using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class List_LineUp : MonoBehaviour
{
    [SerializeField] private GameObject Banner;
    private Text BannerText;
    
    List<GameObject> list_Banner = new List<GameObject>();

    [SerializeField] private int Max = 0;
    [SerializeField] private int BannerSize;
    [SerializeField] private float LineUp_X;
    [SerializeField] private float LineUp_Y;
    [SerializeField] private float Lognum;
    [SerializeField] private Scrollbar _scroll;
    
    public void isScroll()
    {
        //Lognum = Log_Slider.value * -100*Max;
        Lognum = 100+(((Max-2)*-300)* _scroll.value);
        this.gameObject.transform.localPosition = new Vector3(100,Lognum);
    }

    public void DrawLog(string text,int num)
    {
        var parent = this.transform;
        Max = num;
        if (Max > 2){
            _scroll.size = (float)1 / (Max -1);
        }
       
        list_Banner.Add(Instantiate(Banner,Vector3.zero, Quaternion.identity, parent));
        Text BannerText = Banner.GetComponentInChildren<Text>();

        BannerText.text = text;
    
        list_Banner[num].transform.localPosition = new Vector2(-750f,-220f+300*num);

        _scroll.value = 1;
        isScroll();
        if (num <= 4)
        {
            _scroll.enabled = true;
        }
    }
}