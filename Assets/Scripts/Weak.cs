using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : MonoBehaviour
{
    public float bounds = 250f, speed = 80f, direction = 1f;
    public int HP = 2, count = 0;
    public Vector3 upbounds, lowbounds;
    public Tools tool;
    // Start is called before the first frame update
    void Start()
    {
        tool = GameObject.Find("ButtonManager").GetComponent<Tools>();
        upbounds = transform.position + new Vector3(0, bounds / 2f, 0);
        lowbounds = transform.position + new Vector3(0, -bounds / 2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = (new Vector3(0.5f, 0.05f, 1.0f)) * tool.weakScale;
        if (HP == count) {
            ++Camera.main.GetComponent<Wall>().now;
            Destroy(transform.parent.gameObject);
        }

        transform.position += transform.up * direction * speed * Time.deltaTime;
        if (transform.position.y > upbounds.y) {
            transform.position = upbounds;
            direction *= -1f;
        }

        if (transform.position.y < lowbounds.y) {
            transform.position = lowbounds;
            direction *= -1f;
        }
    }
}
