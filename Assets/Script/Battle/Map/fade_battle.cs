using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_battle : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer _sprite;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _sprite.color -= new Color(0f, 0f, 0f, 0.03f);
        if (_sprite.color.a < 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
