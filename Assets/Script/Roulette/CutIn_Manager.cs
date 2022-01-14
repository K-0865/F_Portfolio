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

    private List<Vector3> pos;

    public void Dialogue_CutIn()
    {
        CutIn_Init();

        int y = 0;
        for (int i = 0; i < Frame.Count; i++)
        {
            StartCoroutine(CutIn_Disp(i,y));
            StartCoroutine(CutIn_Slide(i,y));
            y += 2;
        }

        StartCoroutine(CutIn_Fin(3));

    }

    private void CutIn_Init()
    {
        for (int i = 0; i < Dialogue.Count; i++)
        {
            Dialogue[i].text = _roulette.GetDialogue(i);
        }

        for (int y = 0; y < Character.Count; y++)
        {
            Character[y].sprite = Resources.Load<Sprite>("Slot/" + _roulette.GetCharacterId(y) + "_Stand");
        }

        for (int x = 0; x < Frame.Count; x++)
        {
            pos[x] = Character[x].transform.localPosition;
        }
        pos[Frame.Count] = Character[Frame.Count].transform.localPosition;
    }

    IEnumerator CutIn_Disp(int num,float sec)
    {
        yield return new WaitForSeconds(sec);
        Frame[num].enabled = true;
        Dialogue[num].enabled = true;
        if (num == 2)
        {
            Character[0].enabled = false;
        }

        Character[num].enabled = true;
    }
    IEnumerator CutIn_Slide(int num,float sec)
    {
        if (num < 2)
        {
            yield return new WaitForSeconds(sec);
            Character[num].transform.localPosition = new Vector3(pos[num].x, pos[num].y + 278);
            pos[num] = Character[num].transform.localPosition;
        }
    }

    IEnumerator CutIn_Fin(float sec)
    {
        yield return new WaitForSeconds(sec);
        for (int i = 0; i < Frame.Count; i++)
        {
            Frame[i].enabled = false;
            Character[i].enabled = false;
            Dialogue[i].enabled = false;
            Character[i].transform.localPosition = new Vector3(pos[Frame.Count].x,pos[Frame.Count].y);
        }
    }
}
