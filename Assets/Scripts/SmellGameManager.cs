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
    public bool testGameDone;
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
    public List<Sprite> smellSpritePrefabs;
    private List<Sprite> shuffledSprites = new List<Sprite>(); // Shuffled list of sprites

    public int blueCount = 0;
    public int redCount = 0;
    public int yellowCount = 0;

    void Start()
    {
        ShuffleSprites();

        gameStarted = false;
        testGameDone = false;
        referenceSmellSprite = GameObject.Find("referenceSmell").GetComponent<SpriteRenderer>();
        mySmellSprite = GameObject.Find("mySmell").GetComponent<SpriteRenderer>();

        // Define spawn points
        spawnPoints.Add(new Vector3(-48.2f, -20.6f, -2f));
        spawnPoints.Add(new Vector3(-48.9f, 20.3f, -2f));
        spawnPoints.Add(new Vector3(-36.7f, 2.3f, -2f));
        spawnPoints.Add(new Vector3(-3.7f, 21f, -2f));
        spawnPoints.Add(new Vector3(21.92376f, 26.7061f, -2f));
        spawnPoints.Add(new Vector3(27.1f, -3.8f, -2f));
        spawnPoints.Add(new Vector3(47.3f, -20.6f, -2f));
        spawnPoints.Add(new Vector3(-25.5f, 27.2f, -2f));
        spawnPoints.Add(new Vector3(-17f, -16.5f, -2f));



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
        if (!success && gameStarted && !HasIngredientsLeft())
        {
            Invoke("TimerZero", 1f);
        }


        if (ingredientsCollected >= 3)
        {
            successPanel.SetActive(true);

            Invoke("LoadLevelTouch", 2f);
        }
    }

    bool HasIngredientsLeft()
    {
        // Find all GameObjects with the "smellIngredient" tag
        GameObject[] ingredientClones = GameObject.FindGameObjectsWithTag("smellIngredient");

        // Check if there are any clones left in the scene
        return ingredientClones.Length > 0;
    }


    public void startSmellGame()
    {
        gameStarted = true;
        generateReferenceSmell();
        SpawnPrefabs();
    }

    void ShuffleSprites()
    {
        shuffledSprites.AddRange(smellSpritePrefabs); // Copy sprites to shuffled list
        int n = shuffledSprites.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Sprite value = shuffledSprites[k];
            shuffledSprites[k] = shuffledSprites[n];
            shuffledSprites[n] = value;
        }
    }

    Sprite GetNextSprite()
    {
        if (shuffledSprites.Count == 0)
        {
            Debug.LogError("No more sprites available!");
            return null;
        }

        Sprite nextSprite = shuffledSprites[0];
        shuffledSprites.RemoveAt(0);
        return nextSprite;
    }
    
    void SpawnPrefabs()
    {
        int spawnedCount = 0;

        // Variables to track the number of prefabs of each color


        while (spawnedCount < numberOfPrefabs && spawnPoints.Count > 0)
        {

            List<Sprite> usedSprites = new List<Sprite>();

            // Get a random index from the spawnPoints list
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Vector3 spawnPoint = spawnPoints[randomIndex];

            // Determine which color to spawn
            Color ingredientColor = GetNextIngredientColor(blueCount, redCount, yellowCount);

            //// Get a random sprite from the list of sprites
            //Sprite randomSprite = GetRandomSprite(usedSprites);

            // Get the next sprite from the shuffled list
            Sprite randomSprite = GetNextSprite();

            // Check if the sprite is null (no more sprites available)
            if (randomSprite == null)
            {
                Debug.LogError("No more sprites available to spawn!");
                return;
            }

            // Instantiate prefab at the spawn point
            GameObject ingred = Instantiate(smellIngredient, spawnPoint, Quaternion.identity);
            GameObject ingredSmell = Instantiate(smellSprite, ingred.transform);
            ingredSmell.transform.localPosition = new Vector3(0f, 0.7f, 0f); // Adjust the offset as needed
            ingredSmell.GetComponent<SpriteRenderer>().color = ingredientColor;

            // Assign the random sprite to the sprite renderer
            ingred.GetComponent<SpriteRenderer>().sprite = randomSprite;

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

        
    }



    Sprite GetRandomSprite(List<Sprite> usedSprites)
    {
        // Get a random index for the list of sprites
        int randomIndex = Random.Range(0, smellSpritePrefabs.Count);

        // Check if the sprite has already been used
        while (usedSprites.Contains(smellSpritePrefabs[randomIndex]))
        {
            // If the sprite has been used, get another random index
            randomIndex = Random.Range(0, smellSpritePrefabs.Count);
        }

        // Add the used sprite to the list
        usedSprites.Add(smellSpritePrefabs[randomIndex]);

        // Return the random sprite
        return smellSpritePrefabs[randomIndex];
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

    private void LoadLevelTouch()
    {
        SceneManager.LoadScene("LevelTouch");
    }


    public void SpawnIngredients()
    {

        Instantiate(ingredientsPrefab, new Vector2(-50f, 7f), Quaternion.identity);
        Instantiate(ingredientsPrefab, new Vector2(50f, -23f), Quaternion.identity);
        Instantiate(ingredientsPrefab, new Vector2(38f, 35f), Quaternion.identity);

    }

 
    public void DestroyAllIngredients()
    {
        GameObject[] ingredients = GameObject.FindGameObjectsWithTag("smellIngredient");

        foreach (GameObject ingredient in ingredients)
        {
            Destroy(ingredient);
        }
    }


    public void HandleTestGame()
    {
            testGameDone = true;
            SmellPopUp popUp = GameObject.Find("Canvas").GetComponent<SmellPopUp>();
            popUp.ShowPopUp(popUp.testGameDone);
            mySmellSprite.color = Color.white;
            Destroy(GameObject.Find("testIngredient"));
            
            startSmellGame();
    }


    public void invokeMethod(string method, float time)
    {
        Invoke(method, time);
    }


}
