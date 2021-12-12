using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//クエストメニューの入れ替え（現在未設定,仕様変更予定）
//出来る限りSetActiveを使用しない方向
public class QuestMenu : MonoBehaviour
{
    [SerializeField] GameObject Questmenu1;
    [SerializeField] GameObject Questmenu2;
    [SerializeField] GameObject Questmenu3;

    public void OnClickQuestList1()
    {
        Questmenu2.SetActive(true);
        Questmenu1.SetActive(false);
    }
    public void OnClickQuestList2R()
    {
        Questmenu3.SetActive(true);
        Questmenu2.SetActive(false);
    }
    public void OnClickQuestList2L()
    {
        Questmenu1.SetActive(true);
        Questmenu2.SetActive(false);
    }
    public void OnClickQuestList3()
    {
        Questmenu2.SetActive(true);
        Questmenu3.SetActive(false);
    }
}
