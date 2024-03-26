using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 300.0f;
    public int heroOrEnemy = 0; // hero: 0, enemy: 1
    private Vector3 moveDirection, firstDirection;
    private UseTools useTools;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        firstDirection = (player.transform.position - transform.position).normalized;
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
            moveDirection = new Vector3(1f, 0, 0);
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
        Debug.Log("IN");
        
        if (heroOrEnemy == 1 && other.gameObject.CompareTag("Hero")){
            other.gameObject.GetComponent<Player>().HP --;
            other.gameObject.GetComponent<Player>().HP = Mathf.Max(0, other.gameObject.GetComponent<Player>().HP);
            Destroy(gameObject);
        } 
        
        if (heroOrEnemy == 0 && other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<Enemy>().HP --;
            other.gameObject.GetComponent<Enemy>().HP = Mathf.Max(0, other.gameObject.GetComponent<Enemy>().HP);
            Debug.Log(other.gameObject.GetComponent<Enemy>().HP);
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
