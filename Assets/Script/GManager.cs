using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GManager : MonoBehaviour
{
    
    public static GManager instance = null;
    private int lastWidth = 0;
    private int lastHeight = 0;
    public int mapid = 101;
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
            Initialize_PlyerData();
            //Set_PlayerData("level",Level);
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