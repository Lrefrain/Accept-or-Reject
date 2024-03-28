using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private AudioManager audioManager;
    private Tools tools;


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
}
