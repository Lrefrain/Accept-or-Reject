using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAudio : MonoBehaviour
{
    public AudioClip enemyDead;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = enemyDead;
        audioSource.PlayOneShot(enemyDead);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
