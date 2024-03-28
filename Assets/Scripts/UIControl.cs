using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    private CameraSupport cs;
    private float lx, ly, rx, ry, sx, sy;
    public GameObject enemyHp, reject, accept, confirm, text;
    // Start is called before the first frame update
    void Start()
    {
        cs = Camera.main.GetComponent<CameraSupport>();
        GetBounds();
        EnemyHpPosition();
        CheckButtonPosition();
        TextPosition();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void CheckButtonPosition()
    {
        float y = ly + 0.15f * sy;
        float x = lx + 0.3f * sx;
        reject.transform.position = new Vector3(x, y, reject.transform.position.z);
        accept.transform.position = new Vector3(-x, y, accept.transform.position.z);
        confirm.transform.position = new Vector3(0f, y, confirm.transform.position.z);
    }
    private void TextPosition()
    {
        float y = ly + 0.35f * sy;
        text.transform.position = new Vector3(0f, y, text.transform.position.z);
    }
    private void EnemyHpPosition()
    {
        float y = ly + 0.80f * sy;
        enemyHp.transform.position = new Vector3(0f, y, 0f);
    }
    // lx=-231.1111 ly=-130
    // rx=231.1111 ry=130 
    // sx=462.2222 sz=260
    private void GetBounds()
    {
        lx = cs.GetWorldBound().min.x;
        ly = cs.GetWorldBound().min.y;
        rx = cs.GetWorldBound().max.x;
        ry = cs.GetWorldBound().max.y;

        sx = cs.GetWorldBound().size.x;
        sy = cs.GetWorldBound().size.y;
    }
}
