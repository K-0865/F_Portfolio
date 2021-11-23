using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
   [SerializeField] private Quest_List data;
   [SerializeField] private int _mapID;
   [SerializeField] private StageTable _PreviewData;
   public int []Enemy_Data;
   public int []Enemy_Stage_Count;
   private void Awake()
   {
      for (int i = 0; i < data.StageList.Count; i++)
      {
         //Debug.Log(data.StageList[i].MapID);
         if (data.StageList[i].MapID == _mapID)
         {
            _PreviewData = data.StageList[i];
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
