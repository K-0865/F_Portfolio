using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Mask_Charge : MonoBehaviour
{
    [SerializeField] private Slider Exp_Gage;
    [SerializeField] private GameObject Manager;

    private float GageMax;
    private float GageNow;
    private float GageBefore;

    private void Update()
    {
        Exp_Gage.minValue = GageBefore;
        Exp_Gage.maxValue = GageMax;
        Exp_Gage.value = GageNow;
    }
}
