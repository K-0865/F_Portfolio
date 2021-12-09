﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharacterId
{
}

[System.Serializable]
public class CharacterTable
{
    public CharacterId ID;
    public string CharacterName;
    public float HP;
    public float Attack;
    public float Defence;
    public float Speed;
    public float AttackSpeed;
    public float AttackRange;
    public float skillGauge;
    public float GaugeHealing;
    public float Rare;
    public float Level;
    public float Escape;
    public float CriticalDMG;
    public float CriticalHit;
}

// public class StageTable
// {
//     public int MapID;
//     public string MapName;
//     public int StageCount;
//     public int EnrmyPlace;
//     public bool BossFlag;
//     public int EnemyNum1;
//     public int EnemyNum2;
//     public int EnemyNum3;
//     public int EnemyNum4;
//     public int EnemyNum5;
// }
//
// public class Dialogues
// {
//     public int DialogueID;
//     public string DialogueName;
//     public string Dialogue;
//     public int CharacterID1;
//     public int CharacterID2;
//     public int CharacterID3;
//     public int Continue;
//     public int SkillID;
//     public int RouletteID;
// }
