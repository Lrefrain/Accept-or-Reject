using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float blinkTime;
    private int blinks;

    private Renderer myRender;
    void Start()
    {
        blinkTime = 0.03f;
        blinks = 1;
        myRender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer()
    {
        BlinkPlayer(blinks,blinkTime);
    }

    void BlinkPlayer(int numBlinks,float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }
    
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
}
