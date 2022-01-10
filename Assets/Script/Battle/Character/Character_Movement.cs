using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクターの移動処理
public class Character_Movement : MonoBehaviour
{
    
    private float speed = 2.0f;
    //キャラクターがどっちの方向を向いているか
    public enum PlayerState
    {
        Idle,Attack,isAttack,Run,Dead
    }
    
    public enum Face_Direction
    {
        LEFT,
        RIGHT
    }

    public int LoopAt = 0;
    private int LoopConti;
    public bool isAttack = false;
    // Start is called before the first frame update
    private Animator _animator;
    public PlayerState _Player;
    public Face_Direction _faceDirection = Face_Direction.LEFT;
    private Character_Present_Data data;
    private List<int> Loop_Pattern;
    [SerializeField] List<Skill_Data> _skillData;
    private Character_SkillButton _characterSkillButton;
    [SerializeField]private Character_attack_range _attackRange;
    private Character_Present_Data _characterPresentData;
    [SerializeField]public bool isUseSP = false;
    [SerializeField]private GameObject[] P_Factory;
    [SerializeField]private GameObject[] E_Factory;
    private BattleManager _battleManager;
    void Start()
    {
        _battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        _characterPresentData = GetComponent<Character_Present_Data>();
        LoopConti = GetComponentInChildren<CharacterData>().get_LoopConti();
        Loop_Pattern = GetComponentInChildren<CharacterData>().get_Loop();
        data = GetComponent<Character_Present_Data>();
        _animator = this.gameObject.GetComponent<Animator>();
        P_Factory = GameObject.Find("Character_Factory").GetComponent<char_factory>()._character_clone;
        E_Factory = GameObject.Find("Enemy_Factory").GetComponent<Enemy_Fac>()._enemy_clone;
        if (this.gameObject.tag == "Player")
        {
            _faceDirection = Face_Direction.LEFT;
            _characterSkillButton = GameObject.Find("SkillButton").GetComponent<Character_SkillButton>();
            _characterSkillButton.set_Animator_Character(_animator);
            _characterSkillButton.set_Movement_Character(this);
        }else if(this.gameObject.tag == "enemy")
        {
            _faceDirection = Face_Direction.RIGHT;
        }

    }
    
    //歩行アニメーションの呼び出し
    private void C_Walk_Animation()
    {
        // if Enemy not in area this object walk leaf to right to find enemy
       
         // it's mean if not have enemy in stage object will walk unit far of right
        if (!data._found_enemy && data._alive && _Player != PlayerState.isAttack)
        {
            _animator.SetBool("run",true);
            _Player = PlayerState.Run;
            //_animator.SetBool("isAttack",false);
        }
        else if(data._found_enemy && data._alive)
        {
            _animator.SetBool("run", false);
            
            if (!isAttack && _Player != PlayerState.isAttack)
            {
                _Player = PlayerState.isAttack;
                //StartCoroutine("Attack", 100/data._attack_speed);
                StartCoroutine(Attack(Loop_Pattern[LoopAt],100/data._attack_speed));
            }
            
        }
        else if(data._dead)
        {
            _animator.SetBool("run", false);

        }
    
    }

