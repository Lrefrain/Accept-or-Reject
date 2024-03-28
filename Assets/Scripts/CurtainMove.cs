using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainMove : MonoBehaviour
{

    public bool curtainUp = false, curtainDown = false;
    private float curtainSpeed = 200f;
    private float startY, endY;
    private CameraSupport cs;
    void Start()
    {
        cs = Camera.main.GetComponent<CameraSupport>();
        GetBounds();
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
    private void GetBounds()
    {
        float ly, sy;
        // lx = cs.GetWorldBound().min.x;
        ly = cs.GetWorldBound().min.y;
        // rx = cs.GetWorldBound().max.x;
        // ry = cs.GetWorldBound().max.y;
        // sx = cs.GetWorldBound().size.x
        sy = cs.GetWorldBound().size.y;
        startY = ly + 1.3f * sy;
        endY = ly + 0.6f * sy;
        transform.position = new Vector3(transform.position.x, startY, transform.position.z);
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
