using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    private float shakeDuration = 0.4f;
    private float shakeMagnitude = 3f;
    private float shakeTimer = 0f;

    void Update()
    {
        if (shakeTimer > 0)
        {
            Debug.Log("Shaker: " + shakeTimer.ToString());
            Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;
            Camera.main.transform.localPosition = shakeOffset;

            shakeTimer -= Time.deltaTime;
            Camera.main.transform.localPosition -= new Vector3(0f, 0f, 10f + Camera.main.transform.localPosition.z);
        }
        else
        {
            shakeTimer = 0f;
            Camera.main.transform.localPosition = new Vector3(0f, 0f, -10f);
        }
    }

    public void StartShake()
    {
        shakeTimer = shakeDuration;
    }
}
