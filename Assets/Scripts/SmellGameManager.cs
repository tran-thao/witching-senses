using UnityEngine;
using System.Collections.Generic;

public class SmellGameManager : MonoBehaviour
{
    public GameObject smellIngredient;
    public GameObject smellSprite;
    public float spawnRadius = 10f;
    public int numberOfPrefabs = 6;
    public bool gameStarted;
    public GameObject referenceSmell;

    public Color[] referenceColors = { Color.green, new Color(0.5f, 0, 0.5f), new Color(1, 0.5f, 0) }; // green, purple, orange
    public Color[] ingredientColors = { Color.blue, Color.red, Color.yellow };

    void Start()
    {
        gameStarted = false;
        referenceSmell = GameObject.Find("referenceSmell");
        //SpawnPrefabs();
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

        while (spawnedCount < numberOfPrefabs)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(-58f, 58f), Random.Range(-22f, 35f), -2f);

            bool validSpawnPoint = true;
            foreach (Vector3 existingSpawnPoint in spawnPoints)
            {
                if (Vector3.Distance(spawnPoint, existingSpawnPoint) < spawnRadius)
                {
                    validSpawnPoint = false;
                    break;
                }
            }

            if (validSpawnPoint)
            {
                GameObject ingred = Instantiate(smellIngredient, spawnPoint, Quaternion.identity);
               //Debug.Log("ingred pos: " + ingred.transform.position);
                GameObject ingredSmell = Instantiate(smellSprite, ingred.transform);
                //Debug.Log("ingredSmell local pos: " + ingredSmell.transform.localPosition);

                // Set the initial local position of ingredSmell relative to ingred
                ingredSmell.transform.localPosition = new Vector3(0f, 0.5f, 0f); // Adjust the offset as needed

                //Debug.Log("ingredSmell local pos: " + ingredSmell.transform.localPosition);
                ingredSmell.GetComponent<SpriteRenderer>().color = generateIngredientColor();
                spawnedCount++;
                spawnPoints.Add(spawnPoint);
            }
        }
    }

    void generateReferenceSmell()
    {
        int randomIndex = Random.Range(0, referenceColors.Length);
        Color randomColor = referenceColors[randomIndex];
        referenceSmell.GetComponent<SpriteRenderer>().color = randomColor;
        //Debug.Log("Random color: " + randomColor);
    }

    Color generateIngredientColor()
    {
        int randomIndex = Random.Range(0, referenceColors.Length);
        Color randomColor = ingredientColors[randomIndex];
        return randomColor;
    }
}
