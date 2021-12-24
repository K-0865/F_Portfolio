using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//characterの攻撃方法を判定、設定する
public class character_rangeType : MonoBehaviour
{
    private Character_Movement _c_move;
   
    // Start is called before the first frame update　
    [SerializeField] GameObject _data;
    private CharacterData data_char_sc;
    private Character_Movement data_move;
    public float attack;
    public float total_attack;
    public bool _isAttack;
    [SerializeField] private GameObject bullet;
    
    //初期化処理
    void Start()
    {

        data_char_sc = _data.GetComponent<CharacterData>();
        _c_move = this.gameObject.GetComponentInParent<Character_Movement>();
        data_move = this.gameObject.GetComponentInParent<Character_Movement>();
        attack = data_char_sc.CharacterStatus.Attack;
        
        //Debug.Log(data_char_sc);
    }

    //敵のオブジェクトを取得する
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
        //Debug.Log(list_obj.Count);
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
    
    //自分からの攻撃なのか敵からの攻撃なのかを判定する
    public void Range_bullet(float p_att)
    {
        total_attack = attack * (p_att / 100f);
        string me_tag = this.gameObject.transform.parent.tag;
        
        if (me_tag == "Player")
        {
            var find_enemy = FindClosestEnemy("enemy");
            if (find_enemy == null)
            {
                return;
            }
            GameObject obj = Instantiate(bullet);
            obj.transform.parent = this.transform;
            obj.transform.position = find_enemy.transform.position;
        }
        else if(me_tag == "enemy")
        {
            
            var find_enemy = FindClosestEnemy("Player");
            if (find_enemy == null)
            {
                return;
            }
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