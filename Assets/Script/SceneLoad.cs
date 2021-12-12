using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    //inspectorから取得したsceneに移動する
    [SerializeField] private SceneObject Scene;
    public void OnClickLoadScene()
    {
        SceneManager.LoadScene(Scene);
    }
}
