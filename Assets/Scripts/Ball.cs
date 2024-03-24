using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    public float speed = 120f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);

        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Weak"))
        {
            Debug.Log("1111");
            ++other.gameObject.GetComponent<Weak>().count;
            Destroy(gameObject);
        }
    }
}
