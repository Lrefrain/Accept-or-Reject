using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip clickClip, exploreClip, playerDead, enemyDead;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickSound()
    {
        audioSource.clip = clickClip;
        audioSource.PlayOneShot(clickClip);
    }
    public void ExploreSound()
    {
        audioSource.clip = exploreClip;
        audioSource.PlayOneShot(exploreClip);
    }
    public void PlayerDeadSound()
    {
        audioSource.clip = playerDead;
        audioSource.PlayOneShot(playerDead);
    }
    public void EnemyDeadSound()
    {
        audioSource.clip = enemyDead;
        audioSource.PlayOneShot(enemyDead);
    }
}
