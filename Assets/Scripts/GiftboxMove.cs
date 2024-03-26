using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftboxMove : MonoBehaviour
{
    public GameObject annoyedAmon, happyAmon, curtain;
    private float timer;
    private bool isBoxChosen = false;

    private bool isConfirmed = false;

    private int boxState = 0;
    private float boxbeginY = 220f, boxendY = 0f;
    private float boxSpeed = 200f;

    private float boxAppearPeriod = 3f;
    private Vector3 curtainPos;

    void Start()
    {
        timer = boxAppearPeriod;
        curtainPos = curtain.transform.position;
        happyAmon.SetActive(false);
        annoyedAmon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (boxState)
        {
            case 0: // box prepare...
                timer -= Time.smoothDeltaTime;
                // Debug.Log(timer);
                if (timer <= 0) {
                    boxState = 1;
                }
                break;
            case 1: // box down
                BoxAppear();
                // Debug.Log("BoxAppear");
                if(transform.position.y < boxendY){
                    boxState = 2;
                }
                break;
            case 2: // box waiting for player
                if(isConfirmed) {
                    boxState = 4;
                }
                if(isBoxChosen) {
                    boxState = 3;
                }
                
                break;
            case 3: // box comfirm
                if(isConfirmed) {
                    boxState = 4;
                }
                break;
            case 4: // box up
                BoxUpward();
                if(transform.position.y > boxbeginY){
                    timer = boxAppearPeriod;
                    happyAmon.SetActive(false);
                    annoyedAmon.SetActive(false);
                    transform.GetChild(2).position = curtainPos;
                    boxState = 0;
                }
                break;
        }     
    }
    public void BoxAppear()
    {
        {
            transform.position = transform.position + new Vector3(0f, -boxSpeed * Time.smoothDeltaTime, 0f);
        }
    }

    public void BoxUpward()
    {
        if(transform.GetChild(2).GetComponent<CurtainMove>().isCurtainOpen == false)
        {
            transform.position = transform.position + new Vector3(0f, boxSpeed * Time.smoothDeltaTime, 0f);
            isBoxChosen = false;
            isConfirmed = false;
        }

    }

}
