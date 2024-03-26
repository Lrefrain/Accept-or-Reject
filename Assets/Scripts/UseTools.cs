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
        SetSpeedForBegin();
        SetBulletForBegin();
        descriptions = new string[10];
        descriptions[0] = "The World!";
        descriptions[1] = "Get Star Bullet!";
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
                AddStarBullet();
                break;
        }

    }
    public void ShowTool(int id)
    {
        text.SetActive(true);
        textMP.text = descriptions[id];
    }

    public float delaySeconds = 8f; // buff/debuff 延迟时间

// StopEnemy ==========================================
    public float enemyBallSpeed = 200f;
    public float heroBallSpeed = 300f;
    public float enemyStarSpeed = 60f;
    public float heroStarSpeed = 80f;
    public float enemySpeed = 50f;

    void SetSpeedForBegin()
    {
        enemyBallSpeed = 200f;
        heroBallSpeed = 300f;
        enemyStarSpeed = 60f;
        heroStarSpeed = 80f;
        enemySpeed = 50f;
    }

    private void StopEnemy()
    {
        enemyBallSpeed = 0f;
        enemyStarSpeed = 0f;
        enemySpeed = 0f;
        StartCoroutine(ChangeValueAfterDelay(delaySeconds)); // 开始协程
    }

    IEnumerator ChangeValueAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SetSpeedForBegin();
    }

// AddStarBullet ==========================================

    public bool heroHasStar = false;

    private void AddStarBullet()
    {
        heroHasStar = true;
        StartCoroutine(ChangeBulletAfterDelay(delaySeconds)); // 开始协程
    }
    
    void SetBulletForBegin()
    {
        heroHasStar = false;
    }

    IEnumerator ChangeBulletAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SetBulletForBegin();
    }
}
