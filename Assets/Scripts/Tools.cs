using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tools : MonoBehaviour
{
    // Start is called before the first frame update
    public float weakScale = 1f;
    public int idMax = 2;
    private Player player;
    public GameObject acceptButton, rejectButton, confirmButton, chooseAnim, text, BigSmallWeak;
    public TextMeshProUGUI textMP;
    private int id;

    public void ResetParameters()
    {
        weakScale = 1f;
    }

    void Start()
    {
        DisableButton();
        disAll();
        player = GameObject.Find("Player").GetComponent<Player>();
        textMP = text.GetComponent<TextMeshProUGUI>();
        // acceptButton = GameObject.Find("Canvas/ButtonAccept");
        // rejectButton = GameObject.Find("Canvas/ButtonReject");
        // chooseAnim = GameObject.Find("ChooseAnim");
    }

    void disAll()
    {
        for (int i = 0; i < idMax; ++i) {
            DisThing(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InsThing(int id) {
        if (id == 0 || id == 1) {
            BigSmallWeak.SetActive(true);
        }
        text.SetActive(true);
        confirmButton.SetActive(true);
        chooseAnim.SetActive(false);
    }

    void DisThing(int id) {
        if (id == 0 || id == 1) {
            BigSmallWeak.SetActive(false);
        }
        text.SetActive(false);
        confirmButton.SetActive(false);
    }

    void ActualChange(int id) 
    {
        if (id == 0){
            BigWeak();
        } else if(id == 1){
            SmallWeak();
        }
    }

    void UseThings(int id)
    {
        ACRJButton(false);
        if (id == 0){
            textMP.text = "Big Gun\nMakes weakness bigger.";
        } else if(id == 1){
            textMP.text = "Small Gun\nMakes weakness smaller.";
        }
        InsThing(id);
    }

    public void ApplyTool(string choice)
    {
        if (choice == "Accept") {
            UseThings(id);
            return ;
        }
        else if(choice == "Confirm") {
            DisThing(id);
            ActualChange(id);
        }
        ReturnGame();
    }

    private void ACRJButton(bool x) {
        acceptButton.SetActive(x);
        rejectButton.SetActive(x);
    }


    private void DisableButton()
    {
        acceptButton.SetActive(false);
        rejectButton.SetActive(false);
        chooseAnim.SetActive(false);
    }
    public void StartChoice()
    {
        Time.timeScale = 0;
        acceptButton.SetActive(true);
        rejectButton.SetActive(true);
        chooseAnim.SetActive(true);
        id = Random.Range(0, 2);
    }
    private void ReturnGame()
    {
        Time.timeScale = 1;
        DisableButton();
    }
    private void BigWeak()
    {
        weakScale *= 2;
    }
    private void SmallWeak()
    {
        weakScale /= 2;
    }
}
