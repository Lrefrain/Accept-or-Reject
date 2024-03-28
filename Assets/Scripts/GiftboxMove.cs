using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftboxMove : MonoBehaviour
{
    // public GameObject annoyedAmon, happyAmon;
    public bool boxUp = false;
    private float timer, boxAppearPeriod = 7f;
    private int boxState = 0;
    private float boxbeginY, boxendY, boxSpeed = 200f;
    private UseTools useTools;
    private Tools tools;
    private CurtainMove curtainMove;
    public Text toolBar;
    private CameraSupport cs;
    // public AudioClip boxClip;
    // private AudioSource audioSource;
    // public AudioSource bgm;
    void Start()
    {
        cs = Camera.main.GetComponent<CameraSupport>();
        GetBounds();
        ResetBox();
        useTools = Camera.main.GetComponent<UseTools>();
        tools = Camera.main.GetComponent<Tools>();
        curtainMove = GameObject.Find("Curtain").GetComponent<CurtainMove>();
        // audioSource = GetComponent<AudioSource>();
    }
    private void GetBounds()
    {
        float ly, sy;
        // lx = cs.GetWorldBound().min.x;
        ly = cs.GetWorldBound().min.y;
        // rx = cs.GetWorldBound().max.x;
        // ry = cs.GetWorldBound().max.y;
        // sx = cs.GetWorldBound().size.x;
        sy = cs.GetWorldBound().size.y;
        boxbeginY = ly + 1.3f * sy;
        boxendY = ly + 0.6f * sy;
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
                toolBar.text = string.Format("Tool:{0:F2}s", timer);
                // Debug.Log(timer);
                if (timer <= 0) {
                    boxState = 1;
                    timer = 0;
                }
                break;
            case 1: // box down
                useTools.StopAll();
                curtainMove.curtainDown = true;
                // BoxSound();
                BoxDown();
                break;
            case 2: // box waiting for player
                if (boxUp){
                    // bgm.UnPause();
                    BoxUp();
                }
                break;
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
        // bgm.Pause();
        Vector3 pos = transform.position;
        pos -= new Vector3(0f, boxSpeed * Time.smoothDeltaTime, 0f);
        if(transform.position.y <= boxendY){
            pos.y = boxendY;
            boxState = 2;
            tools.StartChoice();
        }
        transform.position = pos;
    }
    private void ResetBox()
    {
        boxState = 0;
        timer = boxAppearPeriod;
        // happyAmon.SetActive(false);
        // annoyedAmon.SetActive(false);
    }
    private void BoxSound()
    {
        // audioSource.clip = boxClip;
        // audioSource.PlayOneShot(boxClip);
    }
}
