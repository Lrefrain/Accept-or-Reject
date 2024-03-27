using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shizuka : MonoBehaviour
{
    private float speed = 50f;
    private Vector3 moveDirection, moveTarget;
    private float leftX, rightX, lowY, upY;
    private float minRate = 0.05f, maxRate = 0.4f;
    private CameraSupport s;
    private float eps = 1e-1f;
    private UseTools useTools;
    // Start is called before the first frame update
    void Start()
    {
        s = Camera.main.GetComponent<CameraSupport>();
        GetPos();
        MoveControl();
        transform.position = moveTarget;
        useTools = Camera.main.GetComponent<UseTools>();
        StartCoroutine(DestroyComponentAfterDelay(useTools.delaySeconds));
    }

    private IEnumerator DestroyComponentAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        speed = useTools.enemySpeed;
        GotoNewDes();
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
}
