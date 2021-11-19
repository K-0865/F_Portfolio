using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
   [SerializeField] private Quest_List data;
   [SerializeField] private int _mapID;
   [SerializeField] private StageTable _PreviewData;

   private void Start()
   {
      for (int i = 0; i < data.StageList.Count; i++)
      {
         Debug.Log(data.StageList[i].MapID);
         if (data.StageList[i].MapID == _mapID)
         {
            _PreviewData = data.StageList[i];
            break;
         }
      }

   }
}
