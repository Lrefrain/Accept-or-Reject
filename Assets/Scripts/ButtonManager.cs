using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject curtain;
    public GameObject happyAmon;

    public GameObject annoyedAmon;


    void Start()
    {
        happyAmon.SetActive(false);
        annoyedAmon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcceptClick()
    {
        Debug.Log("AcceptClick");
        curtain.GetComponent<CurtainMove>().isCurtainOpen = true;
        happyAmon.SetActive(true);
    }

    public void RejectClick()
    {
        Debug.Log("RejectClick");
        curtain.GetComponent<CurtainMove>().isCurtainOpen = false;
        annoyedAmon.SetActive(true);
    }
}
