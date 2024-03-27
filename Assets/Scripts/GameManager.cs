using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float CD = 10.0f, lastTime;
    private Tools tools;
    public TextMeshProUGUI timeBar, toolBar;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        tools = gameObject.GetComponent<Tools>();
    }

    // Update is called once per frame
    void Update()
    {
        ChoiceTimer();
        UpdateTimeBar();
        GameQuit();
    }
    private void GameQuit()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
    }
    private void UpdateTimeBar()
    {
        timeBar.text = string.Format("Time:{0:F2}s", Time.time);
    }
    private void ChoiceTimer()
    {
        float dt = CD - (Time.time - lastTime);
        if (dt < 0) {
            lastTime = Time.time;
            // tools.StartChoice();
        }
        else {
            toolBar.text = string.Format("Tool:{0:F0}s", dt);
        }
    }
}
