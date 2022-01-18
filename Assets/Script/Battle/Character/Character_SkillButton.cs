using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キャラクターのアニメーション制御
public class Character_SkillButton : MonoBehaviour
{
        [SerializeField] public List<Character_Present_Data> All_Character_Data;
        [SerializeField] private List<Character_Movement> All_Character_Movement;
        [SerializeField] private List<Animator> All_Character;
        [SerializeField] public List<Skill_Data> C_Position;
        [SerializeField] private List<GameObject> Button;
        [SerializeField] private List<GameObject> HPBar;
        private skil_icon _skilIcon;

        private void Start()
        {
                _skilIcon = GetComponent<skil_icon>();
        }

        public void set_Animator_Character(Animator a)
        {
                All_Character.Add(a);
                Button[All_Character.Count-1].SetActive(true);
                
                // hp.maxValue = All_Character_Data[All_Character.Count - 1]._maxHp;
                // hp.value = All_Character_Data[All_Character.Count - 1]._hp;
        }
        public void set_Data(Character_Present_Data a)
        {
                All_Character_Data.Add(a);
                HPBar[All_Character_Data.Count-1].SetActive(true);
                HPBar_value hp = HPBar[All_Character_Data.Count - 1].GetComponentInChildren<HPBar_value>();
                hp.set_data_C(All_Character_Data[All_Character_Data.Count - 1]);
                Debug.Log("");
                hp._slider.maxValue = All_Character_Data[All_Character_Data.Count - 1]._maxHp;
                hp._slider.value = All_Character_Data[All_Character_Data.Count - 1]._hp;
                _skilIcon._icon[All_Character_Data.Count - 1].sprite =
                        Resources.Load<Sprite>("Battle/UI/icon/" + a._ID + "_icon");

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
                Debug.Log(num);
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
    
    
