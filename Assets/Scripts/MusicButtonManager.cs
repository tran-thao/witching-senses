using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MusicButtonManager : MonoBehaviour
{
    public List<GameObject> musicButtons;
    public PopUpScript popUpScript; // Reference to the PopUpScript
    public GameObject ingredientsPrefab;
    private List<int> sequence = new List<int>();
    private int currentIndex = 0;
    private bool playerTurn = false;
    public bool gameCompleted = false;
    public GameObject pianoKeys;
    public GameObject princess;
   

    void Start()
    {
        GenerateSequence();
        //Invoke("StartPlayingSequence", 3f);
    }

    public void StartPlayingSequence()
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

    IEnumerator PlaySequence()
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
                    gameCompleted = true;
                    StartCoroutine(handleGameCompleted(1f));
                }
            }
            else
            {
                // Wrong input, restart the sequence
                Debug.Log("Wrong input");
                popUpScript.ShowPopUp(popUpScript.wrongNotePopUpPanel);
                princess.transform.position = new Vector2(-4.3f, -1.3f);
                StartCoroutine(ResetGame());
            }
        }
    }

    private void SpawnIngredients()
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
            Instantiate(ingredientsPrefab, new Vector2(-50f, 7f), Quaternion.identity);
            Instantiate(ingredientsPrefab, new Vector2(50f, -23f), Quaternion.identity);
            Instantiate(ingredientsPrefab, new Vector2(38f, 35f), Quaternion.identity);

        //}

    }


    private IEnumerator ResetGame()
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

    private IEnumerator handleGameCompleted(float delay)
    {
        yield return new WaitForSeconds(delay);
        pianoKeys.SetActive(false);
        popUpScript.ShowPopUp(popUpScript.successPopUpPanel);
        SpawnIngredients();
    }

}
