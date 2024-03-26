using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject ballPrefab, starPrefab;
    public int HP = 5;
    private float speed = 50f;
    private Vector3 moveDirection, moveTarget;
    private float leftX, rightX, lowY, upY;
    private float minRate = 0.05f, maxRate = 0.4f;
    private CameraSupport s;
    private float eps = 1e-1f;
    private UseTools useTools;
    private float lastShootBallTime;
    private float lastShootStarTime;
    private float shootBallCD = 1f;
    private float shootStarCD = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        lastShootBallTime = 0f;
        lastShootStarTime = 0f;
        s = Camera.main.GetComponent<CameraSupport>();
        GetPos();
        useTools = Camera.main.GetComponent<UseTools>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = useTools.enemySpeed;
        ShootControl();
        GotoNewDes();

        if (HP == 0) {
            Destroy(gameObject);
        }
    }
    private float GetDis(Vector3 A, Vector3 B)
    {
        return (A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y);
    }
    private void GotoNewDes() 
    {
        if (GetDis(transform.position, moveTarget) < eps)
        {
            MoveControl();
        }
        else
        {
            moveDirection = (moveTarget - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
    private void MoveControl()
    {
        moveTarget = new Vector3(Random.Range(leftX, rightX), Random.Range(lowY, upY), 0);
    }
    private void GetPos()
    {
        float rightEdgeX = s.GetWorldBound().max.x, screenWidth = s.GetWorldBound().size.x;
        float upEdgeY = s.GetWorldBound().max.y, screenHeight = s.GetWorldBound().size.y;
        leftX = rightEdgeX - maxRate * screenWidth;
        rightX = rightEdgeX - minRate * screenWidth;
        lowY = upEdgeY - maxRate * screenHeight;
        upY = upEdgeY - minRate * screenHeight; 
    }

    private void ShootControl()
    {
        if (Time.time - lastShootBallTime > shootBallCD) {
            lastShootBallTime = Time.time;
            GameObject bullet = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Ball>().heroOrEnemy = 1;     // mark as an enemy bullet
        }
        if (Time.time - lastShootStarTime > shootStarCD) {
            lastShootStarTime = Time.time;
            GameObject bullet = Instantiate(starPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Star>().heroOrEnemy = 1;     // mark as an enemy bullet
        }
    }
}
