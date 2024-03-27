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
        descriptions[6] = "Clear Screen!";
        descriptions[7] = "Add Shizuka! (DO NOT shoot her)";
        descriptions[8] = "Multi-Bullets!";
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
            case 6:
                ClearScreen();
                break;
            case 7:
                AddShizuka();
                break;
            case 8:
                MultiBullets();
                break;
        }

    }

    public void ShowTool(int id)
    {
        text.SetActive(true);
        textMP.text = descriptions[id];
    }
// Stop and Start all for tools choice.=================
    public void StopAll()
    {
        StopEnemy();
        // StopPlayer();
    } 
    public void StartAll()
    {
        // StopEnemy();
        
    }
    private void StopPlayer()
    {
        player.speed = 0;
        player.enableShoot = false;
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
    
// ClearScreen ==========================================

    public void ClearScreen()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
        foreach (GameObject gameObject in balls) {
            if (gameObject.GetComponent<Ball>().heroOrEnemy == 1) {
                Destroy(gameObject);
            }
        }
        foreach (GameObject gameObject in stars) {
            if (gameObject.GetComponent<Star>().heroOrEnemy == 1) {
                Destroy(gameObject);
            }
        }
    }
        
// AddShizuka ==========================================

    public GameObject ShizukaPrefab;

    public void AddShizuka()
    {
        GameObject Shizuka = Instantiate(ShizukaPrefab, transform.position, Quaternion.identity);
    }

// MultiBullets ==========================================

    public int bulletsNum = 1;

    public void MultiBullets()
    {
        bulletsNum = 3;
        StartCoroutine(ChangeBulletsNumAfterDelay(delaySeconds)); // 开始协程
    }
    
    void SetMultiBulletsForBegin()
    {
        bulletsNum = 1;
    }

    IEnumerator ChangeBulletsNumAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SetMultiBulletsForBegin();
    }
}
