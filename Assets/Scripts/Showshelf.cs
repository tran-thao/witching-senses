using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showshelf : MonoBehaviour
{
    public GameObject shelfWithPotions; // Reference to the shelf GameObject

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hey");
        if (other.CompareTag("Player")) // Assuming the player interacts with the object
        {
            ActivateShelf();
            Debug.Log("hey hallo");
        }
    }

    private void ActivateShelf()
    {
        // Activate the shelf GameObject and its children
        shelfWithPotions.SetActive(true);
    }
}
