using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerTouch : MonoBehaviour
{
    public List<GameObject> ingredients; // List to store references to ingredients
    public GameObject gameOverPanel; // Reference to the game over panel
    public GameObject successPanel; // Reference to the success panel
    private bool gameOver = false; // Track game over state
    private bool[] collectedKeys = new bool[3]; //Store collected keys


    private void Start()
    {
        // Ensure game over panel is initially hidden
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Hide the game over panel
        }
        else
        {
            Debug.LogError("Game Over Panel reference is missing!");
        }

        if (successPanel != null)
        {
            
            successPanel.SetActive(false); // Hide the success panel
        }
        else
        {
            Debug.LogError("Success Panel reference is missing!");
        }
    }

    public void TimerZero()
    {

        // Check if the game is already over
        if (gameOver)
        {
            return; // return if the game is already over
        }
  
            // Set game over flag
            gameOver = true;

           // Debug.Log("Game Over");

             //Activate the game over panel 

            if (gameOverPanel != null)
            {
             gameOverPanel.SetActive(true);

            // Load the new scene after 3 seconds
            Invoke("LoadMainMenu", 3f);

        }
            else
            {
              Debug.LogError("Game Over Panel reference is missing!");
            }
        
    }

    private void LoadMainMenu()
    {
        // Load the Main menu scene by name 
        SceneManager.LoadScene("MainMenu");
    }

    public void KeyCollected(string keyType)
    {
        switch (keyType)
        {
            case "Vibration":
                collectedKeys[0] = true;
                break;
            case "Hot":
                collectedKeys[1] = true;
                break;
            case "Cold":
                collectedKeys[2] = true;
                break;
            default:
                break;
        }
        
    }

}

