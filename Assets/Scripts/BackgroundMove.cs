using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private Vector3 MoveDistance = new Vector3(-20f, 0f, 0f), startPos;
    private float lst, resetCD = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // float r = Random.Range(-45f, 45f);
        // transform.localRotation = Quaternion.AngleAxis(r, Vector3.forward);
        // Speed = Random.Range(5f, 10f);
        startPos = transform.position;
        lst = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += MoveDistance * Time.deltaTime;
        if (Time.time - lst > resetCD) {
            lst = Time.time;
            transform.position = startPos;
        }
    }
}
