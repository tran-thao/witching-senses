using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    public GameObject welcomePopUpPanel; // Reference to the Welcome Pop-Up Panel GameObject
    public GameObject messagePopUpPanel; // Reference to the Message Pop-Up Panel GameObject
    public GameObject wrongPopUpPanel; // Reference to the Message Pop-Up Panel GameObject


    void Start()
    {
        messagePopUpPanel.SetActive(false);
        wrongPopUpPanel.SetActive(false);
        // Show the initial welcome pop-up window at the beginning
        ShowWelcomePopUp();
    }

    void ShowWelcomePopUp()
    {
        welcomePopUpPanel.SetActive(true); // Activate the Welcome Pop-Up Panel
        Time.timeScale = 0f; // Pause the game
    }

    public void CloseWelcomePopUp()
    {
        welcomePopUpPanel.SetActive(false); // Deactivate the Welcome Pop-Up Panel
        Time.timeScale = 1f; // Resume the game
    }

    public void ShowMessage()
    {
        messagePopUpPanel.SetActive(true); // Activate the Message Pop-Up Panel
        Time.timeScale = 0f; // Pause the game
    }

    public void CloseMessagePopUp()
    {
        messagePopUpPanel.SetActive(false); // Deactivate the Message Pop-Up Panel
        Time.timeScale = 1f; // Resume the game
    }

    public void ShowWrongPopUp()
    {
        wrongPopUpPanel.SetActive(true); // Activate the Message Pop-Up Panel
        Time.timeScale = 0f; // Pause the game
    }

    public void CloseWrongPopUp()
    {
        wrongPopUpPanel.SetActive(false); // Deactivate the Message Pop-Up Panel
        Time.timeScale = 1f; // Resume the game
    }

}
