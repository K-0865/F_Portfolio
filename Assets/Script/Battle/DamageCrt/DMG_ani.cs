using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//ダメージアニメーション
public class DMG_ani : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed;

    private void Start()
    {
        this.tag = transform.parent.tag;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 642988f, 0f);

    }

    //ダメージエフェクトの色変更と上に登っていく処理
    void Update()
    {
        if (!GameObject.Find("BattleManager").GetComponent<BattleManager>().isPause)
        {


            speed = 1f * Time.deltaTime;

            // gameObject.transform.position += Vector3.MoveTowards(now, target,speed);
            if (this.tag == "enemy")
            {
                this.gameObject.transform.position += new Vector3(speed, speed);

            }
            else
            {
                this.gameObject.transform.position += new Vector3(0f, speed);
                this.gameObject.transform.position -= new Vector3(speed, 0f);

            }

            gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.02f);
            //Debug.Log(color);
        }
    }
}
