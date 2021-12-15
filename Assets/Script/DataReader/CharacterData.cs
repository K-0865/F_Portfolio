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
    [SerializeField] public List<Skill_Data> CharacterSkill = new List<Skill_Data>();
    [SerializeField] public CharacterTable CharacterStatus;
    
    //生成する為にステータスを保管する
    void Awake()
    {
        id = this.gameObject.GetComponentInParent<Character_Present_Data>()._ID;
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
