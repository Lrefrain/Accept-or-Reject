using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainMove : MonoBehaviour
{

    public bool curtainUp = false, curtainDown = false;
    private float curtainSpeed = 200f;
    private float startY = 197f, endY = 12f;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (curtainUp){
            CurtainUp();
        }
        if (curtainDown){
            CurtainDown();
        }
    }

    private void CurtainUp()
    {
        Vector3 pos = transform.position;
        pos += new Vector3(0f, curtainSpeed * Time.smoothDeltaTime, 0f);
        if(pos.y >= startY) {
            pos.y = startY;
            curtainUp = false;
        }
        transform.position = pos;
    }
    private void CurtainDown()
    {
        Vector3 pos = transform.position;
        pos -= new Vector3(0f, curtainSpeed * Time.smoothDeltaTime, 0f);
        if(pos.y <= endY) {
            pos.y = endY;
            curtainDown = false;
        }
        transform.position = pos;
    }
}
