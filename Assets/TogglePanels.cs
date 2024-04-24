using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("return");
            panel.SetActive(false);
            Time.timeScale = 1f; // Resume the game
        }
    }
}
