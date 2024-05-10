using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the Text UI element

   

    private float timeRemaining = 240f; // 3 minutes in seconds
    public GameManager gameManager; // Reference to the GameManager script


    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Decrease the remaining time
            UpdateTimerDisplay(); // Update the timer display
        }
        else
        {
            timeRemaining = 0; // Ensure the timer doesn't go negative
            UpdateTimerDisplay(); // Update the timer display

            // Trigger game over condition when timer reaches 0
            if (gameManager != null)
            {
                gameManager.TimerZero(); // Call the game over method in GameManager
            }
            else
            {
                Debug.LogError("GameManager reference is missing in TimerScript!");
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f); // Calculate minutes
        int seconds = Mathf.FloorToInt(timeRemaining % 60f); // Calculate seconds

        // Update the Text UI element with the remaining time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Check if the timer has reached 00:00
        if (timeRemaining <= 0)
        {
            timerText.text = "00:00"; // Display "00:00" when the timer reaches 0


        }
    }
}
