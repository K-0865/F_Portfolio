using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public enum Face_Direction
    {
        LEFT,
        RIGHT
    }
    // Start is called before the first frame update
    public bool _found_enemy = false;
    public Face_Direction _faceDirection = Face_Direction.LEFT;
    void Start()
    {
        if (this.gameObject.tag == "Player")
        {
            _faceDirection = Face_Direction.LEFT;
        }else if(this.gameObject.tag == "enemy")
        {
            _faceDirection = Face_Direction.RIGHT;
        }
        
    }
    private void C_Walk()
    {
        // if Enemy not in area this object walk leaf to right to find enemy
        // it's mean if not have enemy in stage object will walk unit far of right
        if (!_found_enemy)
        {
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
