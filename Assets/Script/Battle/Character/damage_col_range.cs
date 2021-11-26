using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class damage_col_range : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float attack;

    private void Start()
    {
        attack = GetComponentInParent<character_rangeType>().attack;
    }

    private void Update()
    {
        if (!GameObject.Find("BattleManager").GetComponent<BattleManager>().isPause)
        {
            float speed = 10f * Time.deltaTime;
            if (GetComponentInParent<Character_Movement>()._faceDirection == Character_Movement.Face_Direction.LEFT)
            {
                this.gameObject.transform.position += new Vector3(speed, 0f, 0f);

            }
            else
            {
                this.gameObject.transform.position -= new Vector3(speed, 0f, 0f);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string main_tag = transform.parent.parent.tag;
        // if (data_move.isAttack)
        // {
        //     Debug.Log("IN");
        if (!GameObject.Find("BattleManager").GetComponent<BattleManager>().isPause)
        {

            if ((other.gameObject.tag == "enemy" && main_tag == "Player") ||
                (other.gameObject.tag == "Player" && main_tag == "enemy"))
            {
                if (other.gameObject.GetComponent<Character_Present_Data>()._alive == true)
                {
                    other.gameObject.GetComponent<Character_Present_Data>().getDamage(attack);
                    Destroy(this.gameObject);
                }
                // else
                // {
                //     Debug.Log("Out_Damge");
                //     _c_move._found_enemy = false;
                //
                // }
            }
        }
    }
}
