using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Exp_Charge: MonoBehaviour
{
    [SerializeField] private Slider Exp_Gage;
    [SerializeField] private PlayerExp _ExpTable;
    [SerializeField] private TextMeshProUGUI PlayerLevel;

    private float GageMax;
    private float GageBefore;
    
    int PL = GManager.instance.player.Level;
    private void Start()
    {
        for (int i = 0; i < _ExpTable.ExpTable.Count; i++)
        {
            if (_ExpTable.ExpTable[i].PlayerLevel == PL)
            {
                if (1 == PL)
                {
                    Exp_Gage.minValue = 0;
                }
                else
                {
                    Exp_Gage.minValue = _ExpTable.ExpTable[i - 1].Exp;
                }

                if (_ExpTable.ExpTable.Count >= PL)
                {
                    Exp_Gage.maxValue = _ExpTable.ExpTable[i].Exp;
                }
                else
                {
                    Exp_Gage.maxValue = _ExpTable.ExpTable[i + 1].Exp;
                }
            }
        }
        Exp_Gage.value = GManager.instance.player.Exp;
        //GManager.instance.player.Level;
        PlayerLevel.text = GManager.instance.player.Level.ToString();
        
        //GManager.instance.savePlayerData();
        //GManager.instance.loadPlayerData();
    }
    
}
