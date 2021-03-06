using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//データテーブルからマップ情報を読み込む
//現状は敵とそのID,のみ将来はマップ背景やWave数毎の生成数を読み込めるようにする
public class MapManager : MonoBehaviour
{
   private BattleManager _battleManager;
   [SerializeField] private Quest_List data;
   [SerializeField] private int _mapID;
   [SerializeField] private StageTable _PreviewData;
   [SerializeField] private map_text _mapText;
   public int []Enemy_Data;
   public int []Enemy_Stage_Count;
   
   //MapIDの確認とEnemyの生成
   private void Awake()
   {
      _mapID = GameManager.instance.mapid;
      _battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
      for (int i = 0; i < data.StageList.Count; i++)
      {
         //Debug.Log(data.StageList[i].MapID);
         if (data.StageList[i].MapID == _mapID)
         {
            _PreviewData = data.StageList[i];
            _battleManager.boss = data.StageList[i].BossFlag;
            _mapText.map_name.text = data.StageList[i].MapName;
            break;
         }
      }
      
      for (int i = 0; i < 3; i++)
      {
         switch (i)
         {
          case  0:
             Enemy_Stage_Count[i] = _PreviewData.EnemyStage1;
             break;
          case  1:
             Enemy_Stage_Count[i] = _PreviewData.EnemyStage2;
             break;
          case  2:
             Enemy_Stage_Count[i] = _PreviewData.EnemyStage3;
             break;
         }
      }
      for (int i = 0; i < 9; i++)
      {
         switch (i)
         {
            case 0:
               Enemy_Data[i] = _PreviewData.EnemyID1;
               break;
            case 1:
               Enemy_Data[i] = _PreviewData.EnemyID2;
               break;
            case 2:
               Enemy_Data[i] = _PreviewData.EnemyID3;
               break;
            case 3:
               Enemy_Data[i] = _PreviewData.EnemyID4;
               break;
            case 4:
               Enemy_Data[i] = _PreviewData.EnemyID5;
               break;
            // case 5:
            //    Enemy_Data[i] = _PreviewData.EnemyID6;
            //    break;
            // case 6:
            //    Enemy_Data[i] = _PreviewData.EnemyID7;
            //    break;
            // case 7:
            //    Enemy_Data[i] = _PreviewData.EnemyID8;
            //    break;
            // case 8:
            //    Enemy_Data[i] = _PreviewData.EnemyID9;
            //    break;
         }
      }
   }

   //各種データの管理
   public StageTable get_PreviewData()
   {
      return _PreviewData;
   }   
   public int []get_EnemyData()
   {
      return Enemy_Data;
   }
   public int []get_Enemy_Stage_Count()
   {
      return Enemy_Stage_Count;
   }
}
