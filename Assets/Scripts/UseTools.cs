using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseTools : MonoBehaviour
{
    public GameObject textObj;
    // public GameObject ;
    private Text text;
    private string[] descriptions;
    private GameObject[] enemyBalls;
    private Player player;
    private Enemy enemy;
    public float delaySeconds; // buff/debuff 延迟时间
    public GameObject[] toolsInstant;
    private CameraSupport cs;
    // Start is called before the first frame update
    void Start()
    {
        cs = Camera.main.GetComponent<CameraSupport>();
        delaySeconds = 10f;
        player = GameObject.Find("Player").GetComponent<Player>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        SetSpeedForBegin();
        SetBulletForBegin();
        SetShootCDForBegin();
        descriptions = new string[10];
        descriptions[0] = "The World!";
        descriptions[1] = "Get Star Bullet!";
        descriptions[2] = "Get Shorter Shoot CD!";
        descriptions[3] = "Get Longer Shoot CD!";
        descriptions[4] = "Increase Player HP by 1!";
        descriptions[5] = "Increase Enemy HP by 10-15!";
        descriptions[6] = "Clear Screen!";
        descriptions[7] = "Add Shizuka!\n(DO NOT touch her)";
        descriptions[8] = "Multi-Bullets!";
        descriptions[9] = "Random Door Takes You Anywhere!";

        for (int i = 0; i < 10; ++i) {
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
    private void GetBounds()
    {
        // lx = cs.GetWorldBound().min.x;
        // ly = cs.GetWorldBound().min.y;
        // rx = cs.GetWorldBound().max.x;
        // ry = cs.GetWorldBound().max.y;

        // sx = cs.GetWorldBound().size.x;
        // sy = cs.GetWorldBound().size.y;

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
            case 9:
                RandomDoor();
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
        shootCDRate = 0.01f;
        StartCoroutine(ChangeShootCDAfterDelay(5f)); // 开始协程
    }

    private void HigherShootCD()
    {
        shootCDRate = 4f;
        StartCoroutine(ChangeShootCDAfterDelay(5f)); // 开始协程
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
        int value = Random.Range(10, 15);
        enemy.HP = Mathf.Min(enemy.MaxHP, enemy.HP + value);
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

// RandomDoor ==========================================

    private float blinkTime = 1f;
    private int blinks = 5;

    public void RandomDoor()
    {
        BlinkPlayer(blinks, blinkTime);
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }
    
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks; i++)
        {
            player.RandomShift();
            yield return new WaitForSeconds(seconds);
        }
    }

}
