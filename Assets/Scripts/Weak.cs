using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : MonoBehaviour
{
    private float speed = 80f, direction = 1f;
    // private float bounds = 250f, speed = 80f, direction = 1f;
    public int hp = 3;
    private float upbounds, lowbounds, rate = 0.2f;
    private CameraSupport s;
    // public Tools tool;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0f, 0f);
        s = Camera.main.GetComponent<CameraSupport>();
        float upEdgey = s.GetWorldBound().max.y, lowEdgey = s.GetWorldBound().min.y, screenHeight = s.GetWorldBound().size.y;
        // tool = GameObject.Find("ButtonManager").GetComponent<Tools>();
        lowbounds = lowEdgey + rate * screenHeight;
        upbounds = upEdgey - rate * screenHeight;
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
        HpControl();
    }
    private void MoveControl()
    {
        transform.position += transform.up * direction * speed * Time.deltaTime;
        if (transform.position.y > upbounds) {
            Vector3 pos = transform.position;
            pos.y = upbounds;
            transform.position = pos;
            direction *= -1f;
        }
        else if (transform.position.y < lowbounds) {
            Vector3 pos = transform.position;
            pos.y = lowbounds;
            transform.position = pos;
            direction *= -1f;
        }
    }
    private void HpControl()
    {
        if (hp <= 0) {
            Camera.main.GetComponent<WallManager>().CreateWall();
            Destroy(transform.parent.gameObject);
        }
    }
}
