using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private PlayerExp _ExpTable;
    [SerializeField] private SceneLoad Loader;
    
    [SerializeField] private GameObject Player_Level;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Exp;

    private Text _Level;
    private Text _Coin;
    private Text _Exp;

    private int _LevelNow;
    private int _LevelNext;
    private int _ExpNow;
    private int _ExpPlus = 5;
    private int _ExpNext;

    private bool LevelUp;
    private void Start()
    {
        _Level = Player_Level.GetComponent<Text>();
        _Coin = Coin.GetComponent<Text>();
        _Exp = Exp.GetComponent<Text>();

        LevelUp = false;

        _LevelNow = GManager.instance.player.Level;
        Debug.Log(_ExpTable.ExpTable.Count + "con");
        
        for (int i = 0; i < _ExpTable.ExpTable.Count; i++)
        {
            if (_ExpTable.ExpTable[i].PlayerLevel == _LevelNow)
            {
                _ExpNow = _ExpTable.ExpTable[i].Exp;
                _LevelNext = _ExpTable.ExpTable[i + 1].PlayerLevel;
                _ExpNext = _ExpTable.ExpTable[i + 1].Exp;
            }
        }
        
        Debug.Log(_LevelNext + "LevelNext");
        Debug.Log(_ExpNow + "ExpNow");
        Debug.Log(_ExpNext + "ExpNext");
        
        ResultDisp();
    }

    
    private void ResultDisp()
    {
        _ExpNow = _ExpTable.ExpTable[_LevelNow].Exp;
        _ExpNext = _ExpTable.ExpTable[_LevelNow+1].PlayerLevel;
        _Level.text = "Level:" + _LevelNow;
        _Coin.text = "Coin:" + GManager.instance.player.Coin;
        for (int i = 0; i < _ExpPlus; i++)
        {
            StartCoroutine("CalcExp", 0.1);
        }

        _Exp.text = "Exp:" + _ExpNow + " + " + _ExpPlus;  
        LevelCalc();
        
        if (LevelUp)
        {
            _Level.text = "Level:" + _LevelNow + "+" + _LevelNext;
        }
        else
        {
            _Level.text = "Level:" + _LevelNow;
        }

        StartCoroutine("HomeBack", 10);
    }
    
    IEnumerator CalcExp(float sec)
    {
        yield return new WaitForSeconds(sec);
        _ExpNow++;
        _ExpPlus--;
    }

    IEnumerator HomeBack(float sec)
    {
        yield return new WaitForSeconds(sec);
        Loader.OnClickLoadScene();
    }
    
    private void LevelCalc()
    {
        while (_ExpNow >= _ExpNext)
        {
            _LevelNow++;
            LevelUp = true;
            _ExpNow = _ExpTable.ExpTable[_LevelNow].Exp;
            _ExpNext = _ExpTable.ExpTable[_LevelNow+1].PlayerLevel;
        }
        // while (_ExpNow <= _ExpNext && _ExpPlus != 0)
        // {
        //     _LevelNow++;
        //     LevelUp = true;
        // }
    }
}
