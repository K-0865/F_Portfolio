using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [SerializeField] private Dialogue_Table data = null;

    [SerializeField] private int _dialogueID;

    [SerializeField] private Dialogues _DialogueStatus;

    private void Awake()
    {
        for (int i = 0; i < data.Dialogue.Count; i++)
        {
            //Debug.Log(data.StageList[i].MapID);
            if (data.Dialogue[i].DialogueID == _dialogueID)
            {
                _DialogueStatus = data.Dialogue[i];
                break;
            }
        }
    }
}
