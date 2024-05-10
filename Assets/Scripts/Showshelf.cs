using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showshelf : MonoBehaviour
{
    public GameObject shelfWithPotions; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hey");
        if (other.CompareTag("Player"))
        {
            ActivateShelf();
            Debug.Log("hey hallo");
        }
    }

    private void ActivateShelf()
    {
        shelfWithPotions.SetActive(true);
    }
}
