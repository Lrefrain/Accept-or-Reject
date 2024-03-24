using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public Weapon weapon = null;
    public GameObject bulletPrefab = null;
    public float bulletSpeed  = 120f;
    public float ballScale = 1f;
    private float lastShootTime = 0f, shootCD = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        // if (weapon == null) Debug.Log("Weapon lost!");
        // bulletPrefab = Resources.Load("Bullet");
        lastShootTime = -3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPointerOverButton()){
            ShootControl();
        }
    }
    private void ShootControl()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastShootTime > shootCD){
            lastShootTime = Time.time;
            // 获取鼠标指针世界坐标
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            // 计算发射方向
            Vector2 shootDirection = (mousePosition - transform.position).normalized;
            // 实例化子弹并设定方向
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Debug.Log(ballScale);
            bullet.transform.localScale *= ballScale;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(shootDirection.x, shootDirection.y, 0f) * bulletSpeed;
        }
    }
    bool IsPointerOverButton()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 screenPointToUI = Camera.main.ScreenToWorldPoint(mousePosition);

        // 检查是否点击到了UI按钮上
        RectTransform rectTransform = GameObject.Find("ButtonAccept").GetComponent<RectTransform>();
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPointToUI))
        {
            return true;
        }
        rectTransform = GameObject.Find("ButtonReject").GetComponent<RectTransform>();
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPointToUI))
        {
            return true;
        }

        return false;
    }
}
