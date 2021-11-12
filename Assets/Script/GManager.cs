using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    
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
    
    [System.Serializable]
    public class Player
    {
        public float Exp;
        public float Level;
        public float Stamina;
        public float coin;
        public float jewel;
        public int []character_pos = new []{1000};

    }

    public void savePlayerData(Player player)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(player);

        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public Player loadPlayerData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<Player>(datastr);
    }

}