using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAccept : MonoBehaviour
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
            AcceptClick();
        }
    }

    public void AcceptClick()
    {
        audioManager.ClickSound();
        tools.ApplyTool("Accept");
    }
}
