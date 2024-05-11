using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showshelf : MonoBehaviour
{
    public GameObject shelfWithPotions;
    public GameObject WordGuessingGame;

    private bool shelfActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!shelfActive)
            {
                ActivateShelf();
                DeactivateWordGuessingGame();
            }
        }
    }

    private void ActivateShelf()
    {
        shelfWithPotions.SetActive(true);
        shelfActive = true;
    }

    private void DeactivateWordGuessingGame()
    {
        WordGuessingGame.SetActive(false);
    }

    public void CloseShelf()
    {
        shelfWithPotions.SetActive(false);
        shelfActive = false;
        ActivateWordGuessingGame();
    }

    private void ActivateWordGuessingGame()
    {
        WordGuessingGame.SetActive(true);
    }
}
