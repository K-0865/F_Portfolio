using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private AudioClip sound;

    [SerializeField] private float Sec;
    AudioSource _audioSource;
    
    void Start () {
        //Componentを取得
        _audioSource = GetComponent<AudioSource>();
    }
    
    //inspectorから取得したsceneに移動する
    [SerializeField] private SceneObject Scene;
    public void OnClickLoadScene()
    {
        StartCoroutine(SceneDelay());
    }

    public void BattleStageLoad(int mapid)
    {
        StartCoroutine(BattleDelay(mapid));
    }

    IEnumerator BattleDelay(int mapid)
    {
        _audioSource.PlayOneShot(sound);
        yield return new WaitForSeconds(Sec);
        
        GameManager.instance.mapid = mapid;
        SceneManager.LoadScene(Scene);
    }
    
    IEnumerator SceneDelay ()
    {        
        _audioSource.PlayOneShot(sound);
        yield return new WaitForSeconds(Sec);
        
        SceneManager.LoadScene(Scene);
        Debug.Log("SceneLoad");
    }
}
