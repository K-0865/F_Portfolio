using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controler : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;

    private Character_Present_Data data;
    // Update is called once per frame
    private void Start()
    {
        _animator = GetComponent<Animator>();
        data = GetComponent<Character_Present_Data>();
    }

    private void Update()
    {
        if (data._alive == true)
        {
            
        }
        else if (data._alive == false && data._dead ==  false)
        {
            data._dead = true;
            _animator.SetTrigger("isDead");
        }
       
    }
}
