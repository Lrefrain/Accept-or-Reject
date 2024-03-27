using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private UseTools useTools;
    public GameObject ballPrefab, starPrefab;
    public Text cdBar;
    public int HP;
    private float lastShootTime, shootCD = 0.5f, speed = 100f;
    private float leftX, rightX, upY, lowY, rate = 0.3f;
    private CameraSupport s;
    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        lastShootTime = -3f;
        useTools = Camera.main.GetComponent<UseTools>();
        s = Camera.main.GetComponent<CameraSupport>();
        GetBounds();
    }

    // Update is called once per frame
    void Update()
    {
        // if (!IsPointerOverButton()){
        //     ShootControl();
        // }
        ShootControl();
        MoveControl();
        CheckHP();
        InBounds();
    }
    private void GetBounds()
    {
        leftX = s.GetWorldBound().min.x + 23;
        float screenWidth = s.GetWorldBound().size.x;
        rightX = leftX + rate * screenWidth;
        upY = s.GetWorldBound().max.y - 14;
        lowY = s.GetWorldBound().min.y + 14;
    }
    private void InBounds()
    {
        Vector3 pos = transform.position;
        if (pos.x >= rightX) pos.x = rightX;
        if (pos.x <= leftX) pos.x = leftX;
        if (pos.y >= upY) pos.y = upY;
        if (pos.y <= lowY) pos.y = lowY;
        transform.position = pos;
    }
    private void CheckHP()
    {
        if (HP == 0) {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
    private void MoveControl()
    {
        // add bounds
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(movex, movey, 0).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private float GetShootCD()
    {
        return shootCD * useTools.shootCDRate;
    }

    private void ShootControl()
    {
        if (Time.time - lastShootTime > GetShootCD()) {
            cdBar.text = "Bullet:Ready";
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
                lastShootTime = Time.time;
                GameObject bullet = Instantiate(ballPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Ball>().heroOrEnemy = 0;     // mark as a hero bullet

                if (useTools.heroHasStar) {
                    GameObject star = Instantiate(starPrefab, transform.position, Quaternion.identity);
                    star.GetComponent<Star>().heroOrEnemy = 0;     // mark as a hero bullet
                }
                cdBar.text = "";
            }
        }
    }

    bool IsPointerOverButton()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 screenPointToUI = Camera.main.ScreenToWorldPoint(mousePosition);

        // 检查是否点击到了UI按钮上
        RectTransform rectTransform = GameObject.Find("Canvas/ButtonAccept").GetComponent<RectTransform>();
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPointToUI))
        {
            return true;
        }
        rectTransform = GameObject.Find("Canvas/ButtonReject").GetComponent<RectTransform>();
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPointToUI))
        {
            return true;
        }
        rectTransform = GameObject.Find("Canvas/ConfirmReject").GetComponent<RectTransform>();
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPointToUI))
        {
            return true;
        }

        return false;
    }
}
