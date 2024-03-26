using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallManager : MonoBehaviour
{
    public GameObject wallPrefab;
    public TextMeshProUGUI scoreBar;
    private float minRate = 0.1f, maxRate = 0.5f;
    private float leftX, rightX;
    // public Tools tools;
    private CameraSupport s;
    private int score = -1;
    // Start is called before the first frame update
    void Start()
    {
        // tools = GameObject.Find("ButtonManager").GetComponent<Tools>();
        // mid = Camera.main.transform.localPosition.y;
        s = Camera.main.GetComponent<CameraSupport>();
        GetPosx();
        CreateWall();
    }
    
    void GetPosx() 
    {
        float rightEdgeX = s.GetWorldBound().max.x, screenWidth = s.GetWorldBound().size.x;
        leftX = rightEdgeX - minRate * screenWidth;
        rightX = rightEdgeX - maxRate * screenWidth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void CreateWall()
    {
        score++;
        scoreBar.text = "Score:" + score;
        Vector3 pos = new Vector3(Random.Range(leftX, rightX), 0f, 0f);
        GameObject wall = Instantiate(wallPrefab, pos, Quaternion.identity);
        // wall.transform.GetChild(0).GetComponent<Weak>().direction *= dir;
        // wall.transform.GetChild(0).GetComponent<Weak>().speed *= speed;
    }
}
