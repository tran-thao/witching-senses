using UnityEngine;
using UnityEngine.SceneManagement;  // ���ó������������ռ�

public class EndLevelTrigger : MonoBehaviour
{
    public GameObject endLevelCanvas;  // ���ý�����ʾCanvas

    private void Start()
    {
        endLevelCanvas.SetActive(false);  // ��ʼʱ����Canvas
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endLevelCanvas.SetActive(true);  // ��ʾ������ʾCanvas
            Invoke("LoadNextScene", 3);  // 3�����ü����³����ĺ���
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene");  // �滻Ϊ������һ����������
    }
}
