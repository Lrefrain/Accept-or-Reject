using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private float MoveSpeed = 0.02f;
    private Vector3 MoveDistance = new Vector3(-200, 0f, 0f);

    private Vector3 startPos;
    private Vector3 targetPos;
    private float lst = -0.3f;

    // Start is called before the first frame update
    void Start()
    {
        // float r = Random.Range(-45f, 45f);
        // transform.localRotation = Quaternion.AngleAxis(r, Vector3.forward);

        // Speed = Random.Range(5f, 10f);
        startPos = transform.position;
        targetPos = startPos + MoveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += MoveDistance * Time.deltaTime;
        if (Time.time - lst > 0.3f) {
            lst = Time.time;
            transform.position = startPos;
        }
    }
}
