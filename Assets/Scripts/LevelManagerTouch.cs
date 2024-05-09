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
    private bool keyHeld = false; //Store Key held value
    private KeyScript collectedKey;  // Reference to the collected key
    private string heldKeyType;  // Store the type of held key
    public int totalChests;  // Total number of chests in the level
    private int openedChests = 0;  // Number of opened chests
    private bool levelCompleted = false;  // Flag to track level completion


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

    public bool IsKeyHeld() //Checking if key is collected
    {
        return keyHeld;
    }

    public void SetKeyHeld(bool held) //setting key held status
    {
        keyHeld = held;
    }

    // Method to set the held key type
    public void SetHeldKeyType(string keyType)
    {
        heldKeyType = keyType;
    }

    // Method to get the held key type
    public string GetHeldKeyType()
    {
        return heldKeyType;
    }

    public void SetCollectedKey(KeyScript key)
    {
        collectedKey = key;  // Set the collected key reference
    }

    public void ResetCollectedKey()
    {
        
        if (collectedKey != null)
        {
            Debug.Log("Collected key :" + collectedKey);
            collectedKey.ResetToInitialPosition();  // Reset the collected key to initial position
        }
        else
        {
            Debug.LogError("No collected key reference!");
        }
    }

   

   public void ChestOpened()
    {
        openedChests++;
        Debug.Log("Chest opened! Total open chests: " + openedChests);
        if (openedChests >= totalChests && !levelCompleted)
        {
            levelCompleted = true;
            Debug.Log("Level Complete! All chests opened.");
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

    private void LoadSuccess()
    {
        // Load the Main menu scene by name 
        successPanel.SetActive(true);
    }

    private void Update()
    {
        if (levelCompleted)
        {
            Invoke("LoadSuccess", 1f);
    
        }
    }



}

