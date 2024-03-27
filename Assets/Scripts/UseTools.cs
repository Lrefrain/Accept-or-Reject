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
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        SetSpeedForBegin();
        SetBulletForBegin();
        SetShootCDForBegin();
        descriptions = new string[10];
        descriptions[0] = "The World!";
        descriptions[1] = "Get Star Bullet!";
        descriptions[2] = "Get Lower Shoot CD!";
        descriptions[3] = "Get Higher Shoot CD!";
        descriptions[4] = "Increase HP by 1!";
        descriptions[5] = "Dcresase HP by 1! (if your HP > 1)";
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
            case 2:
                LowerShootCD();
                break;
            case 3:
                HigherShootCD();
                break;
            case 4:
                IncreaseHP();
                break;
            case 5:
                DecreaseHP();
                break;
        }

    }

    public void ShowTool(int id)
    {
        text.SetActive(true);
        textMP.text = descriptions[id];
    }
    public void StopAll()
    {
        StopEnemy();
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

// Lower/HigherShootCD ==========================================

    public float shootCDRate = 1f;

    private void LowerShootCD()
    {
        shootCDRate = 0.5f;
        StartCoroutine(ChangeShootCDAfterDelay(delaySeconds)); // 开始协程
    }

    private void HigherShootCD()
    {
        shootCDRate = 2f;
        StartCoroutine(ChangeShootCDAfterDelay(delaySeconds)); // 开始协程
    }
    
    void SetShootCDForBegin()
    {
        shootCDRate = 1f;
    }

    IEnumerator ChangeShootCDAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SetShootCDForBegin();
    }
    
// Inc/DecHP ==========================================

    private void IncreaseHP()
    {
        ++ player.HP;
    }

    private void DecreaseHP()
    {
        if (player.HP > 1) {
            -- player.HP;
        }
    }
}
