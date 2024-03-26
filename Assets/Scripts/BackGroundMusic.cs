using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    private AudioSource bgm;

    // 在脚本启用时调用
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        PlayBackgroundMusic();
    }
    void Update()
    {
        PlayBackgroundMusic();
    }
    void PlayBackgroundMusic()
    {
        if (!bgm.isPlaying){
            bgm.Play();
        }
    }
}
