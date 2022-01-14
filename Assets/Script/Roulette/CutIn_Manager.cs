using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutIn_Manager : MonoBehaviour
{
    [SerializeField] private List<Image> Frame;
    [SerializeField] private List<Image> Character;
    [SerializeField] private List<TextMeshProUGUI> Dialogue;

    [SerializeField] private Roulette _roulette;

    [SerializeField] private List<Vector3> pos;
    private bool[] D_Slider = {false, false };
    private bool[] D_Slider_Done = {false, false };
    private void Update()
    {
        for (int i = 0; i < D_Slider.Length; i++)
        {
            if (D_Slider[i])
            {
                _Slider(i+1);
                if (i == 1)
                {
                    Disable_Img(0);
                }
            }
    
            
        }

        for (int i = 0; i < D_Slider.Length; i++)
        {
            if (D_Slider_Done[i])
            {
                StartCoroutine(CutIn_Disp(i+1,1));
                
            }
        }

        if (D_Slider_Done[1])
        {
            D_Slider_Done[0] = false;
            D_Slider_Done[1] = false;     
            D_Slider[0] = false;
            D_Slider[1] = false;
            
            StartCoroutine(CutIn_Fin(2));
        }
    }

    void Disable_Img(int i)
    {
        Frame[i].enabled = false;
        Character[i].enabled = false;
        Dialogue[i].enabled = false;
    }
    public void Dialogue_CutIn()
    {
        CutIn_Init();
       
        // int y = 0;
        // for (int i = 0; i < Frame.Count; i++)
        // {
        //     StartCoroutine(CutIn_Disp(i,y));
        //     //_Slider(i);
        //     //StartCoroutine(CutIn_Slide(i,y));
        //     y += 2;
        // }
        //
        StartCoroutine(CutIn_Disp(0,1));
        //StartCoroutine(CutIn_Fin(3));

    }

    private void CutIn_Init()
    {
       
        for (int i = 0; i < Dialogue.Count; i++)
        {
            Dialogue[i].text = _roulette.GetDialogue(i);
        }

        for (int y = 0; y < Character.Count; y++)
        {
            Debug.Log(_roulette.get_D_ID()[y]);
            Character[y].sprite = Resources.Load<Sprite>("Slot/" + _roulette.GetCharacterId(y) + "_Stand");
        }
        
        for (int x = 0; x < Frame.Count; x++)
        {
            pos.Add(Frame[x].transform.localPosition);
            // pos[x] = Character[x].transform.localPosition;
            // Debug.Log(pos[x]);
        }
        pos[Frame.Count-1] = Frame[Frame.Count-1].transform.localPosition;
    }

    IEnumerator CutIn_Disp(int num,float sec)
    {
        
        
        Frame[num].enabled = true;
        Dialogue[num].enabled = true;
        if (num == 2)
        {
            Character[0].enabled = false;
        }

        Character[num].enabled = true;
        yield return new WaitForSeconds(sec);
        if (num < D_Slider.Length)
        {
            D_Slider[num] = true;
        }
        
       
    }

    void _Slider(int num)
    {
        
        if (num > 0)
        {
            Vector3 target = new Vector3(pos[num-1].x, 339f, pos[num-1].z);
            
            if (Vector3.Distance(Frame[num-1].transform.localPosition, target) > 0.001f)
            {
                float step =  300 * Time.deltaTime; // calculate distance to move
                Frame[num-1].transform.localPosition = Vector3.MoveTowards(Frame[num-1].transform.localPosition, target, step);
            }
            else
            {
                D_Slider_Done[num - 1] = true;
            }

        }
    }
    IEnumerator CutIn_Slide(int num,float sec)
    {
        
        if (num > 0)
        {
            Vector3 target = new Vector3(pos[num-1].x, 339f, pos[num-1].z);
            
            while (Vector3.Distance(Frame[num-1].transform.localPosition, target) > 0.001f)
            {
                float step =  1 * Time.deltaTime; // calculate distance to move
                Frame[num-1].transform.localPosition = Vector3.MoveTowards(Frame[num-1].transform.localPosition, target, step);
            }
            yield return new WaitForSeconds(0);
            // yield return new WaitForSeconds(sec);
            // //Frame[num].transform.localPosition = new Vector3(pos[num].x, pos[num].y + 278);
            // Frame[num].transform.localPosition = new Vector3(pos[num].x, pos[num].y);
            // pos[num] = Frame[num].transform.localPosition;

        }
    }

    IEnumerator CutIn_Fin(float sec)
    {
        // Frame[i].enabled = false;
        // Character[i].enabled = false;
        // Dialogue[i].enabled = false;
        yield return new WaitForSeconds(sec);
        for (int i = 0; i < Frame.Count; i++)
        {
            Frame[i].enabled = false;
            Character[i].enabled = false;
            Dialogue[i].enabled = false;
            Frame[i].transform.localPosition = new Vector3(pos[Frame.Count-1].x,pos[Frame.Count-1].y);
        }
    }
}
