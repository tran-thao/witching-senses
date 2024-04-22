using System.Collections.Generic;
using UnityEngine;

public class MusicButtonManager : MonoBehaviour
{
    public List<GameObject> musicButtons;
    public PopUpScript popUpScript; // Reference to the PopUpScript
    public GameObject ingredientsPrefab;
    private List<int> sequence = new List<int>();
    private int currentIndex = 0;
    private bool playerTurn = false;
    private bool gameCompleted = false;
   

    void Start()
    {
        GenerateSequence();
        Invoke("StartPlayingSequence", 3f);
    }

    void StartPlayingSequence()
    {
        StartCoroutine(PlaySequence());
    }

    void Update()
    {
        // Player turn is handled by the MusicButtonScript
    }

    void GenerateSequence()
    {
        sequence.Clear();
        HashSet<int> usedIndices = new HashSet<int>();

        while (sequence.Count < 5)
        {
            int index = Random.Range(0, musicButtons.Count);

            // Check if the index is already used
            if (!usedIndices.Contains(index))
            {
                sequence.Add(index);
                usedIndices.Add(index);
            }
        }
    }

    System.Collections.IEnumerator PlaySequence()
    {
        foreach (int index in sequence)
        {
            musicButtons[index].GetComponent<MusicButtonScript>().Highlight();
            yield return new WaitForSeconds(1.5f);
        }
        playerTurn = true;
    }

    public void CheckInput(GameObject musicButton)
    {
        if (playerTurn)
        {
            if (musicButtons[sequence[currentIndex]] == musicButton)
            {
                currentIndex++;
                if (currentIndex >= sequence.Count)
                {
                    // Player completed the sequence
                    Debug.Log("Good job!");
                    popUpScript.ShowMessage();
                    gameCompleted = true;
                    SpawnIngredients();
                    ResetGame();
                }
            }
            else
            {
                // Wrong input, restart the sequence
                Debug.Log("Wrong input");
                popUpScript.ShowWrongPopUp();
                StartCoroutine( ResetGame());
            }
        }
    }

    void SpawnIngredients()
    {
        //HashSet<Vector2> usedPositions = new HashSet<Vector2>(); // To keep track of used positions

        //for (int i = 0; i < 3; i++)
            //{
            //    Vector2 randomPosition;
            //    do
            //    {
            //        // Calculate random position within the screen boundaries
            //        randomPosition = new Vector2(Random.Range(-65f, 65f), Random.Range(-35f, 35f));
            //    } while (usedPositions.Contains(randomPosition)); // Keep generating new positions until a unique one is found

            //    usedPositions.Add(randomPosition); // Add the new position to the set of used positions

            //    // Instantiate Ingredients prefab at the random position
            //    Instantiate(ingredientsPrefab, randomPosition, Quaternion.identity);
            Instantiate(ingredientsPrefab, new Vector2(-60f, 0f), Quaternion.identity);
            Instantiate(ingredientsPrefab, new Vector2(-3f, -20f), Quaternion.identity);
            Instantiate(ingredientsPrefab, new Vector2(65f, -12f), Quaternion.identity);

        //}

    }



    System.Collections.IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(3f);
        currentIndex = 0;
        playerTurn = false;

        // Check if the game is completed before generating a new sequence
        if (!gameCompleted)
        {
            GenerateSequence();
            StartCoroutine(PlaySequence());
        }
        else
        {
            gameCompleted = false; // Reset gameCompleted flag
        }
    }

}
