using UnityEngine;

public class IntroCanvasController : MonoBehaviour
{
    public GameObject introCanvas; // ���ý���Canvas

    void Start()
    {
        introCanvas.SetActive(true); // ��������ʱ����Canvas
    }

    void Update()
    {
        if (Input.anyKeyDown) // ����Ƿ������κΰ���
        {
            introCanvas.SetActive(false); // ������°���������Canvas
        }
    }
}

