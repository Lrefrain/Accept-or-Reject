using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed = 70f;
    public int heroOrEnemy = 0; // hero: 0, enemy: 1
    private Vector3 moveDirection;
    private UseTools useTools;
    private Player player;
    private Enemy enemy;
    private float delaySeconds = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        useTools = Camera.main.GetComponent<UseTools>();
        // Destroy this Star after delaySeconds.
        StartCoroutine(DestroyComponentAfterDelay(delaySeconds));
    }

    private IEnumerator DestroyComponentAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        Destroy(gameObject);
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
            if (Object.ReferenceEquals(enemy, null)) {
                Destroy(gameObject);
            }
            else {
                moveDirection = (enemy.transform.position - transform.position).normalized;
            }
        }
        else {
            if (Object.ReferenceEquals(player, null)) {
                Destroy(gameObject);
            }
            else {
                moveDirection = (player.transform.position - transform.position).normalized;
            }
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
        if (heroOrEnemy == 1 && other.gameObject.CompareTag("Hero")) {
            other.gameObject.GetComponent<Player>().HP --;
            other.gameObject.GetComponent<Player>().HP = Mathf.Max(0, other.gameObject.GetComponent<Player>().HP);
            Destroy(gameObject);
        } 
        
        if (heroOrEnemy == 0 && other.gameObject.CompareTag("Enemy")) {
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
