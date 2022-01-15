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
            //Debug.Log(_roulette.get_D_ID()[y]);
            Character[y].sprite = Resources.Load<Sprite>("UI/Dialog/" + _roulette.GetCharacterId(y) + "_Stand");
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
        if (num > 0 && _roulette.GetCharacterId(num) == _roulette.GetCharacterId(num-1))
        {
            Character[num].transform.localPosition = Character[num - 1].transform.localPosition;
            Character[num].enabled = true;
            Character[num-1].enabled = false;
            Frame[num].transform.localScale = Frame[num-1].transform.localScale;
            Dialogue[num].transform.localScale = Dialogue[num-1].transform.localScale;

        }
        else
        {
            if (num > 0)
            {
                if (Character[num-1].transform.localPosition.x == -212f)
                {
                    Character[num].transform.localPosition = new Vector3(1641f,
                        Character[num].transform.localPosition.y, Character[num].transform.localPosition.z);
                }
                else
                {
                    Character[num].transform.localPosition = new Vector3(-212f,
                        Character[num].transform.localPosition.y, Character[num].transform.localPosition.z);
                }

                if (Frame[num-1].transform.localScale.x == 1f)
                {
                    Frame[num].transform.localScale = new Vector3(-1f, 1f, 1f);
                    // Frame[num].transform.localPosition = new Vector3(780f,
                    //     Frame[num].transform.localPosition.y, Frame[num].transform.localPosition.z);
                    Dialogue[num].transform.localScale = Frame[num].transform.localScale;
                    Dialogue[num].transform.localPosition = new Vector3(98, Dialogue[num].transform.localPosition.y,
                        Dialogue[num].transform.localPosition.z);
                }
                else
                {
                    Frame[num].transform.localScale = new Vector3(1f, 1f, 1f);
                    // Frame[num].transform.localPosition = new Vector3(740f,
                    //     Frame[num].transform.localPosition.y, Frame[num].transform.localPosition.z);
                    Dialogue[num].transform.localScale = Frame[num].transform.localScale;
                    Dialogue[num].transform.localPosition = new Vector3(-147, Dialogue[num].transform.localPosition.y,
                        Dialogue[num].transform.localPosition.z);

                }

            
                //Frame[num].transform.rotation = new Quaternion(Frame[num].transform.rotation.x, Frame[num].transform.rotation.y + 180f, Frame[num].transform.rotation.z, Frame[num].transform.rotation.w);
                //Dialogue[num].transform.rotation = Frame[num].transform.rotation;
            }
            
            Character[num].enabled = true;
            // if (Frame[num].transform.localScale.x == -1f)
            // {
            //     Frame[num].transform.localPosition = new Vector3(780f,
            //         Frame[num].transform.localPosition.y, Frame[num].transform.localPosition.z);
            // }
            // else
            // {
            //     Frame[num].transform.localPosition = new Vector3(740f,
            //         Frame[num].transform.localPosition.y, Frame[num].transform.localPosition.z);
            // }
            
        }
        
        
        Frame[num].enabled = true;
        Dialogue[num].enabled = true;
        if (num == 2)
        {
            Character[0].enabled = false;
        }

        //Character[num].enabled = true;
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
            Vector3 target = new Vector3(pos[num-1].x, 121f, pos[num-1].z);
            
            if (Vector3.Distance(Frame[num-1].transform.localPosition, target) > 0.001f)
            // if (target.y - Frame[num-1].transform.localPosition.y > 0.01f)
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
