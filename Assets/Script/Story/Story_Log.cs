using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story_Log : MonoBehaviour
{
    [SerializeField] private Text LogName;
    [SerializeField] private Text LogText;
    [SerializeField] private int LogNumber;

    List<GameObject> list_LogName = new List<GameObject>();
    List<GameObject> list_LogText = new List<GameObject>();

    public void DrawLog(string name, string text)
    {
        Instantiate(LogName);
        Instantiate(LogText);
        LogName.text = name;
        LogText.text = text;
    }
}
