using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SmellGameManager : MonoBehaviour
{
    public GameObject smellIngredient;
    public GameObject smellSprite;


    public List<Vector3> spawnPoints = new List<Vector3>(); // Define an array of spawn points
    public int numberOfPrefabs = 9;
    public bool gameStarted;
    public SpriteRenderer referenceSmellSprite;
    public SpriteRenderer mySmellSprite;
    public bool success;

    public Color[] referenceColors = { Color.green, new Color(0.5f, 0, 0.5f), new Color(1, 0.5f, 0) }; // green, purple, orange
    public Color[] ingredientColors = { Color.blue, Color.red, Color.yellow };
    public Color[] requiredColors = new Color[2];

    public List<GameObject> ingredients; // List to store references to ingredients
    public GameObject gameOverPanel; // Reference to the game over panel
    public GameObject successPanel; // Reference to the success panel
    private bool gameOver = false; // Track game over state
    public int ingredientsCollected = 0;

    public GameObject ingredientsPrefab;

    public int blueCount = 0;
    public int redCount = 0;
    public int yellowCount = 0;

    void Start()
    {
        gameStarted = false;
        referenceSmellSprite = GameObject.Find("referenceSmell").GetComponent<SpriteRenderer>();
        mySmellSprite = GameObject.Find("mySmell").GetComponent<SpriteRenderer>();

        // Define spawn points
        spawnPoints.Add(new Vector3(-48.2f, -20.6f, -2f));
        spawnPoints.Add(new Vector3(-48.9f, 20.3f, -2f));
        spawnPoints.Add(new Vector3(5.9f, -12.3f, -2f));
        spawnPoints.Add(new Vector3(-3.7f, 21f, -2f));
        spawnPoints.Add(new Vector3(21.92376f, 26.7061f, -2f));
        spawnPoints.Add(new Vector3(54.24879f, 15.32769f, -2f));
        spawnPoints.Add(new Vector3(47.3f, -20.6f, -2f));
        spawnPoints.Add(new Vector3(-25.5f, 27.2f, -2f));
        spawnPoints.Add(new Vector3(-13.5f, -24.8f, -2f));



        // Ensure game over panel is initially hidden
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Hide the game over panel
        }
        else
        {
            Debug.LogError("Game Over Panel reference is missing!");
        }

        if (successPanel != null)
        {

            successPanel.SetActive(false); // Hide the success panel
        }
        else
        {
            Debug.LogError("Success Panel reference is missing!");
        }
    }

    private void Update()
    {
        if (ingredientsCollected >= 3)
        {
            successPanel.SetActive(true);
            Invoke("LoadMainMenu", 3f);
        }
    }

    public void startSmellGame()
    {
        generateReferenceSmell();
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        int spawnedCount = 0;

        // Variables to track the number of prefabs of each color


        while (spawnedCount < numberOfPrefabs && spawnPoints.Count > 0)
        {
            // Get a random index from the spawnPoints list
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Vector3 spawnPoint = spawnPoints[randomIndex];

            // Determine which color to spawn
            Color ingredientColor = GetNextIngredientColor(blueCount, redCount, yellowCount);

            // Instantiate prefab at the spawn point
            GameObject ingred = Instantiate(smellIngredient, spawnPoint, Quaternion.identity);
            GameObject ingredSmell = Instantiate(smellSprite, ingred.transform);
            ingredSmell.transform.localPosition = new Vector3(0f, 0.7f, 0f); // Adjust the offset as needed
            ingredSmell.GetComponent<SpriteRenderer>().color = ingredientColor;

            // Update the counts based on the color spawned
            if (ingredientColor == Color.blue)
            {
                blueCount++;
            }
            else if (ingredientColor == Color.red)
            {
                redCount++;
            }
            else if (ingredientColor == Color.yellow)
            {
                yellowCount++;
            }

            // Remove the used spawn point from the list
            spawnPoints.RemoveAt(randomIndex);

            spawnedCount++;
        }

        // Check if there are no ingredients left of any required color
        if (!HasRequiredColors(blueCount, redCount, yellowCount))
        {
            // Trigger game over
            TimerZero();
        }
    }

    bool HasRequiredColors(int blueCount, int redCount, int yellowCount)
    {
        foreach (Color requiredColor in requiredColors)
        {
            if ((requiredColor == Color.blue && blueCount == 0) ||
                (requiredColor == Color.red && redCount == 0) ||
                (requiredColor == Color.yellow && yellowCount == 0))
            {
                return false;
            }
        }
        return true;
    }



    Color GetNextIngredientColor(int blueCount, int redCount, int yellowCount)
    {
        // If there are fewer than 3 blue prefabs, spawn blue
        if (blueCount < 3)
        {
            return Color.blue;
        }
        // If there are fewer than 3 red prefabs, spawn red
        else if (redCount < 3)
        {
            return Color.red;
        }
        // If there are fewer than 3 yellow prefabs, spawn yellow
        else if (yellowCount < 3)
        {
            return Color.yellow;
        }
        // Otherwise, spawn a random color
        else
        {
            int randomIndex = Random.Range(0, ingredientColors.Length);
            return ingredientColors[randomIndex];
        }
    }





    void generateReferenceSmell()
    {
        int randomIndex = Random.Range(0, referenceColors.Length);
        Color randomColor = referenceColors[randomIndex];
        referenceSmellSprite.color = randomColor;

        //Color.green, new Color(0.5f, 0, 0.5f), new Color(1, 0.5f, 0)

        if(randomColor == Color.green)
        {
            requiredColors[0] = Color.blue;
            requiredColors[1] = Color.yellow;
        } else if (randomColor == new Color(0.5f, 0, 0.5f)) //purple
        {
            requiredColors[0] = Color.blue;
            requiredColors[1] = Color.red;
        }
        else if(randomColor == new Color(1, 0.5f, 0)) //orange
        {
            requiredColors[0] = Color.yellow;
            requiredColors[1] = Color.red;
        }

    }

    Color generateIngredientColor()
    {
        int randomIndex = Random.Range(0, ingredientColors.Length);
        Color randomColor = ingredientColors[randomIndex];
        return randomColor;
    }

    public void TimerZero()
    {

        // Check if the game is already over
        if (gameOver)
        {
            return; // return if the game is already over
        }

        // Set game over flag
        gameOver = true;

        // Debug.Log("Game Over");

        //Activate the game over panel 

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            // Load the new scene after 3 seconds
            Invoke("LoadMainMenu", 3f);

        }
        else
        {
            Debug.LogError("Game Over Panel reference is missing!");
        }

    }

    public void LoadMainMenu()
    {
        // Load the Main menu scene by name 
        SceneManager.LoadScene("MainMenu");
    }


    public void SpawnIngredients()
    {

        Instantiate(ingredientsPrefab, new Vector2(-50f, 7f), Quaternion.identity);
        Instantiate(ingredientsPrefab, new Vector2(50f, -23f), Quaternion.identity);
        Instantiate(ingredientsPrefab, new Vector2(38f, 35f), Quaternion.identity);

        //}

    }

 
    public void DestroyAllIngredients()
    {
        GameObject[] ingredients = GameObject.FindGameObjectsWithTag("smellIngredient");

        foreach (GameObject ingredient in ingredients)
        {
            Destroy(ingredient);
        }
    }


}
