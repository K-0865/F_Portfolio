using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story_Log : MonoBehaviour
{
    [SerializeField] private Text LogName;
    [SerializeField] private Text LogText;
    
    List<Text> list_LogName = new List<Text>();
    List<Text> list_LogText = new List<Text>();

    private int Lognum;

    public void DrawLog(string name,string text,int num)
    {
        var parent = this.transform;
        Lognum = num ;
        
        list_LogName.Add(Instantiate(LogName,Vector3.zero, Quaternion.identity, parent));
        list_LogText.Add(Instantiate(LogText,Vector3.zero, Quaternion.identity, parent));
        
        list_LogName[num].text = name;
        list_LogText[num].text = text;
    
        list_LogName[num].transform.localPosition = new Vector2(-1800f,-730f+300*num);
        list_LogText[num].transform.localPosition = new Vector2(-1140f,-880f+300*num);

    }
}
