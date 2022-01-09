using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    //データテーブルからキャラクターデータを読み込む
    [SerializeField] private DataTable_pre data = null;
    [SerializeField] private SkillTable Skill_datas = null;
    [SerializeField] private PatternTable PatternData = null;
    private int PatternID;
    private List<int> Skill_get = new List<int>();

    [SerializeField] private List<int> Loop_Pattern;
    [SerializeField] private int Loop_Pattern_Conti;
     //[SerializeField]
    private int id;
    [SerializeField] private Character_SkillButton Add_Skill_Button;
    [SerializeField] public List<Skill_Data> CharacterSkill = new List<Skill_Data>();
    [SerializeField] public CharacterTable CharacterStatus;
    [SerializeField] private GameObject _hp;
    
    //生成する為にステータスを保管する
    void Awake()
    {
        Add_Skill_Button = GameObject.Find("SkillButton").GetComponent<Character_SkillButton>();
        id = this.gameObject.GetComponentInParent<Character_Present_Data>()._ID;
        
        if (this.transform.parent.tag == "Player")
        {
            for (int i = 0; i < data.Character.Count; i++)
            {
                if ((int)data.Character[i].ID == id)
                {
                    CharacterStatus = data.Character[i];
                    Skill_get.Add(CharacterStatus.SkillID1);
                    Skill_get.Add(CharacterStatus.SkillID2);
                    Skill_get.Add(CharacterStatus.SkillID3);
                    Skill_get.Add(CharacterStatus.SkillID4);
                    PatternID = CharacterStatus.patternID;
                    
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < data.Enemy.Count; i++)
            {
                if ((int)data.Enemy[i].ID == id)
                {
                    CharacterStatus = data.Enemy[i];
                    Skill_get.Add(CharacterStatus.SkillID1);
                    Skill_get.Add(CharacterStatus.SkillID2);
                    Skill_get.Add(CharacterStatus.SkillID3);
                    Skill_get.Add(CharacterStatus.SkillID4);
                    PatternID = CharacterStatus.patternID;
                    if (data.Enemy[i].BossFlag)
                    {
                        _hp.GetComponent<HP>().boss = true;
                    }
                    break;
                }
            }
        }
        
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < Skill_datas.SkillIDs.Count; j++)
            {
                if (Skill_get[i] == Skill_datas.SkillIDs[j].SkillID)
                {
                    CharacterSkill.Add(Skill_datas.SkillIDs[j]);
                    
                }
            }
        }
        if (this.transform.parent.tag == "Player")
        {
            Add_Skill_Button.set_Pos(CharacterSkill[3]);
        }

        for (int i = 0; i < PatternData.PatternTables.Count; i++)
        {
            if (PatternID == PatternData.PatternTables[i].PatternID)
            {
                Loop_Pattern_Conti = PatternData.PatternTables[i].LoopConti;
                Loop_Pattern.Add(PatternData.PatternTables[i].Loop1);
                Loop_Pattern.Add(PatternData.PatternTables[i].Loop2);
                Loop_Pattern.Add(PatternData.PatternTables[i].Loop3);
                Loop_Pattern.Add(PatternData.PatternTables[i].Loop4);
                Loop_Pattern.Add(PatternData.PatternTables[i].Loop5);
                Loop_Pattern.Add(PatternData.PatternTables[i].Loop6);
                Loop_Pattern.Add(PatternData.PatternTables[i].Loop7);
                Loop_Pattern.Add(PatternData.PatternTables[i].Loop8);
                Loop_Pattern.Add(PatternData.PatternTables[i].Loop9);
                for (int j = 0; j < Loop_Pattern.Count; j++)
                {
                    if (Loop_Pattern[j] == 0)
                    {
                        Loop_Pattern.RemoveAt(j);
                    }
                }
            }
        }
        gameObject.GetComponentInParent<Character_Movement>().set_Skill_data(CharacterSkill);
        
    }

    public List<Skill_Data >get_Skill()
    {
        return CharacterSkill;
    }
    public List<int> get_Loop()
    {
        return Loop_Pattern;
    }

    public int get_LoopConti()
    {
        return Loop_Pattern_Conti;
    }
        //this.gameObject.tag = this.transform.parent.tag;
          
    

}
