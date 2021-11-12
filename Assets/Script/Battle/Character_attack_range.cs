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
    private Character_Movement _c_move;
    
    void Start()
    {
        this.gameObject.tag = gameObject.transform.parent.tag;
        _box_range = this.gameObject.GetComponent<BoxCollider2D>();
        attack_range = this.gameObject.GetComponentInParent<CharacterData>().CharacterStatus.AttackRange;
        _c_move = this.gameObject.GetComponentInParent<Character_Movement>();
        float _box_range_size_x = attack_range / 100f;
        float offset_x = _box_range_size_x / 2f;


        _box_range.offset = new UnityEngine.Vector2(offset_x, 0);
        _box_range.size = new UnityEngine.Vector2(_box_range_size_x, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "enemy")
            {
                Debug.Log("Found Enemy >>");
                _c_move._found_enemy = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("not Found Enemy >>");

        _c_move._found_enemy = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
