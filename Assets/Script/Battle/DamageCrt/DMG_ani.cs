using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DMG_ani : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed;

    private void Start()
    {
        this.tag = transform.parent.tag;
    }

    // Update is called once per frame
    void Update()
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
        
    }
}
