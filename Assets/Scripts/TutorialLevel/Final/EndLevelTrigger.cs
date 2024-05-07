using UnityEngine;
using UnityEngine.SceneManagement;  // 引用场景管理命名空间

public class EndLevelTrigger : MonoBehaviour
{
    public GameObject endLevelCanvas;  // 引用结束提示Canvas

    private void Start()
    {
        endLevelCanvas.SetActive(false);  // 开始时隐藏Canvas
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endLevelCanvas.SetActive(true);  // 显示结束提示Canvas
            Invoke("LoadNextScene", 3);  // 3秒后调用加载新场景的函数
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene");  // 替换为您的下一个场景名称
    }
}
