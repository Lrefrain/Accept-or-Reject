using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Animator fireAnimation; // 动画组件

    void Start()
    {
        fireAnimation = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void PlayAnimation(string name) 
    {
        // fireAnimation.Play(name);
    }

}