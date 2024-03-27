using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftboxMove : MonoBehaviour
{
    public GameObject annoyedAmon, happyAmon;
    public bool boxUp = false;
    private float timer, boxAppearPeriod = 3f;
    private int boxState = 0;
    private float boxbeginY = 200f, boxendY = 15f, boxSpeed = 200f;
    private UseTools useTools;
    private Tools tools;
    void Start()
    {
        ResetBox();
        useTools = Camera.main.GetComponent<UseTools>();
        tools = Camera.main.GetComponent<Tools>();
    }
    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }
    private void MoveControl()
    {
        switch (boxState) {
            case 0: // box prepare...
                timer -= Time.smoothDeltaTime;
                // Debug.Log(timer);
                if (timer <= 0) {
                    boxState = 1;
                }
                break;
            case 1: // box down
                useTools.StopAll();
                BoxDown();
                break;
            case 2: // box waiting for player
                if (boxUp){
                    BoxUp();
                }
                break;
            // case 3: // box comfirm
            //     if(isConfirmed) {
            //         boxState = 4;
            //     }
            //     break;
            // case 4: // box up
            //     BoxUpward();
            //     if(transform.position.y > boxbeginY){
            //         timer = boxAppearPeriod;
            //         happyAmon.SetActive(false);
            //         annoyedAmon.SetActive(false);
            //         // curtain.transform.position = curtainPos;
            //         boxState = 0;
            //     }
            //     break;
        }    
    }
    private void BoxUp()
    {
        Vector3 pos = transform.position;
        pos += new Vector3(0f, boxSpeed * Time.smoothDeltaTime, 0f);
        if(transform.position.y >= boxbeginY) {
            pos.y = boxbeginY;
            boxUp = false;
            ResetBox();
        }
        transform.position = pos;
    }
    private void BoxDown()
    {
        Vector3 pos = transform.position;
        pos -= new Vector3(0f, boxSpeed * Time.smoothDeltaTime, 0f);
        if(transform.position.y <= boxendY){
            pos.y = boxendY;
            boxState = 2;
        }
        transform.position = pos;
        tools.StartChoice();
    }
    private void ResetBox()
    {
        boxState = 0;
        timer = boxAppearPeriod;
        happyAmon.SetActive(false);
        annoyedAmon.SetActive(false);
    }
}
