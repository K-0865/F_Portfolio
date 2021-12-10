using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_rangeType : MonoBehaviour
{
    private Character_Movement _c_move;
   
    // Start is called before the first frame update　
    [SerializeField] GameObject _data;
    private CharacterData data_char_sc;
    private Character_Movement data_move;
    public float attack;
    public bool _isAttack;
    [SerializeField] private GameObject bullet;
    void Start()
    {

        data_char_sc = _data.GetComponent<CharacterData>();
        _c_move = this.gameObject.GetComponentInParent<Character_Movement>();
        data_move = this.gameObject.GetComponentInParent<Character_Movement>();
        attack = data_char_sc.CharacterStatus.Attack;

        Debug.Log(data_char_sc);
    }

    public GameObject FindClosestEnemy(string tag_name)
    {
        GameObject[] gos;
        List<GameObject> list_obj = new List<GameObject>();
        gos = GameObject.FindGameObjectsWithTag(tag_name);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (var go in gos)
        {
            if (go.GetComponent<Character_Present_Data>()._alive)
            {
                list_obj.Add(go);
            }
        }
        Debug.Log(list_obj.Count);
        foreach (GameObject go in list_obj)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    public void Range_bullet()
    { 
       
        string me_tag = this.gameObject.transform.parent.tag;
        
        if (me_tag == "Player")
        {
            var find_enemy = FindClosestEnemy("enemy");
            GameObject obj = Instantiate(bullet);
            obj.transform.parent = this.transform;
            obj.transform.position = find_enemy.transform.position;
        }
        else
        {
            var find_enemy = FindClosestEnemy("Player");
            GameObject obj = Instantiate(bullet);
            obj.transform.parent = this.transform;
            obj.transform.position = find_enemy.transform.position;
        }
        
    }
    private void Update()
    {
        //Debug.Log(data_move.isAttack);
    }

    
    
    
}