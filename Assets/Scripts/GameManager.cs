using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float CD = 7.0f, lastTime;
    private Tools tools;
    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        tools = GameObject.Find("ButtonManager").GetComponent<Tools>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTime > CD){
            lastTime = Time.time;
            tools.StartChoice();
        }
    }
}
