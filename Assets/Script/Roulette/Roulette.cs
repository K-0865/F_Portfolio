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

    [SerializeField] private GameObject PauseButton;

    //初期化
    private void Initialize()
    {
        Rcount = 0;
        for (int i = 0; i < data.Dialogue.Count; i++)
        {
            //Debug.Log(data.StageList[i].MapID);
            
            //DialogueテーブルのCharacterID1,2,3に現在生きているバトルシーンに居るオブジェクトのIDがあるテーブルだけを抜き出す
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
        
        //スロットの表示
        Slot.SetActive(true);
        PauseButton.GetComponent<UnityEngine.UI.Button>().interactable = false;

    }


    //Continueが0,1か2,3科を判定する
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

    //Slotのメイン判定部
    public void Roul_main()
    {
       Roul();
       
       //1つ目のセリフを抽出する
       target1 = Random.Range(0, Con_0_1.Count);
       target1 = Con_0_1[target1];
       
       //２つ目のセリフを抽出する
       //Continueが１か２なら次のセリフを２つ目のセリフにする
       if (data.Dialogue[target1].Continue == 1 && data.Dialogue[target1+1].Continue == 2)
       {
           target2 = target1 + 1;
       }
       else //Continueが0か1なら次のセリフをランダムで決める
       {
           target2 = Random.Range(0, Con_0_1.Count);
           target2 = Con_0_1[target2];
           while (target1 == target2)
           {
               target2 = Random.Range(0, Con_0_1.Count);
               target2 = Con_0_1[target2];
           }
       }

       //３つ目のセリフを抽出する
       //２つ目のセリフのContinueが1か２ならその続きのセリフを３つ目のセリフにする
       if ((data.Dialogue[target2].Continue == 2 && data.Dialogue[target2+1].Continue == 3) ||
           (data.Dialogue[target2].Continue == 1 && data.Dialogue[target2+1].Continue == 2))
       {
           target3 = target2 + 1;
       }
       else //上記の条件に当てはまらない場合３つ目のセリフをランダムで抽出する
       {
           target3 = Random.Range(0, Con_0_1.Count);
           target3 = Con_0_1[target3];
           while (target1 == target3 || target3 == target2)
           {
               target3 = Random.Range(0, Con_0_1.Count);
               target3 = Con_0_1[target3];
           }
       }
       
       //抽出したセリフの確認
       Debug.Log(data.Dialogue[target1].Dialogue);
       Debug.Log(data.Dialogue[target2].Dialogue);
       Debug.Log(data.Dialogue[target3].Dialogue);

       //リールの操作に関するコルーチン
       StartCoroutine("DisplaySlot", 2);
       Debug.Log("スタート");
       StartCoroutine("ReelStopL", 7);
       StartCoroutine("ReelStopC", 7.5);
       StartCoroutine("ReelStopR", 8);
       StartCoroutine("ReelFin", 15);

    }

    //遅延を入れてリールスタート
    IEnumerator DisplaySlot(float sec)
    {
        
        yield return new WaitForSeconds(sec);

        Reel_l.GetComponent<ReelController>().first = false;
        Reel_C.GetComponent<ReelController>().first = false;
        Reel_R.GetComponent<ReelController>().first = false;
        RouletteManager.GetComponent<GameController>().Play();
    }

    //各リールを0.5秒ごとに止める
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
    
    //スロットを非表示にする
    IEnumerator ReelFin(float sec)
    {
        yield return new WaitForSeconds(sec);
        Reel_l.GetComponent<ReelController>().first = true;
        Reel_C.GetComponent<ReelController>().first = true;
        Reel_R.GetComponent<ReelController>().first = true;

        Slot.SetActive(false);

        Debug.Log("Fin");
        
        PauseButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
    }
    
}
