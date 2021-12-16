using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

//キャラクターの攻撃範囲を設定
public class Character_attack_range : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D _box_range;
    //private CircleCollider2D _circle2d;
    //private CharacterData _characterData;
    [SerializeField] private float attack_range;
    // private Character_Movement _c_move;
    // SKill Num Read >> Skill ID READ >> SKILL RANGE READ >> change  Range
    void Start()
    {
        this.gameObject.tag = "attack";
        //_circle2d = GetComponent<CircleCollider2D>();
        _box_range = this.gameObject.GetComponent<BoxCollider2D>();
        attack_range = this.gameObject.GetComponentInParent<CharacterData>().CharacterStatus.AttackRange;
        // _c_move = this.gameObject.GetComponentInParent<Character_Movement>();

        //CIRCLE COLLIDER
        // if (attack_range == 100f)
        // {
        //     _circle2d.offset = new UnityEngine.Vector2(0.4f, 0f);
        //     _circle2d.radius = 1f;
        //
        //
        // }
        // else if (attack_range == 2000f)
        // {
        //     _circle2d.offset = new UnityEngine.Vector2(4.5f, 0f);
        //     _circle2d.radius = 5f; 
        // }
        if (attack_range == 100f)
        {
            _box_range.size = new UnityEngine.Vector2(1.5f, 8f);
            _box_range.offset = new UnityEngine.Vector2(_box_range.size.x/2, 0f);


        }
        else if (attack_range == 2000f)
        {
            _box_range.size = new UnityEngine.Vector2(10f, 8f);
            _box_range.offset = new UnityEngine.Vector2(_box_range.size.x/2, 0f); 
        }
       


    }

    //接敵判定
    private void OnTriggerEnter2D(Collider2D other)
    {
        string main_tag = transform.parent.parent.tag;

        // Debug.Log(other.tag);
        // Character_Present_Data other_data = other.GetComponent<Character_Present_Data>();
        // Debug.Log(other_data._alive);
        // if (other_data._alive == true)
        // {
        //     if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Player")
        //     {
        //         Debug.Log("Found Enemy >>");
        //         _c_move._found_enemy = true;
        //     }
        // }
        // else
        // {
        //     _c_move._found_enemy = false;
        //
        // }
        //
        //
        if ((other.gameObject.tag == "enemy" && main_tag == "Player") || (other.gameObject.tag == "Player" && main_tag == "enemy"))
        {
           // Debug.Log(other.tag);
            Character_Present_Data other_data = other.GetComponent<Character_Present_Data>();
            Character_Present_Data user_data =
                GetComponentInParent<Transform>().GetComponentInParent<Character_Present_Data>();
            //Debug.Log(other_data._alive);
            if (other_data._alive)
            {
                user_data._found_enemy = true;
                
                //other_data._found_enemy = true;
              //  Debug.Log("Found Enemy >>");
            }
            else
            {
                //user_data._found_enemy = false;
                other_data._found_enemy = false;
            }
        }


    }

    //接敵判定
    private void OnTriggerStay2D(Collider2D other)
    {
        string main_tag = transform.parent.parent.tag;

        if ((other.gameObject.tag == "enemy" && main_tag == "Player") || (other.gameObject.tag == "Player" && main_tag == "enemy"))
        {
            //Debug.Log(other.tag);
            Character_Present_Data other_data = other.GetComponent<Character_Present_Data>();
            Character_Present_Data user_data =
                GetComponentInParent<Transform>().GetComponentInParent<Character_Present_Data>();
           // Debug.Log(other_data._alive);
            if (other_data._alive)
            {
                user_data._found_enemy = true;
                
                //other_data._found_enemy = true;
                //Debug.Log("Found Enemy >>");
            }
            else
            {
                //user_data._found_enemy = false;
                other_data._found_enemy = false;
            }
        }    }

    //攻撃処理の終了
    private void OnTriggerExit2D(Collider2D other)
    {
//        Debug.Log("not Found Enemy >>");
        string main_tag = transform.parent.parent.tag;

        if (other.tag == "enemy" || other.tag == "Player")
        {
            Character_Present_Data user_data =
                GetComponentInParent<Transform>().GetComponentInParent<Character_Present_Data>();
            user_data._found_enemy = false;

        }

{
            
        }
        //_c_move._found_enemy = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