    private void useBuff(int skill_num)
    {
        
        
        if (this.tag == "Player")
        {
            //GameObject []Factory = GameObject.Find("Character_Factory").GetComponent<char_factory>()._character_clone;
            Skill_Data skill = _skillData[skill_num];
            for (int i = 0; i < P_Factory.Length; i++)
            {
                if (P_Factory[i] != null)
                {
//                    Debug.Log(Factory.Length);
                    P_Factory[i].GetComponent<Character_Present_Data>().setBuff(skill);
                }
               
            }
        }
        else if (this.tag == "Enemy")
        {
            //GameObject []Factory = GameObject.Find("Character_Factory").GetComponent<char_factory>()._character_clone;
            Skill_Data skill = _skillData[skill_num];
            for (int i = 0; i < E_Factory.Length; i++)
            {
                if (E_Factory[i] != null)
                {
//                    Debug.Log(Factory.Length);
                    E_Factory[i].GetComponent<Character_Present_Data>().setBuff(skill);
                }
               
            }
        }

    }
    //攻撃ループ
    IEnumerator Attack(int Loop,float sec)
    {
        
        _Player = PlayerState.isAttack;
        if (!isUseSP)
        {
            switch (Loop)
            {
                case 1:
                    _animator.SetTrigger("isNormalAttack");
                    break;
                case 2:
                    _animator.SetTrigger("isSkill1");
                    break;
                case 3:
                    _animator.SetTrigger("isSkill2");
                    break;
            }
        }
        else
        {
            _animator.SetTrigger("isSPSkill");
        }
        

        
        
        isAttack = true;
       
        yield return new WaitForSeconds(sec);
        LoopAt++;
        //_Player = PlayerState.Idle;
        isAttack = false;
    }

  //範囲攻撃(現在不使用)
    void RangeAttack()
    {
        if (_characterPresentData._found_enemy)
        {
            GetComponentInChildren<character_rangeType>().Range_bullet(_skillData[Loop_Pattern[LoopAt]-1].Attack);
        }
    }

    void set_PlayerState()
    {
        _Player = PlayerState.Idle;
    }
    // Update is called once per frame
    void C_Walk_R()
    {
        if (_faceDirection == Face_Direction.LEFT)
        {
            if (_animator.GetBool("run") == true && _Player != PlayerState.isAttack)
            {
                this.gameObject.transform.position += new Vector3(speed, 0) * Time.deltaTime;
            }
            else
            {
                this.gameObject.transform.position += new Vector3(0, 0) * Time.deltaTime;
            
            }
        }
        else
        {
            if (_animator.GetBool("run") == true)
            {
                this.gameObject.transform.position -= new Vector3(speed, 0) * Time.deltaTime;
            }
            else
            {
                this.gameObject.transform.position += new Vector3(0, 0) * Time.deltaTime;
            
            }
        }
        
    }
    
    //アニメーションの呼び出し
    void Update()
    {
        if (_battleManager._start_player || _battleManager._start_enemy)
        {
            
            if (LoopAt >= Loop_Pattern.Count)
            {
                LoopAt = LoopConti;
            }

            if (_battleManager._ready_player && this.transform.tag == "Player" && !_battleManager._gamestart)
            {
                _animator.SetBool("Force_Stand", true);
            }
            if (_battleManager._ready_enemy && this.transform.tag == "enemy" && !_battleManager._gamestart)
            {
                _animator.SetBool("Force_Stand", true);

            }
            if(_battleManager._gamestart)
            {
                _animator.SetBool("Force_Stand", false);
            }
            
            if (!_battleManager.isPause && _battleManager._gamestart)
            {
                _animator.enabled = true;
                C_Walk_Animation();
                C_Walk_R();
                if (!isUseSP)
                {
                    _attackRange.set_Skill_range_Now(_skillData[Loop_Pattern[LoopAt] - 1].Range);

                }
                else
                {
                    _attackRange.set_Skill_range_Now(_skillData[3].Range);

                }
            }
            else if (_battleManager.isPause)
            {
                _animator.enabled = false;
            }
        }
        if (!_battleManager._start_player && this.transform.tag == "Player")
        {
            _animator.enabled = true;
            C_Walk_Animation();
            C_Walk_R();
        }
        if (!_battleManager._start_enemy && this.transform.tag == "enemy")
        {
            _animator.enabled = true;
            C_Walk_Animation();
            C_Walk_R();
        }
        
    }


    public void set_Skill_data(List<Skill_Data> info)
    {
        _skillData = info;
        
    }
    public void set_Player_State(PlayerState state)
    {
        _Player = state;
    }

    public void set_isSP()
    {
        isUseSP = false;
    }
}
