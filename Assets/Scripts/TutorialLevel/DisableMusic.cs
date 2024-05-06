using UnityEngine;
using System.Collections;

public class DisableMusic : MonoBehaviour
{
    public AudioSource backgroundMusic;  // Drag your music player's AudioSource here
    public GameObject hintBox;           // Drag your hint box UI GameObject here

    private void Start()
    {
        hintBox.SetActive(false);  // Ensure the hint box is hidden at start
        Debug.Log("Script started, hint box should be hidden.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);  // This will show the name of the object that entered the trigger
        if (other.CompareTag("Player"))  // Make sure it only triggers when the player enters
        {
            Debug.Log("Player has entered the trigger.");
            backgroundMusic.Stop();   // Stop the background music
            hintBox.SetActive(true);  // Show the hint box
            StartCoroutine(HideHintBoxAfterDelay(2));
        }

    }
    IEnumerator HideHintBoxAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the specified delay time
        hintBox.SetActive(false);  // Hide the hint box
    }
}
