using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public GameObject acceptButton, rejectButton, confirmButton, chooseAnim, text, curtain;
    // public GameObject happyAmon, annoyedAmon;
    private TextMeshProUGUI textMP;
    private int id;
    private UseTools useTools;

    // Start is called before the first frame update
    void Start()
    {
        DisableAll();
        textMP = text.GetComponent<TextMeshProUGUI>();
        useTools = Camera.main.GetComponent<UseTools>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartChoice()
    {
        Time.timeScale = 0;
        acceptButton.SetActive(true);
        rejectButton.SetActive(true);
        chooseAnim.SetActive(true);
        curtain.SetActive(true);
        id = Random.Range(8, 9);
    }
    private void DisableAll()
    {
        acceptButton.SetActive(false);
        rejectButton.SetActive(false);
        confirmButton.SetActive(false);
        curtain.SetActive(false);
        chooseAnim.SetActive(false);
        text.SetActive(false);
    }
    public void ApplyTool(string choice)
    {
        if (choice == "Accept") {
            useTools.ShowTool(id);
            acceptButton.SetActive(false);
            rejectButton.SetActive(false);
            curtain.SetActive(false);
            confirmButton.SetActive(true);
            return;
        }
        else if (choice == "Reject") {

        }
        else if (choice == "Confirm") {
            useTools.GoWork(id);
        }
        ReturnGame();
    }
    private void ReturnGame()
    {
        Time.timeScale = 1;
        DisableAll();
    }
}
