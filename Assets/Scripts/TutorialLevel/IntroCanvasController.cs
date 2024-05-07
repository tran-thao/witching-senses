using UnityEngine;

public class IntroCanvasController : MonoBehaviour
{
    public GameObject introCanvas; // 引用介绍Canvas

    void Start()
    {
        introCanvas.SetActive(true); // 场景加载时激活Canvas
    }

    void Update()
    {
        if (Input.anyKeyDown) // 检查是否按下了任何按键
        {
            introCanvas.SetActive(false); // 如果按下按键，隐藏Canvas
        }
    }
}

