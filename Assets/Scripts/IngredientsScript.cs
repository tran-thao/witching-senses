using UnityEngine;

public class IngredientScript : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the ingredient when the player touches it
            Destroy(gameObject);
        }
    }
}
