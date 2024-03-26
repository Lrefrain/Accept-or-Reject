using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 300.0f;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        GetMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        OutBounds();
        MoveControl();
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
    private void GetMoveDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        moveDirection = (mousePosition - transform.position).normalized;
    }
}
