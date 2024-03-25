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
    public Tools tools;
    public CameraSupport s;
    // Start is called before the first frame update
    void Start()
    {
        tools = GameObject.Find("ButtonManager").GetComponent<Tools>();
        mid = Camera.main.transform.localPosition.y;
        s = Camera.main.GetComponent<CameraSupport>();  // Try to access the CameraSupport component on the MainCamera
        rightEdgeX = s.GetWorldBound().max.x;
        screenWidth = s.GetWorldBound().size.x;
        GenerateWall();
    }
    
    void GenerateWall() 
    {
        float positionX = rightEdgeX - screenWidth / 10;
        float dir = 1.0f;
        for (int i = 0 ; i < 3; ++i) {
            float speed = Random.Range(0.8f, 1.2f);
            CreateWall(positionX, dir, speed);
            positionX -= screenWidth / 5;
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
                tools.ResetParameters();
            }
        }
    }

    public void CreateWall(float positionX, float dir, float speed)
    {
        GameObject newWall = Instantiate(wall);
        newWall.transform.position = new Vector3(positionX, mid, 0f);
        newWall.transform.GetChild(0).GetComponent<Weak>().direction *= dir;
        newWall.transform.GetChild(0).GetComponent<Weak>().speed *= speed;
    }
}
