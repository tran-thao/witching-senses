using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShelf : MonoBehaviour
{
    public Showshelf interactionScript; // Reference to the InteractionScript

    private void Start()
    {
        // Find the InteractionScript in the scene
        interactionScript = GameObject.FindObjectOfType<Showshelf>();
    }

    public void OnCloseButtonClick()
    {
        // Call the CloseShelf method in the InteractionScript
        interactionScript.CloseShelf();
    }
}
