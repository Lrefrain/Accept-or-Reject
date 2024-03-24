using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject curtain;
    public GameObject happyAmon;
    public GameObject annoyedAmon;  
    public GameObject giftbox;


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
        curtain.GetComponent<CurtainMove>().isCurtainOpen = true;
        happyAmon.SetActive(true);
        giftbox.GetComponent<GiftboxMove>().isBoxChosen = true;

        
    }

    public void RejectClick()
    {
        Debug.Log("RejectClick");
        curtain.GetComponent<CurtainMove>().isCurtainOpen = false;
        annoyedAmon.SetActive(true);
        giftbox.GetComponent<GiftboxMove>().isBoxChosen = true;

    }


}
