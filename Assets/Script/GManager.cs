﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    
    //全sceneに置くことで次のsceneに移ったときに破棄されずにこのオブジェクトが各シーンを移動できるようにする
    private void Awake()
    {
        Application.targetFrameRate = 60; // 60fpsに設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }
    
    //プレイヤーデータの保管（Jsonかplayerprehubで管理予定）
    [System.Serializable]
    public class Player
    {
        public float Exp;
        public float Level;
        public float Stamina;
        public float coin;
        public float jewel;

        public int[] character_pos { get; private set; } = new[] {102000,1000 };
        public int []get_char_pos()
        {
            return character_pos;
        }

        public void set_char_pos(int [] data)
        {
            character_pos = data;
        }
        
    }

    //Json書き出し用のテスト
    public void savePlayerData(Player player)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(player);

        writer = new StreamWriter(Application.dataPath + "./savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    //Json読み込み用のテスト
    public Player loadPlayerData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "./savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<Player>(datastr);
    }

}