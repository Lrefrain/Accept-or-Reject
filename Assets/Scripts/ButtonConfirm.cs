using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConfirm : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.L)) {
            ConfirmClick();
        }
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
}
