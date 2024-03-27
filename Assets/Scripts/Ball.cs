using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 300.0f;
    public int heroOrEnemy = 0; // hero: 0, enemy: 1
    public int oth;    // hero bullet dir index   0 mid, 1 low, 2 up
    private Vector3 moveDirection, firstDirection;
    private UseTools useTools;
    private Player player;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        firstDirection = (player.transform.position - transform.position).normalized;
        useTools = Camera.main.GetComponent<UseTools>();
        audioManager = Camera.main.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDir();
        GetSpeed();
        OutBounds();
        MoveControl();
    }

    void GetDir()
    {
        if (heroOrEnemy == 0) {
            if (oth == 0) {
                moveDirection = new Vector3(1f, 0, 0);
            }
            else if (oth == 1) {
                moveDirection = (new Vector3(1.732f, -1f, 0)).normalized;
            }
            else if (oth == 2) {
                moveDirection = (new Vector3(1.732f, 1f, 0)).normalized;
            }
        }
        else {
            moveDirection = firstDirection;
        }
    }

    void GetSpeed()
    {
        if (heroOrEnemy == 0) {
            speed = useTools.heroBallSpeed;
        }
        else {
            speed = useTools.enemyBallSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (heroOrEnemy == 1 && other.gameObject.CompareTag("Hero")){
            useTools.ClearScreen();
            audioManager.ExploreSound();
            other.gameObject.GetComponent<Player>().HP --;
            other.gameObject.GetComponent<Player>().HP = Mathf.Max(0, other.gameObject.GetComponent<Player>().HP);
            Destroy(gameObject);
        }

        if (heroOrEnemy == 0 && other.gameObject.CompareTag("Shizuka")) {
            useTools.ClearScreen();
            audioManager.ExploreSound();
            player.HP --;
            player.HP = Mathf.Max(0, player.HP);
            Destroy(gameObject);
        }

        if (heroOrEnemy == 0 && other.gameObject.CompareTag("Enemy")){
            audioManager.ExploreSound();
            other.gameObject.GetComponent<Enemy>().HP --;
            other.gameObject.GetComponent<Enemy>().HP = Mathf.Max(0, other.gameObject.GetComponent<Enemy>().HP);
            Destroy(gameObject);
        }
    }

    private void OutBounds()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            Destroy(gameObject);
    }

    private void MoveControl()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
