using UnityEngine;
using UnityEngine.SceneManagement;  // ????????????????????

public class EndLevelTrigger : MonoBehaviour
{
    public GameObject endLevelCanvas;  // ????????????Canvas

    private void Start()
    {
        endLevelCanvas.SetActive(false);  // ??????????Canvas
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endLevelCanvas.SetActive(true);  // ????????????Canvas
            Invoke("LoadNextScene", 3);  // 3????????????????????????
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene1");  // ????????????????????????
    }
}
