using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    [SerializeField]private StoryUI uitext;
    [SerializeField] private Image Character1;
    [SerializeField] private Image Character2;
    [SerializeField] private Text Name;
    [SerializeField] private Image AutoButton;

    [SerializeField] private Story_1 Story1_1;

    [SerializeField] private float sec;
    void Start()
    {
        StartCoroutine("Cotest");
    }

    public void OnClickAutoForward()
    {
        if (uitext.AutoForward)
        {
            uitext.AutoForward = false;
            uitext.AutoForward_2 = false;
            AutoButton.color = new Color32(255, 255, 255, 255);
            Debug.Log(uitext.AutoForward);
        }
        else
        {
            uitext.AutoForward = true;
            uitext.AutoForward_2 = true;
            AutoButton.color = new Color32(155, 155, 155, 255);
            Debug.Log(uitext.AutoForward);
           
        }
    }
    
    // クリック待ちのコルーチン
    IEnumerator Skip()
    {
        while (uitext.playing) yield return 0;
        while (!uitext.isClicked()) yield return 0;
    }

    IEnumerator Auto()
    {
        while (uitext.playing) yield return 0;
        while (!uitext.isAuto()) yield return 0;
        StartCoroutine("Skip");
    }

    // 文章を表示させるコルーチン
    IEnumerator Cotest()
    {
        for (int i = 0;i < Story1_1.Story11.Count; i++)
        {
            if (Story1_1.Story11[i].CharaSprite1 != "")
            {
                Character1.enabled = true;
                Character1.sprite = Resources.Load<Sprite>("Home/" + Story1_1.Story11[i].CharaSprite1);
            }
            else
            {
                Character1.enabled = false;
            }

            if (Story1_1.Story11[i].CharaSprite2 != "")
            {
                Character2.enabled = true;
                Character2.sprite = Resources.Load<Sprite>("Home/" + Story1_1.Story11[i].CharaSprite2);
            }
            else
            {
                Character2.enabled = false;
            }

            if(Story1_1.Story11[i].Speaker != "")
            {
                Name.enabled = true;
            }
            else
            {
                Name.enabled = false;  
            }

            uitext.DrawText(Story1_1.Story11[i].Speaker, Story1_1.Story11[i].StoryDialogue);
            yield return StartCoroutine("Skip");
            uitext.isClick = false;
        }
    }
}