using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private int wallCnt = 3 * 4;
    public int now = 0;
    public float rightEdgeX = 0f;
    public float screenWidth = 0f;
    public float mid = 0f;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        Camera mainCamera = Camera.main;
        Vector3 rightEdgeWorld = mainCamera.ScreenToWorldPoint(new Vector3(screenWidth, 0f, mainCamera.nearClipPlane));
        rightEdgeX = rightEdgeWorld.x;
        mid = mainCamera.transform.localPosition.y;

        Debug.Log("Right edge position: " + rightEdgeX);
        
        GenerateWall();
    }

    void GenerateWall() 
    {
        float positionX = rightEdgeX - screenWidth / 30;
        float dir = 1.0f;
        for (int i = 0 ; i < 3; ++i) {
            Debug.Log(rightEdgeX);
            Debug.Log(screenWidth);
            Debug.Log(positionX);
            float speed = Random.Range(0.8f, 1.2f);
            CreateWall(positionX, dir, speed);
            positionX -= screenWidth / 20;
            dir *= -1f;
        }
        wallCnt -= 3;
    }
    public string url = "https://ys.mihoyo.com/"; // 要打开的链接
    public void OpenLink()
    {
        // 在设备的默认浏览器中打开链接
        Application.OpenURL(url);
    }

    // Update is called once per frame
    void Update()
    {
        if (now == 3)
        {
            now = 0;
            if (wallCnt == 0) 
            {
                OpenLink();
            }
            else 
            {
                GenerateWall();
            }
        }
    }

    public void CreateWall(float positionX, float dir, float speed)
    {
        GameObject newWall = Instantiate(wall);
        wall.transform.position = new Vector3(positionX, mid, 0f);
        wall.transform.GetChild(0).GetComponent<Weak>().direction *= dir;
        wall.transform.GetChild(0).GetComponent<Weak>().speed *= speed;
    }
}
