using UnityEngine;
using System.Collections.Generic;

public class SmellGameManager : MonoBehaviour
{
    public GameObject smellIngredient;
    public GameObject smellSprite;
    public float spawnRadius = 30f;
    public int numberOfPrefabs = 6;
    public bool gameStarted;
    public SpriteRenderer referenceSmellSprite;
    public SpriteRenderer mySmellSprite;

    public Color[] referenceColors = { Color.green, new Color(0.5f, 0, 0.5f), new Color(1, 0.5f, 0) }; // green, purple, orange
    public Color[] ingredientColors = { Color.blue, Color.red, Color.yellow };

    void Start()
    {
        gameStarted = false;
        referenceSmellSprite = GameObject.Find("referenceSmell").GetComponent<SpriteRenderer>();
        mySmellSprite = GameObject.Find("mySmell").GetComponent<SpriteRenderer>();

        //SpawnPrefabs();
    }

    private void Update()
    {

    }

    public void startSmellGame()
    {
        generateReferenceSmell();
        SpawnPrefabs();
       
    }

    void SpawnPrefabs()
    {
        List<Vector3> spawnPoints = new List<Vector3>();
        int spawnedCount = 0;

        // Define exclusion zones (empty GameObjects)
        GameObject exclusionZone1 = GameObject.Find("referenceCauldron");
        GameObject exclusionZone2 = GameObject.Find("myCauldron");

        while (spawnedCount < numberOfPrefabs)
        {
            Vector3 spawnPoint = Vector3.zero;

            bool validSpawnPoint = true;

            do
            {
                // Generate a random spawn point
                spawnPoint = new Vector3(Random.Range(-58f, 58f), Random.Range(-22f, 35f), -2f);

                // Check if the spawn point falls within any exclusion zone
                if (Vector3.Distance(spawnPoint, exclusionZone1.transform.position) < spawnRadius ||
                    Vector3.Distance(spawnPoint, exclusionZone2.transform.position) < spawnRadius)
                {
                    validSpawnPoint = false; // Spawn point is within an exclusion zone, not valid
                }
                else
                {
                    validSpawnPoint = true; // Spawn point is outside all exclusion zones, valid
                }

            } while (!validSpawnPoint); // Repeat until a valid spawn point is found

            // Instantiate prefab at the valid spawn point
            GameObject ingred = Instantiate(smellIngredient, spawnPoint, Quaternion.identity);
            GameObject ingredSmell = Instantiate(smellSprite, ingred.transform);
            ingredSmell.transform.localPosition = new Vector3(0f, 0.5f, 0f); // Adjust the offset as needed
            ingredSmell.GetComponent<SpriteRenderer>().color = generateIngredientColor();
            spawnedCount++;
        }
    }


    void generateReferenceSmell()
    {
        int randomIndex = Random.Range(0, referenceColors.Length);
        Color randomColor = referenceColors[randomIndex];
        referenceSmellSprite.color = randomColor;
        //Debug.Log("Random color: " + randomColor);
    }

    Color generateIngredientColor()
    {
        int randomIndex = Random.Range(0, referenceColors.Length);
        Color randomColor = ingredientColors[randomIndex];
        return randomColor;
    }
}
