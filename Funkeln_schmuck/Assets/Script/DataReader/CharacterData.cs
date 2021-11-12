using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private DataTable_pre data = null;

    [SerializeField]
    private int id;
    [SerializeField]
    private CharacterTable CharacterStatus = null;
    void Start()
    {
        for (int i = 0; i < data.Character.Count; i++)
        {
            if (data.Character[i].ID == id)
            {
                CharacterStatus = data.Character[i];
                break;
            }
        }

        /* How to use STATUS
        CharacterStatus[0] == id
        CharacterStatus[1] == characterName
        CharacterStatus[2] == HP
        CharacterStatus[3] == Attack
        CharacterStatus[4] == Defence
        CharacterStatus[5] == Speed
        CharacterStatus[6] == AttackSpeed
        CharacterStatus[7] == skillGauge
        CharacterStatus[8] == GaugeHealing
        CharacterStatus[9] == Rare
        CharacterStatus[10] == Level
        CharacterStatus[11] == Escape
        CharacterStatus[12] == CriticalDMG
        CharacterStatus[13] == CriticalHit
        */
    }

  
}
