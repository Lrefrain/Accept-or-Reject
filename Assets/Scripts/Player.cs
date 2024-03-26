using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private UseTools useTools;
    public GameObject ballPrefab;
    public GameObject starPrefab;
    public TextMeshProUGUI cdBar;
    public int HP = 3;
    private float lastShootTime, shootCD = 0.5f, speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        lastShootTime = -3f;
        useTools = Camera.main.GetComponent<UseTools>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (!IsPointerOverButton()){
        //     ShootControl();
        // }
        ShootControl();
        MoveControl();
        
        if (HP == 0) {
            Destroy(gameObject);
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

    private void ShootControl()
    {
        if (Time.time - lastShootTime > shootCD) {
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
