using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainMove : MonoBehaviour
{

    public bool isCurtainOpen = false;
    private float curtainSpeed = 500f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isCurtainOpen)
        {
            OpenCurtain();
        }

    }

    public void OpenCurtain()
    {
        transform.position = transform.position + new Vector3(0f, -curtainSpeed * Time.smoothDeltaTime, 0f);
        if(transform.position.y < -400f)
        {
            isCurtainOpen = false;
        }
    }

    


}
