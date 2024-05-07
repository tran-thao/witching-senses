using UnityEngine;

public class MaskController : MonoBehaviour
{
    public Transform playerTransform;  // 玩家的Transform
    public Camera mainCamera;          // 主摄像机
    public Canvas canvas;              // 遮罩所在的Canvas

    private RectTransform myRectTransform;  // 遮罩的RectTransform

    private void Start()
    {
        myRectTransform = GetComponent<RectTransform>();  // 获取RectTransform组件
    }

    private void Update()
    {
        if (playerTransform != null && mainCamera != null && canvas != null)
        {
            Vector2 viewportPosition = mainCamera.WorldToViewportPoint(playerTransform.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
                ((viewportPosition.x * canvas.GetComponent<RectTransform>().sizeDelta.x) - (canvas.GetComponent<RectTransform>().sizeDelta.x * 0.5f)),
                ((viewportPosition.y * canvas.GetComponent<RectTransform>().sizeDelta.y) - (canvas.GetComponent<RectTransform>().sizeDelta.y * 0.5f)));

            myRectTransform.anchoredPosition = WorldObject_ScreenPosition;
        }
    }

    public void ShowMask(bool show)
    {
        gameObject.SetActive(show);
    }
}
