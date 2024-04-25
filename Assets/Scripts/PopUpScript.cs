using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    public GameObject howToPopUpPanel; // Reference to the Welcome Pop-Up Panel GameObject
    public GameObject successPopUpPanel; // Reference to the Message Pop-Up Panel GameObject
    public GameObject wrongNotePopUpPanel; // Reference to the Message Pop-Up Panel GameObject
    public GameObject GoToPianoPopUpPanel;


    void Start()
    {
        //this.gameObject.SetActive(false);
        // Show the initial welcome pop-up window at the beginning
        howToPopUpPanel.SetActive(false);
        successPopUpPanel.SetActive(false);
        wrongNotePopUpPanel.SetActive(false);

    }

    // Show the pop-up panel
    public void ShowPopUp(GameObject panel)
    {

        panel.SetActive(true); // Activate the Pop-Up Panel

        Time.timeScale = 0f; // Pause the game
    }

    public void ClosePopUp(GameObject panel)
    {
        panel.SetActive(false); // Hide the Pop-Up Panel
        Time.timeScale = 1f; // Resume the game
    }
}

