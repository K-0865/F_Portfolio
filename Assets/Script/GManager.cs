using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    
    //public int[] character_pos { get; private set; } = new[] {102000,1000 };
    public int[] character_pos = new[] {102000,101000,0,0,0 };
    
    public int []get_char_pos()
    {
        return character_pos;
    }

    public void set_char_pos(int [] data)
    {
        character_pos = data;
    }

    //全sceneに置くことで次のsceneに移ったときに破棄されずにこのオブジェクトが各シーンを移動できるようにする
    private void Awake()
    {
        Application.targetFrameRate = 60; // 60fpsに設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Initialize_PlyerData();
            //Set_PlayerData("level",Level);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    
    //プレイヤーデータの保管（Jsonかplayerprefsで管理予定）

    public int Level = 1;
    public int Stamina = 0;
    public int Exp = 0;
    public int Coin = 0;
    public int Jewel = 0;

    private void Initialize_PlyerData()
    {
        Level = PlayerPrefs.GetInt("level", 1);
        Stamina = PlayerPrefs.GetInt("stamina", 0);
        Exp = PlayerPrefs.GetInt("exp", 0);
        Coin = PlayerPrefs.GetInt("coin", 0);
        Jewel = PlayerPrefs.GetInt("jewel", 0);
    }

    public int get_PlayerData(string Lavel)
    {
        int status;
        status = PlayerPrefs.GetInt(Lavel);
        //Debug.Log(status + "Leveltest");
        return status;
    }

    public void Set_PlayerData(string Lavel,int num)
    {
        PlayerPrefs.SetInt(Lavel,num);
        PlayerPrefs.Save ();
    }

    public void Init_PlayerData(string Lavel)
    {
        PlayerPrefs.DeleteKey(Lavel);
    }


    //Json書き出し用のテスト
    /*public void savePlayerData(GManager player)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(player);

        writer = new StreamWriter(Application.dataPath + "./savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    //Json読み込み用のテスト
    public GManager loadPlayerData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "./savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<GManager>(datastr);
    }*/

}