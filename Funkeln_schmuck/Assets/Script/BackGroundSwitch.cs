using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSwitch : MonoBehaviour
{
    [SerializeField] GameObject BackGroundImage1;
    [SerializeField] GameObject BackGroundImage2;
    [SerializeField] GameObject BackGroundImage3;
    // Start is called before the first frame update
    public void OnclickLeft1()
    {
        if (BackGroundImage1.activeSelf)
        {
            BackGroundImage2.SetActive(true);
            BackGroundImage1.SetActive(false);
            Debug.Log("a");
        }
    }

    public void OnclickLeft2()
    {
        if (BackGroundImage2.activeSelf)
        {
            BackGroundImage3.SetActive(true);
            BackGroundImage2.SetActive(false);
            Debug.Log("b");
        }
    }

    public void OnclickLeft3()
    {
        if (BackGroundImage3.activeSelf)
        {
            BackGroundImage1.SetActive(true);
            BackGroundImage3.SetActive(false);
            Debug.Log("c");
        }
    }
    public void OnclickRight1()
    {
        if (BackGroundImage1.activeSelf)
        {
            BackGroundImage3.SetActive(true);
            BackGroundImage1.SetActive(false);
            Debug.Log("d");
        }
    }
    public void OnclickRight2()
    {
        if (BackGroundImage2.activeSelf)
        {
            BackGroundImage1.SetActive(true);
            BackGroundImage2.SetActive(false);
            Debug.Log("f");
        }
    }
    public void OnclickRight3()
    {
        if (BackGroundImage3.activeSelf)
        {
            BackGroundImage2.SetActive(true);
            BackGroundImage3.SetActive(false);
            Debug.Log("e");
        }
    }

}
