using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class Roulette : MonoBehaviour
{
    private int Rcount = 0;
    private List<int> DiaIDList = new List<int>();
    private List<int> DisplayDialogue = new List<int>();
    private List<int> DiaCon= new List<int>();
    private int target1 = 0;
    private int target2 = 0;
    private int target3 = 0;
    [SerializeField] private Dialogue_Table data = null;

    [SerializeField] private int _AliveCharacterID1;
    [SerializeField] private int _AliveCharacterID2;
    [SerializeField] private int _AliveCharacterID3;

    [SerializeField] private Dialogues _DialogueStatus;

    [SerializeField] private int rouletteGage;

    [SerializeField] private int GageMax;

    //初期化
    private void Initialize()
    {
        Rcount = 0;
        for (int i = 0; i < data.Dialogue.Count; i++)
        {
            //Debug.Log(data.StageList[i].MapID);
            if (data.Dialogue[i].CharacterID1 == _AliveCharacterID1 || 
                data.Dialogue[i].CharacterID1 == _AliveCharacterID2 || 
                data.Dialogue[i].CharacterID1 == _AliveCharacterID3)
            {
                DiaIDList.Add(data.Dialogue[i].CharacterID1);
                Rcount++;
            }
        }

    }

    public void Roulette_main()
    {
        Initialize();
        Rcount++;

        //一つ目のセリフ決定
        target1 = Random.Range(1, Rcount);
        Roulette1(target1);

        //2つ目のセリフ決定
        if (1 == data.Dialogue[target1].Continue)
        {
            //Continueが１の場合
            target2 = target1 + 1;
            Roulette2(target2);
        }
        else
        {
            //Continueが1以外の場合
            target2 = Random.Range(1, Rcount);
            while (target1  == target2)
            {
                target2 = Random.Range(1, Rcount);
            }
            Roulette2(target2);
            
            //3つ目のセリフの決定
            if (1 == data.Dialogue[target1].Continue)
            {
                //2つ目のセリフのContinueが１の場合
                target3 = target2 + 1;
                Roulette3(target3);
            }
            else
            {
                //Continueが1以外の場合
                target3 = Random.Range(1, Rcount);
                while (target2  == target3)
                {
                    target3 = Random.Range(1, Rcount);
                }
                Roulette3(target3);
            }
        }

        //3つ目のセリフ決定
        if (2 == data.Dialogue[target2].Continue)
        {
            //Continueが2の場合
            target3 = target2 + 1;
            Roulette3(target3);
        }
        else
        {
            //Continueが2意外の場合
            target3 = Random.Range(1, Rcount);
            while (target1  == target2 && target2  == target3)
            {
                target3 = Random.Range(1, Rcount);
            }
            Roulette3(target3);
        }
        
        Debug.Log(data.Dialogue[target1].CharacterID1);
        Debug.Log(data.Dialogue[target2].CharacterID1);
        Debug.Log(data.Dialogue[target3].CharacterID1);
    }

    private void Roulette1(int target)
    {
        DiaIDList.Add(data.Dialogue[target].DialogueID);
    }
    
    private void Roulette2(int target)
    {
        DiaIDList.Add(data.Dialogue[target].DialogueID);
    }
    
    private void Roulette3(int target)
    {
        DiaIDList.Add(data.Dialogue[target].DialogueID);
    }

    public void Sub()
    {
        
    }
}
