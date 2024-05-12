using UnityEngine;

public class IngredientScript : MonoBehaviour
{
    GameManager gameManagerScript;

    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManagerScript.ingredientsCollected++;
            // Destroy the ingredient when the player touches it
            Destroy(gameObject);
        }
    }
}
