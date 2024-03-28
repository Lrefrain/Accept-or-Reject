using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReject : MonoBehaviour
{
    private AudioManager audioManager;
    private Tools tools;

    void Start()
    {
        tools = Camera.main.GetComponent<Tools>();
        audioManager = Camera.main.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            RejectClick();
        }
    }

    public void RejectClick()
    {
        audioManager.ClickSound();
        tools.ApplyTool("Reject");
    }
}
