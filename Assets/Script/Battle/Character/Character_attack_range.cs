using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Character_attack_range : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D _box_range;

    //private CharacterData _characterData;
    [SerializeField] private float attack_range;
    // private Character_Movement _c_move;

    void Start()
    {
        this.gameObject.tag = "attack";
        _box_range = this.gameObject.GetComponent<BoxCollider2D>();
        attack_range = this.gameObject.GetComponentInParent<CharacterData>().CharacterStatus.AttackRange;
        // _c_move = this.gameObject.GetComponentInParent<Character_Movement>();



        if (attack_range == 100f)
        {
            float _box_range_size_x = attack_range / 100f;
            float offset_x = _box_range_size_x / 4f;
            _box_range.offset = new UnityEngine.Vector2(offset_x, 0);
            _box_range.size = new UnityEngine.Vector2(_box_range_size_x, 1);
        }
        else if (attack_range == 2000f)
        {
            float _box_range_size_x = 10f;
            float offset_x = 5f;
            _box_range.offset = new UnityEngine.Vector2(offset_x, 0);
            _box_range.size = new UnityEngine.Vector2(_box_range_size_x, 1);
        }


    }

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
