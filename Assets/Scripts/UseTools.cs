using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseTools : MonoBehaviour
{
    public GameObject textObj, enemy;
    // public GameObject ;
    private Text text;
    private string[] descriptions;
    private GameObject[] enemyBalls;
    private Player player;
    public float delaySeconds; // buff/debuff 延迟时间
    public GameObject[] toolsPrefab;
    public GameObject[] toolsInstant;
    // Start is called before the first frame update
    void Start()
    {
        delaySeconds = 10f;
        player = GameObject.Find("Player").GetComponent<Player>();
        SetSpeedForBegin();
        SetBulletForBegin();
        SetShootCDForBegin();
        descriptions = new string[10];
        toolsPrefab = new GameObject[10];
        toolsInstant = new GameObject[10];
        descriptions[0] = "The World!";
        descriptions[1] = "Get Star Bullet!";
        descriptions[2] = "Get Lower Shoot CD!";
        descriptions[3] = "Get Higher Shoot CD!";
        descriptions[4] = "Increase HP by 1!";
        descriptions[5] = "Decrease HP by 1!\n(if your HP > 1)";
        descriptions[6] = "Clear Screen!";
        descriptions[7] = "Add Shizuka!\n(DO NOT touch her)";
        descriptions[8] = "Multi-Bullets!";

        for (int i = 0; i < 9; ++i) {
            toolsPrefab[i] = Resources.Load<GameObject>("Tools/Tool" + i.ToString());
            toolsInstant[i] = Instantiate(toolsPrefab[i], transform.position, Quaternion.identity);
            Vector3 p = toolsInstant[i].transform.localPosition;
            p.z = -5f;
            toolsInstant[i].transform.localPosition = p;
            toolsInstant[i].SetActive(false);
        }
        
        text = textObj.GetComponent<Text>();
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
        textObj.SetActive(true);
        text.text = descriptions[id];
        toolsInstant[id].SetActive(true);
    }

    public float enemyBallSpeed = 200f;
    public float heroBallSpeed = 300f;
    public float enemyStarSpeed = 60f;
    public float heroStarSpeed = 80f;
    public float enemySpeed = 50f;
    public bool enemyEnableShoot = true;
    public void StopAll()
    {
        enemyBallSpeed = 0f;
        enemyStarSpeed = 0f;
        enemySpeed = 0f;
        enemyEnableShoot = false;

        player.speed = 0f;
        player.enableShoot = false;
        // heroStarSpeed = 0f;
        // heroBallSpeed = 0f;
    }
    public void BeginAllFor0()
    {
        enemyEnableShoot = true;
        player.speed = 120f;
        player.enableShoot = true;
    }
    public void BeginAll()
    {
        // enemySpeed = 50f;
        SetSpeedForBegin();
        enemyEnableShoot = true;
        player.speed = 120f;
        player.enableShoot = true;
    }
    void SetSpeedForBegin()
    {
        enemyBallSpeed = 200f;
        heroBallSpeed = 300f;
        enemyStarSpeed = 60f;
        heroStarSpeed = 80f;
        enemySpeed = 50f;
    }
// StopEnemy ==========================================
    private void StopEnemy()
    {
        enemyBallSpeed = 0f;
        enemyStarSpeed = 0f;
        enemySpeed = 0f;
        StartCoroutine(ChangeValueAfterDelay(5f)); // 开始协程
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
        bulletsNum = 5;
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
