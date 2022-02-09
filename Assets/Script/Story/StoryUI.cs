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
    public bool AutoForward_2 = false;
    [SerializeField]private float textSpeed = 0.1f;
    [SerializeField]private TextWriter textwriter;
    public bool isClick = false;
    

    void Start(){}
    void Update(){
        if(AutoForward && AutoForward_2){
            if (!playing)
            {
                StartCoroutine("WaitTime",2f);
                AutoForward_2 = false;
            }
        }
    }
    IEnumerator WaitTime (float sec){
        yield return new WaitForSeconds(sec);
        if(AutoForward){
            isClick = true;
            AutoForward_2 = true;
        }
}
        public void OnClickSkip()
    {
        if(!playing){
            isClick = true;
        }
    }
    
    // クリックで次のページを表示させるための関数
    public bool isClicked()
    {
        return isClick;
    }

    public bool isAuto()
    {
        //AutoForward = true;
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
