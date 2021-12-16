using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクターの移動処理
public class Character_Movement : MonoBehaviour
{

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
    private Character_SkillButton _characterSkillButton;

    void Start()
    {
        LoopConti = GetComponentInChildren<CharacterData>().get_LoopConti();
        Loop_Pattern = GetComponentInChildren<CharacterData>().get_Loop();
        data = GetComponent<Character_Present_Data>();
        _animator = this.gameObject.GetComponent<Animator>();
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

    //攻撃ループ
    IEnumerator Attack(int Loop,float sec)
    {
        
        _Player = PlayerState.isAttack;
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

        
        if (LoopAt > Loop_Pattern.Count)
        {
            LoopAt = LoopConti;
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
        GetComponentInChildren<character_rangeType>().Range_bullet();
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
                this.gameObject.transform.position += new Vector3(1, 0) * Time.deltaTime;
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
                this.gameObject.transform.position -= new Vector3(1, 0) * Time.deltaTime;
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
        if (!GameObject.Find("BattleManager").GetComponent<BattleManager>().isPause)
        {
            _animator.enabled = true;
            C_Walk_Animation();
            C_Walk_R();
        }    else if (GameObject.Find("BattleManager").GetComponent<BattleManager>().isPause)
        {
            _animator.enabled = false;
        }
    }

    public void set_Player_State(PlayerState state)
    {
        _Player = state;
    }
    
}
