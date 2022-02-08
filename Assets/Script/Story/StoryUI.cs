using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryUI : MonoBehaviour
{
    // nameText:喋っている人の名前
    // talkText:喋っている内容やナレーション
    [SerializeField]private Text nameText;
    [SerializeField]private Text talkText;

    public bool playing = false;
    public bool AutoForward = false;
    [SerializeField]private float textSpeed = 0.1f;

    public bool isClick = false;

    void Start(){}

    public void OnClickSkip()
    {
        isClick = true;
    }
    
    // クリックで次のページを表示させるための関数
    public bool isClicked()
    {
        return isClick;
    }

    public bool isAuto()
    {
        return true;
    }
    // テキストを生成する関数
    public void DrawText ( string name, string text)
    {
        nameText.text = name ;
        StartCoroutine("CoDrawText", text);
    }

    // テキストがヌルヌル出てくるためのコルーチン
    IEnumerator CoDrawText ( string text )
    {
        playing = true;
        float time = 0;
        while ( true )
        {
            yield return 0;
            time += Time.deltaTime;

            // クリックされると一気に表示
            if ( isClicked() ) break;

            int len = Mathf.FloorToInt ( time / textSpeed);
            if (len > text.Length) break;
            talkText.text = text.Substring(0, len);
        }
        talkText.text = text;
        yield return 0;
        playing = false;
    }
}
