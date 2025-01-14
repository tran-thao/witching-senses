using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TogglePanels : MonoBehaviour
{
    private GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        panel = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {

            if (SceneManager.GetActiveScene().name == "Smell")
            {
                Debug.Log("return");
                Debug.Log(panel.name);
                SmellPopUp smellPopUp = GameObject.Find("Canvas").GetComponent<SmellPopUp>();
                smellPopUp.ClosePopUp(panel);
                //panel.SetActive(false);
                //Time.timeScale = 1f; // Resume the game
            } else
            {
                PopUpScript popUpScript = GameObject.Find("Canvas").GetComponent<PopUpScript>();
                popUpScript.ClosePopUp(panel);
            }

        }
    }
}
