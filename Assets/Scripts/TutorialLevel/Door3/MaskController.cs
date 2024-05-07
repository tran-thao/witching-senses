using UnityEngine;

public class MaskController : MonoBehaviour
{
    public Transform playerTransform;  // ��ҵ�Transform
    public Camera mainCamera;          // �������
    public Canvas canvas;              // �������ڵ�Canvas

    private RectTransform myRectTransform;  // ���ֵ�RectTransform

    private void Start()
    {
        myRectTransform = GetComponent<RectTransform>();  // ��ȡRectTransform���
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
