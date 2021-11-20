using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{

    public enum Face_Direction
    {
        LEFT,
        RIGHT
    }
    // Start is called before the first frame update
    private Animator _animator;
    public bool _found_enemy = false;
    public Face_Direction _faceDirection = Face_Direction.LEFT;
    void Start()
    {
        _animator = this.gameObject.GetComponent<Animator>();
        if (this.gameObject.tag == "Player")
        {
            _faceDirection = Face_Direction.LEFT;
        }else if(this.gameObject.tag == "enemy")
        {
            _faceDirection = Face_Direction.RIGHT;
        }
        
    }
    private void C_Walk_Animation()
    {
        // if Enemy not in area this object walk leaf to right to find enemy
        // it's mean if not have enemy in stage object will walk unit far of right
        if (!_found_enemy)
        {
            _animator.SetBool("run",true);
            _animator.SetBool("isAttack",false);
        }
        else if(_found_enemy)
        {
            _animator.SetBool("run", false);
            
            _animator.SetTrigger("isAttack");
            // 
        }
    }

    void AttackEnd()
    {
        _animator.ResetTrigger("isAttack");
    }
    // Update is called once per frame
    void C_Walk_R()
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
    void Update()
    {
        C_Walk_Animation();
        C_Walk_R();
        
    }

    
}
