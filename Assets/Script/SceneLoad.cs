using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource _audioSource;
    
    void Start () {
        //Componentを取得
        _audioSource = GetComponent<AudioSource>();
    }
    
    //inspectorから取得したsceneに移動する
    [SerializeField] private SceneObject Scene;
    public void OnClickLoadScene()
    {
        StartCoroutine(SceneDelay(2));
    }

    public void BattleStageLoad(int mapid)
    {
        GManager.instance.mapid = mapid;
        SceneManager.LoadScene(Scene);
        _audioSource.PlayOneShot(sound1);
    }
    
    IEnumerator SceneDelay (float sec)
    {        
        _audioSource.PlayOneShot(sound1);
        yield return new WaitForSeconds(sec);
        
        SceneManager.LoadScene(Scene);
        Debug.Log("SceneLoad");
    }
}
