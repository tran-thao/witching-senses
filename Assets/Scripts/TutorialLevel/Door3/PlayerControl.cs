using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5.0f;
    private bool isReversed = false;
    private bool hasReversedOnce = false;  // �������������ڸ����Ƿ��Ѿ���ת��һ��

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
        // ֻ�е���û�з�ת��һ��ʱ��ִ�з�ת
        if (!hasReversedOnce)
        {
            isReversed = !isReversed;
            hasReversedOnce = true;  // ����Ѿ���ת������ֹ�ٴη�ת
        }
    }
}
