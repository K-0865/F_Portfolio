using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meinMenu : MonoBehaviour
{
    [SerializeField] GameObject subMenu1;
    [SerializeField] GameObject subMenu2;
    [SerializeField] GameObject subMenu3;
    [SerializeField] GameObject subMenu4;
    private bool menuOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCklickMenu()
    {
        if (menuOpen)
        {
            subMenu1.SetActive(true);
            subMenu2.SetActive(true);
            subMenu3.SetActive(true);
            subMenu4.SetActive(true);
            menuOpen = false;
        }
        else
        {
            subMenu1.SetActive(false);
            subMenu2.SetActive(false);
            subMenu3.SetActive(false);
            subMenu4.SetActive(false);
            menuOpen = true;
        }
    }
}
