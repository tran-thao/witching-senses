using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientScript : MonoBehaviour
{
    GameManager gameManagerScript;
    SmellGameManager smellgameManagerScript;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Smell")
        {
            smellgameManagerScript = GameObject.Find("smellGameManager").GetComponent<SmellGameManager>();
        }else
        {
            gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Smell")
            {
                smellgameManagerScript.ingredientsCollected++;
            }
            else
            {
                gameManagerScript.ingredientsCollected++;
            }
                
            // Destroy the ingredient when the player touches it
            Destroy(gameObject);

        }
    }
}
    