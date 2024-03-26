using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UseTools : MonoBehaviour
{
    public GameObject text, enemy;
    // public GameObject ;
    private TextMeshProUGUI textMP;
    private string[] descriptions;
    private GameObject[] enemyBalls;
    // Start is called before the first frame update
    void Start()
    {
        SetForBegin();
        descriptions = new string[10];
        descriptions[0] = "The World!";
        descriptions[1] = "Weakness Bigger!";
        textMP = text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    // private bool tag = false;
    void Update()
    {
        // if (Time.time >= 2f && tag == false) {
        //     StopEnemy();
        //     tag = true;
        // }
    }
    public void GoWork(int id)
    {
        Debug.Log("work" + id);
        switch (id){
            case 0:
                StopEnemy();
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

    public float delaySeconds = 8f; // buff/debuff 延迟时间

    public float enemyBallSpeed = 300f;
    public float heroBallSpeed = 300f;
    public float enemyStarSpeed = 150f;
    public float heroStarSpeed = 150f;
    public float enemySpeed = 50f;

    void SetForBegin()
    {
        enemyBallSpeed = 300f;
        heroBallSpeed = 300f;
        enemyStarSpeed = 150f;
        heroStarSpeed = 150f;
        enemySpeed = 50f;
    }
    private void StopEnemy()
    {
        enemyBallSpeed = 0f;
        enemyStarSpeed = 0f;
        enemySpeed = 0f;
        StartCoroutine(ChangeValueAfterDelay()); // 开始协程
    }
    IEnumerator ChangeValueAfterDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        SetForBegin();
    }


    private void BigWeak()
    {
        
    }
}
