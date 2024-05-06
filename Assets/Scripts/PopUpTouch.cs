using UnityEngine;
using UnityEngine.UI;

public class PopUpTouch : MonoBehaviour
{
    public GameObject howToPopUpPanel; // Reference to the Welcome Pop-Up Panel GameObject
    public GameObject successPopUpPanel; // Reference to the Message Pop-Up Panel GameObject
    public GameObject wrongNotePopUpPanel; // Reference to the Message Pop-Up Panel GameObject
   // public GameObject GoToPianoPopUpPanel;
    public GameObject introPanel;
    public GameObject instructionsPanel;


    void Start()
    {
        //this.gameObject.SetActive(false);
        // Show the initial welcome pop-up window at the beginning
        howToPopUpPanel.SetActive(false);
        successPopUpPanel.SetActive(false);
        wrongNotePopUpPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        //GoToPianoPopUpPanel.SetActive(false);
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
        if (panel.name == "Intro")
        {
            Debug.Log("if intro");
            CloseIntroPopUp();
        }else if(panel.name == "Instructions")
        {
            instructionsPanel.SetActive(false);
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
        introPanel.SetActive(false); // Hide the Pop-Up Panel
        ShowPopUp(instructionsPanel);
    }

    
}

