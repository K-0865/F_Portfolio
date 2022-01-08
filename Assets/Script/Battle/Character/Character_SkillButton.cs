using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キャラクターのアニメーション制御
public class Character_SkillButton : MonoBehaviour
{
        [SerializeField] private List<Character_Movement> All_Character_Movement;
        [SerializeField] private List<Animator> All_Character;
        [SerializeField] public List<Skill_Data> C_Position;
        [SerializeField] private List<GameObject> Button;
        public void set_Animator_Character(Animator a)
        {
                All_Character.Add(a);
                //Button[All_Character.Count-1].SetActive(true);
        }
        public void set_Movement_Character(Character_Movement a)
        {
                All_Character_Movement.Add(a);
        }

        public void set_Pos(Skill_Data Char)
        {
                C_Position.Add(Char);
        }

        public void Use_Skill(int num)
        {
                if (!All_Character_Movement[num].isUseSP)
                {
                        All_Character_Movement[num].isUseSP = true;
                }
                else
                {
                        All_Character_Movement[num].isUseSP = false;
                }
                // All_Character[num].SetTrigger("isSPSkill");
                // All_Character_Movement[num].set_Player_State(Character_Movement.PlayerState.isAttack);
        }

       
}
    
    
