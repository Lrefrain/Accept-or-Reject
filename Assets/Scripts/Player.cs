using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // public Weapon weapon = null;
    public GameObject ballPrefab;
    public TextMeshProUGUI cdBar;
    private float lastShootTime, shootCD = 0.5f, speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        lastShootTime = -3f;
    }

    // Update is called once per frame
    void Update()
    {
        // if (!IsPointerOverButton()){
        //     ShootControl();
        // }
        ShootControl();
        MoveControl();
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
            cdBar.text = "Ball:Ready";
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
                lastShootTime = Time.time;
                GameObject bullet = Instantiate(ballPrefab, transform.position, Quaternion.identity);
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
