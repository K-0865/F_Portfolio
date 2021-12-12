using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクターのアニメーション制御
public class Animation_Controler : MonoBehaviour
{
    private Animator _animator;

    private Character_Present_Data data;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        data = GetComponent<Character_Present_Data>();
    }

    //HPがゼロになったら死亡アニメーションを取らせる
    private void Update()
    {
        if (data._dead)
        {
            _animator.SetTrigger("isDead");
        }
       
    }
}
