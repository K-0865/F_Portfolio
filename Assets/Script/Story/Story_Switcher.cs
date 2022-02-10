using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_Switcher : MonoBehaviour
{
    [SerializeField] private GameObject Log;
    [SerializeField] private GameObject Skip;
    
    [SerializeField]private bool Log_Flag = false;

    public void OnClickLogSwitch()
    {
        if (Log_Flag)
        {
            Log.SetActive(false);
            Log_Flag = false;
            Debug.Log("false");
        }
        else
        {
            Log.SetActive(true);
            Log_Flag = true;
            Debug.Log("true");
        }
    }
}
