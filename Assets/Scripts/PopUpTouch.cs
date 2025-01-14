using UnityEngine;
using UnityEngine.UI;

public class PopUpTouch : MonoBehaviour
{
    
    public GameObject chestOpenPanel; // Reference to the Message Pop-Up Panel GameObject
    public GameObject wrongChestPanel; // Reference to the Message Pop-Up Panel GameObject
    public GameObject instructionsTouchPanel;
    public GameObject introTouchPanel;


    void Start()
    {
        
        // Show the initial welcome pop-up window at the beginning
        chestOpenPanel.SetActive(false);
        wrongChestPanel.SetActive(false);
        instructionsTouchPanel.SetActive(false);
        Time.timeScale = 0f; // Pause the game

    }

    // Show the pop-up panel
    public void ShowPopUp(GameObject panel)
    {

        panel.SetActive(true); // Activate the Pop-Up Panel

        Time.timeScale = 0f; // Pause the game
    }

    public void ClosePopUp(GameObject panel)
    {
        Debug.Log("close " + panel.name);
        if (panel.name == "IntroTouch")
        {
            Debug.Log("if intro");
            CloseIntroPopUp();
        }else if(panel.name == "InstructionsTouch")
        {
            instructionsTouchPanel.SetActive(false);
           // ShowPopUp(GoToPianoPopUpPanel);
            Time.timeScale = 1f; // Resume the game
        }
        else
        {
            Debug.Log("else");
            panel.SetActive(false); // Hide the Pop-Up Panel
            Time.timeScale = 1f; // Resume the game
        }
        
    }

    private void CloseIntroPopUp()
    {
        introTouchPanel.SetActive(false); // Hide the Pop-Up Panel
        ShowPopUp(instructionsTouchPanel);
    }

    
}

