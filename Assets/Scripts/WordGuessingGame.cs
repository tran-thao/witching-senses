using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGuessingGame : MonoBehaviour
{
    public Text anagramText;
    public InputField userInputField;
    public Text resultText;

    private List<string> words = new List<string>()
    {
        "spiderweb dewdrops",
        "rainbow beam",
        "orange",
        "grape",
        "melon",
        "strawberry",
        // Add more words as needed
    };

    private string currentWord;
    private string currentAnagram;

    void Start()
    {
        ChooseRandomWord();
        UpdateAnagramText();
        userInputField.onEndEdit.AddListener(delegate { CheckAnswer(); }); // Listen for user pressing Enter
    }

    void ChooseRandomWord()
    {
        currentWord = words[Random.Range(0, words.Count)];
        currentAnagram = ShuffleWord(currentWord);
    }

    string ShuffleWord(string word)
    {
        char[] chars = word.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            char temp = chars[i];
            int randomIndex = Random.Range(i, chars.Length);
            chars[i] = chars[randomIndex];
            chars[randomIndex] = temp;
        }
        return new string(chars);
    }

    void UpdateAnagramText()
    {
        anagramText.text = currentAnagram;
    }

    public void CheckAnswer(string input = null)
    {
        string userAnswer = (input != null) ? input.ToLower() : userInputField.text.ToLower();
        if (userAnswer == currentWord)
        {
            resultText.text = "Correct!";
        }
        else
        {
            resultText.text = "Incorrect! Try again.";
        }
    }
}
