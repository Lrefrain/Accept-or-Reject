using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private AudioManager audioManager;
    private Tools tools;
    private bool hasPause = false;

    void Start()
    {
        tools = gameObject.GetComponent<Tools>();
        audioManager = Camera.main.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AcceptClick()
    {
        audioManager.ClickSound();
        tools.ApplyTool("Accept");
    }

    public void RejectClick()
    {
        audioManager.ClickSound();
        tools.ApplyTool("Reject");
    }

    public void ConfirmClick()
    {
        audioManager.ClickSound();
        tools.ApplyTool("Confirm");
    }
    public void PauseClick()
    {
        audioManager.ClickSound();
        if (hasPause) Time.timeScale = 1;
        else Time.timeScale = 0;
        hasPause = !hasPause;
    }
    public void RestartClick()
    {
        audioManager.ClickSound();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
