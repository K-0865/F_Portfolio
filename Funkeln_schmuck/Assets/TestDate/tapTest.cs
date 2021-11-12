using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tapTest : MonoBehaviour
{
    private float tapcount1 = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tapconGet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("クリックした瞬間");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("離した瞬間");
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("クリックしっぱなし");
        }

    }

    public void OnTapTest()
    {
        tapcount1++;
        SceneManager.LoadScene("ui-Test");
        Debug.Log("1");
    }


}
