using UnityEngine;

public class IngredientScript : MonoBehaviour
{
    SmellGameManager gameManagerScript;

    private void Start()
    {
        gameManagerScript = GameObject.Find("smellGameManager").GetComponent<SmellGameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManagerScript.ingredientsCollected++;
            Debug.Log("ingredients remaining " + gameManagerScript.ingredientsCollected);
            // Destroy the ingredient when the player touches it
            Destroy(gameObject);
        }
    }
}
