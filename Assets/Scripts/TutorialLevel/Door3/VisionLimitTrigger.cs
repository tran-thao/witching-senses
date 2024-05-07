using UnityEngine;

public class VisionLimitTrigger : MonoBehaviour
{
    public GameObject hintCanvas;  // 指向提示信息Canvas的引用
    public MaskController maskController; // 指向MaskController的引用

    private void Start()
    {
        hintCanvas.SetActive(false);  // 确保提示Canvas一开始是隐藏的
        maskController.ShowMask(false); // 确保遮罩一开始也是隐藏的
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 显示提示Canvas和遮罩
            hintCanvas.SetActive(true);
            maskController.ShowMask(true);
            Invoke("HideCanvas", 2); // 2秒后隐藏Canvas和遮罩
        }
    }

    private void HideCanvas()
    {
        hintCanvas.SetActive(false);
    }
}
