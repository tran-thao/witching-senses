using UnityEngine;

public class VisionLimitTrigger : MonoBehaviour
{
    public GameObject hintCanvas;  // ָ����ʾ��ϢCanvas������
    public MaskController maskController; // ָ��MaskController������

    private void Start()
    {
        hintCanvas.SetActive(false);  // ȷ����ʾCanvasһ��ʼ�����ص�
        maskController.ShowMask(false); // ȷ������һ��ʼҲ�����ص�
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ��ʾ��ʾCanvas������
            hintCanvas.SetActive(true);
            maskController.ShowMask(true);
            Invoke("HideCanvas", 2); // 2�������Canvas������
        }
    }

    private void HideCanvas()
    {
        hintCanvas.SetActive(false);
    }
}
