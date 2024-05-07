using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5.0f;
    private bool isReversed = false;
    private bool hasReversedOnce = false;  // 新增变量，用于跟踪是否已经反转过一次

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (isReversed)
        {
            moveInput.x *= -1; // Invert the horizontal control
            moveInput.y *= -1; // Invert the vertical control
        }
        transform.Translate(moveInput * speed * Time.deltaTime);
    }

    public void ToggleReverseControl()
    {
        // 只有当还没有反转过一次时才执行反转
        if (!hasReversedOnce)
        {
            isReversed = !isReversed;
            hasReversedOnce = true;  // 标记已经反转过，防止再次反转
        }
    }
}
