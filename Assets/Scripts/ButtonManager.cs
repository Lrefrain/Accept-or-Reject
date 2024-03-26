using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // public GameObject curtain;
    // public GameObject happyAmon;
    // public GameObject annoyedAmon;

    // public GiftboxMove giftboxMove;
    private Tools tools;


    void Start()
    {
        // happyAmon.SetActive(false);
        // annoyedAmon.SetActive(false);
        tools = gameObject.GetComponent<Tools>();
    }

    // Update is called once per frame
    void Update()
    {      
    }

    public void AcceptClick()
    {
        Debug.Log("AccpetClick");
        // curtain.GetComponent<CurtainMove>().isCurtainOpen = true;
        // happyAmon.SetActive(true);
        // ChooseBox();
        tools.ApplyTool("Accept");
    }

    public void RejectClick()
    {
        Debug.Log("RejectClick");
        // curtain.GetComponent<CurtainMove>().isCurtainOpen = false;
        // annoyedAmon.SetActive(true);
        // Invoke("ResetBox", 1f);
        tools.ApplyTool("Reject");
    }

    public void ConfirmClick()
    {
        Debug.Log("ConfirmClick");
        // giftboxMove.isConfirmed = true;
        tools.ApplyTool("Confirm");
    }

    //     public void ChooseBox()
    // {
    //     giftboxMove.isBoxChosen = true;
    // }

    // public void ResetBox()
    // {
    //     giftboxMove.isConfirmed = true;
    // }
}
