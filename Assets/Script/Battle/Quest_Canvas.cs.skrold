using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Canvas : MonoBehaviour
{
    [SerializeField] private List<GameObject> _menus;
    [SerializeField] private List<Image> _star;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GManager.instance._Map_Logs.Count; i++)
        {
            List<bool> foo = GManager.instance._Map_Logs;
            if (foo[i])
            {
                _star[i].sprite = Resources.Load<Sprite>("QuestSelect_UI/Clear_Star");
            }
            else
            {
                _star[i].sprite = Resources.Load<Sprite>("QuestSelect_UI/Empty_Star");

            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
