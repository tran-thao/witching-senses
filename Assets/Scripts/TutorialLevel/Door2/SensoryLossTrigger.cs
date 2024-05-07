using UnityEngine;

public class SensoryLossTrigger : MonoBehaviour
{
    public GameObject hintCanvas; // Drag your entire Canvas GameObject here, which includes the text

    private void Start()
    {
        hintCanvas.SetActive(false); // Ensure the Canvas is hidden at start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the black and white shader effect permanently
            Camera.main.GetComponent<ShaderController>().ToggleShader(true);

            // Show the hint canvas
            hintCanvas.SetActive(true);

            // Schedule to hide the hint canvas after 2 seconds
            Invoke("HideCanvas", 2);
        }
    }

    void HideCanvas()
    {
        hintCanvas.SetActive(false); // Hide the hint canvas
    }
}



