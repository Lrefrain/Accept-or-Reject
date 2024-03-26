using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed = 300.0f;
    public int heroOrEnemy = 0; // hero: 0, enemy: 1
    private Vector3 moveDirection;
    private UseTools useTools;
    private Player player;
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        useTools = Camera.main.GetComponent<UseTools>();
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
            moveDirection = enemy.transform.position - transform.position;
        }
        else {
            moveDirection = player.transform.position - transform.position;
        }
    }

    void GetSpeed()
    {
        if (heroOrEnemy == 0) {
            speed = useTools.heroStarSpeed;
        }
        else {
            speed = useTools.enemyStarSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Wall")){
            Destroy(gameObject);
        } 
        else if (other.gameObject.CompareTag("Weak")){
            Debug.Log("Hit the Weak.");
            other.gameObject.GetComponent<Weak>().hp--;
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
