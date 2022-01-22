using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]　public class SaveData
{
    public int Level = 1;
    public int Stamina = 0;
    public int Exp = 0;
    public int Coin = 0;
    public int Jewel = 0;
} 

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    private int lastWidth = 0;
    private int lastHeight = 0;
    public int mapid = 101;
    public int[] character_pos = new[] {102000,101000,0,0,0 };
    public SaveData player = new SaveData();
    private string Savefile;

    public int []get_char_pos()
    {
        return character_pos;
    }

    public void set_char_pos(int [] data)
    {
        character_pos = data;
    }
    void Force_Camera(){
        float targetaspect = 19.5f / 9.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if(scaleheight < 1.0f){
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
            camera.rect = rect;
        }
        else{
            float scalewidth = 1.0f / scaleheight;
            Rect rect = camera.rect;
            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }
    
   
    //全sceneに置くことで次のsceneに移ったときに破棄されずにこのオブジェクトが各シーンを移動できるようにする
    private void Awake()
    {
        Force_Camera();
        //Screen.SetResolution(2436,1125,false);
        Application.targetFrameRate = 60; // 60fpsに設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            InitSaveData();
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    private void Update()
    {
        var width = Screen.width; var height = Screen.height;
 
         if (lastWidth != width) // if the user is changing the width
         {
             // update the height
             var heightAccordingToWidth = width / 19.5 * 9.0f;
             Screen.SetResolution(width, (int)Mathf.Round((float)heightAccordingToWidth), false, 0);
         }
         else if (lastHeight != height) // if the user is changing the height
         {
             // update the width
             var widthAccordingToHeight = height / 9.0 * 19.5;
             Screen.SetResolution((int)Mathf.Round((float)widthAccordingToHeight), height, false, 0);
         }
         lastWidth = width;
         lastHeight = height;
     
    }
    
    //プレイヤーデータの保管(Jsonで行う)
    //（playerprefsでは問題が多そうな為中止）
    /*public int Level = 1;
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
    */

    //Json処理の初期化
    private void InitSaveData()
    {
        Savefile = "/savedata.json";
    }
    
    //Json書き出し用のテスト
    public void savePlayerData(SaveData saveData)
    {
        string jsonstr = JsonUtility.ToJson(saveData,false);
        StreamWriter writer = new StreamWriter(Application.dataPath + Savefile, false);
        
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
        
        Debug.Log(jsonstr);
    }

    //Json読み込み用のテスト
    public SaveData Load()
    {
        if (File.Exists(Application.dataPath + Savefile))
        {
            string datastr = "";
            StreamReader reader;
            reader = new StreamReader(Application.dataPath + Savefile);
            datastr = reader.ReadToEnd();
            reader.Close();
            
            return JsonUtility.FromJson<SaveData>(datastr);
        }

        player.Level = 1;
        player.Exp = 0;
        player.Stamina = 0;
        player.Coin = 0;
        player.Jewel = 0;
        return player;
    }

}