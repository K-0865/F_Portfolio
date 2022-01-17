using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_Charge : MonoBehaviour
{
    [SerializeField] private Slider Slot_Gage;
    [SerializeField] private BattleManager BattleManager;

    public void Start()
    {
        Slot_Gage.minValue = 0;
        Slot_Gage.maxValue = BattleManager._GageMax;

        Slot_Gage.value = BattleManager.hit_count;
    }

    private void Update()
    {
        Slot_Gage.value = BattleManager.hit_count;
    }
}
