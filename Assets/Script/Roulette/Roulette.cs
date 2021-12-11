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
    private List<int> DisplayDialogue = new List<int>(200);
    private List<int> DiaCon = new List<int>(200);
    private List<string> DiaDisplay = new List<string>(200);
    private int target1 = 0;
    private int target2 = 0;
    private int target3 = 0;
    [SerializeField] private Dialogue_Table data = null;
    [SerializeField] private GameObject Slot;

    [SerializeField] private int _AliveCharacterID1;
    [SerializeField] private int _AliveCharacterID2;
    [SerializeField] private int _AliveCharacterID3;

    [SerializeField] private Dialogues _DialogueStatus;

    [SerializeField] private int rouletteGage;

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
                DiaIDList.Add(data.Dialogue[i].DialogueID);
                DiaCon.Add(data.Dialogue[i].Continue);
                DiaDisplay.Add(data.Dialogue[i].Dialogue);
                Rcount++;
            }
        }
        
        Slot.SetActive(true);

    }

    public void Roulette_main()
    {
        Initialize();
        Rcount++;

        //一つ目のセリフ決定
        target1 = Random.Range(1, Rcount);
        Debug.Log(target1 + "調査");
        RouletteIn(target1);

        //2つ目のセリフ決定
        if (1 == DiaCon[target1])
        {
            //Continueが１の場合
            target2 = target1 + 1;
            RouletteIn(target2);
        }
        else
        {
            //Continueが1以外の場合
            target2 = Random.Range(1, Rcount);
            while (target1  == target2)
            {
                target2 = Random.Range(1, Rcount);
            }
            RouletteIn(target2);
            
            //3つ目のセリフの決定
            if (1 == DiaCon[target2])
            {
                //2つ目のセリフのContinueが１の場合
                target3 = target2 + 1;
                RouletteIn(target3);
            }
            else
            {
                //Continueが1以外の場合
                target3 = Random.Range(1, Rcount);
                while (target2  == target3)
                {
                    target3 = Random.Range(1, Rcount);
                }
                RouletteIn(target3);
            }
        }

        //3つ目のセリフ決定
        if (2 == data.Dialogue[target2].Continue)
        {
            //Continueが2の場合
            target3 = target2 + 1;
            RouletteIn(target3);
        }
        else
        {
            //Continueが2意外の場合
            target3 = Random.Range(1, Rcount);
            while (target1  == target2 && target2  == target3)
            {
                target3 = Random.Range(1, Rcount);
            }
            RouletteIn(target3);
        }

        int DispCon = 0;
        while (DispCon < data.Dialogue.Count)
        {
            if (data.Dialogue[DispCon].DialogueID == DisplayDialogue[DispCon])
            {
                Debug.Log(data.Dialogue[DispCon]);
            } 
            DispCon++;
        }
        
        

        Debug.Log(data.Dialogue[target1].CharacterID1);
        Debug.Log(data.Dialogue[target2].CharacterID1);
        Debug.Log(data.Dialogue[target3].CharacterID1);

        //コルーチンテスト152行目呼び出し
       //StartCoroutine("Stop", 10f);231
    }

    private void RouletteIn(int target)
    {
        DisplayDialogue.Add(DiaIDList[target]);
    }


    //コルーチンテスト 139行目から
    /*IEnumerator Stop(float sec)
    {
        yield return new WaitForSeconds(sec);
    }*/
        

}
