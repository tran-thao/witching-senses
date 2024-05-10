using UnityEngine;
using UnityEngine.UI;

public class SmellPopUp : MonoBehaviour
{
    //public GameObject introPanel;
    public GameObject instructionsPanel;
    //public GameObject GoToPianoPopUpPanel;
    public GameObject successPanel; 
    public GameObject wrongPanel; 


    void Start()
    {
        //this.gameObject.SetActive(false);
        // Show the initial welcome pop-up window at the beginning
        ShowPopUp(instructionsPanel);
        successPanel.SetActive(false);
        wrongPanel.SetActive(false);
        Time.timeScale = 0f; // Pause the game

    }

    // Show the pop-up panel
    public void ShowPopUp(GameObject panel)
    {
        Debug.Log("show panel: " + panel.name);
        panel.SetActive(true); // Activate the Pop-Up Panel
        Time.timeScale = 0f; // Pause the game
    }

    public void ClosePopUp(GameObject panel)
    {
        Debug.Log("Close panel: " + panel.name);
        panel.SetActive(false); // Hide the Pop-Up Panel
        Time.timeScale = 1f; // Resume the game

    }

}

