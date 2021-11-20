using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DMG_ani : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 target;
    private Vector3 now;
    private float speed;
    void Start()
    {
        target = new Vector3(this.gameObject.transform.position.x, gameObject.transform.position.y + 100f,0);
        now = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0);
        //Destroy(this,1f);
    }

    // Update is called once per frame
    void Update()
    {
        speed = 1f * Time.deltaTime;
        // gameObject.transform.position += Vector3.MoveTowards(now, target,speed);
        gameObject.transform.position += new Vector3(0, speed);
    }
}
