using UnityEngine;

public class ControlReverseTrigger : MonoBehaviour
{
    public GameObject hintCanvas; // Drag the hint Canvas GameObject here

    private void Start()
    {
        hintCanvas.SetActive(false); // Ensure the Canvas is hidden at start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Toggle reverse control only once when entering the trigger
            other.GetComponent<PlayerControl>().ToggleReverseControl();

            // Show hint canvas
            hintCanvas.SetActive(true);
            Invoke("HideCanvas", 4); // Schedule to hide the hint canvas after 2 seconds
        }
    }

    private void HideCanvas()
    {
        hintCanvas.SetActive(false); // Hide the hint canvas
    }
}
