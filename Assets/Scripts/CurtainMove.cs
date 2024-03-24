using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainMove : MonoBehaviour
{

    public bool isCurtainOpen = false;
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
        transform.position = transform.position + new Vector3(0, -1f, 0);
        if(transform.position.y < 0f)
        {
            isCurtainOpen = false;
        }
    }

    


}
