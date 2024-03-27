using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDManager : MonoBehaviour
{
    public Image image;
    public float shootCD;
    public float lst;
    // private Player player;
    // Start is called before the first frame update
    void start() {
        shootCD = 0.3f;
        image.fillAmount = 1.0f;
        lst = -5f;
    }
    private void Update()
    {
        if (Time.time - lst > shootCD) {
            image.fillAmount = 1f;
        }
        else {
            image.fillAmount = (Time.time - lst) / shootCD;
        }
    }
}
