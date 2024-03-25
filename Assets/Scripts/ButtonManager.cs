using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject curtain;
    public GameObject happyAmon;

    public GameObject annoyedAmon;

    public Tools tools;


    void Start()
    {
        happyAmon.SetActive(false);
        annoyedAmon.SetActive(false);
        tools = gameObject.GetComponent<Tools>();
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
        tools.ApplyTool("Accept");
    }

    public void RejectClick()
    {
        Debug.Log("RejectClick");
        curtain.GetComponent<CurtainMove>().isCurtainOpen = false;
        annoyedAmon.SetActive(true);
        tools.ApplyTool("Reject");
    }

    public void ConfirmClick()
    {
        Debug.Log("ConfirmClick");
        tools.ApplyTool("Confirm");
    }
}
