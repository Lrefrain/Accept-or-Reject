using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UseTools : MonoBehaviour
{
    public GameObject text;
    // public GameObject ;
    private TextMeshProUGUI textMP;
    private string[] descriptions;
    // Start is called before the first frame update
    void Start()
    {
        descriptions = new string[10];
        descriptions[0] = "Weakness Smaller!";
        descriptions[1] = "Weakness Bigger!";
        textMP = text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoWork(int id)
    {
        Debug.Log("work" + id);
        switch (id){
            case 0:
                SmallWeak();
                break;
            case 1:
                BigWeak();
                break;
        }

    }
    public void ShowTool(int id)
    {
        text.SetActive(true);
        textMP.text = descriptions[id];
    }
    private void SmallWeak()
    {
        
    }
    private void BigWeak()
    {
        
    }
}
