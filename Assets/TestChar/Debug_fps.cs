using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_fps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // public Text fpsText;
    public float deltaTime;
 
    void Update () {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        //fpsText.text = Mathf.Ceil (fps).ToString ();
        Debug.Log(Mathf.Ceil(fps).ToString());
    }
}
