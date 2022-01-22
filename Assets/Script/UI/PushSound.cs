using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSound : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource _audioSource;

    void Start () {
        //Componentを取得
        _audioSource = GetComponent<AudioSource>();
    }

    void Sound () {
        // 左
        if (Input.GetKey (KeyCode.LeftArrow)) {
            //音(sound1)を鳴らす
            _audioSource.PlayOneShot(sound1);
        }
    }
}
