using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordGuessingGame : MonoBehaviour
{
    public TMP_Text anagramText;
    public TMP_InputField userInputField;
    public TMP_Text resultText;
    public Canvas ShowAnagram;

    private List<string> words = new List<string>()
    {
        "spiderweb dewdrops",
        "rainbow beam",
        "butterflywing pattern",
        "last sunray",
        "moonflower petals",
        "aurora essence",
        "heartbreak tears",
        "mirage mist",
        "shadow veil",
        "eternal frost",
        "unicorn mane",
        "enigma berries",
        "starlight dust",
        "mountain wildflowers",
        "flowing lava",
    };

    private string currentWord;
    private string currentAnagram;

    void Start()
    {
        ChooseRandomWord();
        UpdateAnagramText();
        userInputField.onEndEdit.AddListener(delegate { CheckAnswer(); });
        ShowAnagram = GameObject.Find("AnagramCanvas").GetComponent<Canvas>();
    }

    void ChooseRandomWord()
    {
        currentWord = words[UnityEngine.Random.Range(0, words.Count)];
        currentAnagram = GetAnagram(currentWord);
    }

    string GetAnagram(string word)
    {
        string[] wordArray = word.Split(' ');
        List<string> shuffledWords = new List<string>();

        foreach (string w in wordArray)
        {
            char[] chars = w.ToCharArray();
            List<char> letters = new List<char>(chars);

            ShuffleList(letters);
            shuffledWords.Add(new string(letters.ToArray()));
        }

        return string.Join(" ", shuffledWords);
    }

    void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void UpdateAnagramText()
    {
        anagramText.text = currentAnagram;
    }

    public void CheckAnswer(string input = null)
    {
        string userAnswer = (input != null) ? input.ToLower() : userInputField.text.ToLower();
        string[] correctAnswerWords = currentWord.Split(' ');

        bool isCorrect = true;

        // Check each word in the correct answer
        foreach (string word in correctAnswerWords)
        {
            if (!userAnswer.Contains(word))
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            resultText.text = "Correct!";
            Invoke("togglecanvas", 1.5f);
            Invoke("HideResultText", 1.5f);
            Invoke("ShowNewAnagram", 1.8f);
            GameObject.Find("SightGameManager").GetComponent<SightGameManager>().AnagramSolved();

        }
        else
        {
            resultText.text = "Incorrect! Try again.";
        }

        userInputField.text = "";
    }

    void togglecanvas()
    {
        ShowAnagram.enabled = false;
    }

    void HideResultText()
    {
        resultText.text = "";
    }

    void ShowNewAnagram()
    {
        ChooseRandomWord();
        UpdateAnagramText();
    }

}
