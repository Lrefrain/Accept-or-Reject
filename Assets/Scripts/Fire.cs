using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

public class Fire : MonoBehaviour
{
    public Animation fireAnimation; // 引用Animation组件

    void Start()
    {
        // 获取Animation组件
        fireAnimation = GetComponent<Animation>();

        // 创建动画帧并添加到动画剪辑中
        for (int i = 1; i <= 6; i++)
        {
            // 加载图片素材，假设图片名称为"fire_frame" + 帧数
            Sprite sprite = Resources.Load<Sprite>("PlayerFire/" + i);

            // 创建关键帧
            AnimationClip clip = new AnimationClip();
            clip.legacy = true; // 使用旧版的动画系统
            clip.SetCurve("", typeof(SpriteRenderer), "m_Sprite", AnimationCurve.Linear(0, i - 1, 1, i)); // 设置帧的变化

            // 将关键帧添加到动画组件中
            fireAnimation.AddClip(clip, "PlayerFire" + i);
        }
    }

    void Update()
    {
        // 播放动画
        if (!fireAnimation.isPlaying)
        {
            fireAnimation.Play("FireAnimation");
        }
    }
}