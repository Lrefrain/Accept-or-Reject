using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyTool(string choice)
    {
        if (choice == "BigWeak"){
            player.ballScale *= 2f;
        }
        else if (choice == "SmallWeak") {
            player.ballScale *= 0.5f;
        }
    }
}
