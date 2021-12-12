using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクターの移動処理
public class Character_Movement : MonoBehaviour
{

    //キャラクターがどっちの方向を向いているか
    public enum Face_Direction
    {
        LEFT,
        RIGHT
    }

    public bool isAttack = false;
    // Start is called before the first frame update
    private Animator _animator;
    public Face_Direction _faceDirection = Face_Direction.LEFT;
    private Character_Present_Data data;
    void Start()
    {
        data = GetComponent<Character_Present_Data>();
        _animator = this.gameObject.GetComponent<Animator>();
        if (this.gameObject.tag == "Player")
        {
            _faceDirection = Face_Direction.LEFT;
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
        if (!data._found_enemy && data._alive)
        {
            _animator.SetBool("run",true);
            _animator.SetBool("isAttack",false);
        }
        else if(data._found_enemy && data._alive)
        {
            _animator.SetBool("run", false);
            if (!isAttack)
            {
                StartCoroutine("Attack", 100/data._attack_speed);
            }
            
        }
        else if(data._dead)
        {
            _animator.SetBool("run", false);

        }
    
    }

    //攻撃ループ
    IEnumerator Attack(float sec)
    {
        _animator.SetTrigger("isAttack");
        isAttack = true;
       
        yield return new WaitForSeconds(sec);
        isAttack = false;
    }

  //範囲攻撃(現在不使用)
    void RangeAttack()
    {
        GetComponentInChildren<character_rangeType>().Range_bullet();
    }
    // Update is called once per frame
    void C_Walk_R()
    {
        if (_faceDirection == Face_Direction.LEFT)
        {
            if (_animator.GetBool("run") == true)
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

    
}
