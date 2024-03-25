using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public CurtainMove curtainMove;
    public GameObject happyAmon;
    public GameObject annoyedAmon;  
    public GiftboxMove giftboxMove;

    void Start()
    {
        happyAmon.SetActive(false);
        annoyedAmon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }

    public void AcceptClick()
    {
        Debug.Log("AcceptClick");
        curtainMove.isCurtainOpen = true;
        happyAmon.SetActive(true);
        ResetBox();   
    }

    public void RejectClick()
    {
        Debug.Log("RejectClick");
        curtainMove.isCurtainOpen = false;
        annoyedAmon.SetActive(true);
        Invoke("ResetBox", 1f);
    }

    public void ResetBox()
    {
        giftboxMove.isBoxChosen = true;
    }


}
