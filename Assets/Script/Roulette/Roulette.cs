using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class Roulette : MonoBehaviour
{
    private int Rcount = 0;
    private List<int> DiaIDList = new List<int>(200);
    private List<int> DiaLine = new List<int>(200);
    private List<int> DisplayDialogue = new List<int>(200);
    private List<int> DiaCon = new List<int>(200);
    private List<string> DiaDisplay = new List<string>(200);
    private int target1 = 0;
    private int target2 = 0;
    private int target3 = 0;
    List<int> Con_0_1 = new List<int>(99);
    List<int> Con_2_3 = new List<int>(99);
    [SerializeField] private Dialogue_Table data = null;
    [SerializeField] private GameObject Slot;

    [SerializeField] private int _AliveCharacterID1;
    [SerializeField] private int _AliveCharacterID2;
    [SerializeField] private int _AliveCharacterID3;

    [SerializeField] private GameObject Reel_l;
    [SerializeField] private GameObject Reel_C;
    [SerializeField] private GameObject Reel_R;

    [SerializeField] private Dialogues _DialogueStatus;

    [SerializeField] private GameObject RouletteManager;

    //初期化
    private void Initialize()
    {
        Rcount = 0;
        for (int i = 0; i < data.Dialogue.Count; i++)
        {
            //Debug.Log(data.StageList[i].MapID);
            if ((data.Dialogue[i].CharacterID1 == _AliveCharacterID1 || 
                data.Dialogue[i].CharacterID1 == _AliveCharacterID2 || 
                data.Dialogue[i].CharacterID1 == _AliveCharacterID3) &&(
                data.Dialogue[i].CharacterID2 == _AliveCharacterID1 ||
                data.Dialogue[i].CharacterID2 == _AliveCharacterID2 ||
                data.Dialogue[i].CharacterID2 == _AliveCharacterID3 ||
                data.Dialogue[i].CharacterID2 == 0 ||
                data.Dialogue[i].CharacterID2 == null )&&(
                data.Dialogue[i].CharacterID3 == _AliveCharacterID1 ||
                data.Dialogue[i].CharacterID3 == _AliveCharacterID2 ||
                data.Dialogue[i].CharacterID3 == _AliveCharacterID3 ||
                data.Dialogue[i].CharacterID3 == 0 ||
                data.Dialogue[i].CharacterID3 == null )
                )
            {
                DiaLine.Add(i);
                DiaIDList.Add(data.Dialogue[i].DialogueID);
                DiaCon.Add(data.Dialogue[i].Continue);
                DiaDisplay.Add(data.Dialogue[i].Dialogue);
                Rcount++;
            }
        }
        
        Slot.SetActive(true);

    }



    public void Roul()
    {
        Initialize();
        for (int i = 0; i < DiaIDList.Count; i++)
        {
            if (DiaCon[i] == 0 || DiaCon[i] == 1)
            {
                Con_0_1.Add(DiaLine[i]);
            }
            else
            {
                Con_2_3.Add(DiaLine[i]);
            }
        }
    }

    public void Roul_main()
    {
       Roul();
       target1 = Random.Range(0, Con_0_1.Count);
       target1 = Con_0_1[target1];
       if (data.Dialogue[target1].Continue == 1 && data.Dialogue[target1+1].Continue == 2)
       {
           target2 = target1 + 1;
       }
       else
       {
           target2 = Random.Range(0, Con_0_1.Count);
           target2 = Con_0_1[target2];
           while (target1 == target2)
           {
               target2 = Random.Range(0, Con_0_1.Count);
               target2 = Con_0_1[target2];
           }
       }

       if ((data.Dialogue[target2].Continue == 2 && data.Dialogue[target2+1].Continue == 3) ||
           (data.Dialogue[target2].Continue == 1 && data.Dialogue[target2+1].Continue == 2))
       {
           target3 = target2 + 1;
       }
       else
       {
           target3 = Random.Range(0, Con_0_1.Count);
           target3 = Con_0_1[target3];
           while (target1 == target3 || target3 == target2)
           {
               target3 = Random.Range(0, Con_0_1.Count);
               target3 = Con_0_1[target3];
           }
       }

       Debug.Log(data.Dialogue[target1].Dialogue);
       Debug.Log(data.Dialogue[target2].Dialogue);
       Debug.Log(data.Dialogue[target3].Dialogue);

       StartCoroutine("DisSlot", 1.5);
       StartCoroutine("StartSlot", 10);
       Debug.Log("スタート");
       StartCoroutine("ReelStopL", 7);
       StartCoroutine("ReelStopC", 7.5);
       StartCoroutine("ReelStopR", 8);
       StartCoroutine("ReelFin", 11);

    }

    IEnumerator DisSlot(float sec)
    {
        yield return new WaitForSeconds(sec);
        RouletteManager.GetComponent<GameController>().Play();
    }
    
    //コルーチンテスト 139行目から
    IEnumerator StartSlot(float sec)
    {
        yield return new WaitForSeconds(sec);
        Debug.Log("コルーチンスタート");

    }

    IEnumerator ReelStopL(float sec)
    {   
        yield return new WaitForSeconds(sec);
        Debug.Log("SlotL");
        Reel_l.GetComponent<ReelController>().Reel_Stop();
    }
    IEnumerator ReelStopC(float sec)
    {
        yield return new WaitForSeconds(sec);
        Debug.Log("SlotC");
        Reel_C.GetComponent<ReelController>().Reel_Stop();
    }
    IEnumerator ReelStopR(float sec)
    {
        yield return new WaitForSeconds(sec);
        Debug.Log("SlotR");
        Reel_R.GetComponent<ReelController>().Reel_Stop();
    }
    IEnumerator ReelFin(float sec)
    {
        yield return new WaitForSeconds(sec);
        Slot.SetActive(false);
        Debug.Log("Fin");
    }
    


}
