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

    private List<string> words = new List<string>()
    {
        "spiderweb dewdrops",
        "rainbow beam",
        "butterflywing pattern",
        "last sunray",
        "moonflower petal",
    };

    private string currentWord;
    private string currentAnagram;

    void Start()
    {
        ChooseRandomWord();
        UpdateAnagramText();
        userInputField.onEndEdit.AddListener(delegate { CheckAnswer(); });
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
        if (userAnswer == currentWord.Replace(" ", ""))
        {
            resultText.text = "Correct!";
        }
        else
        {
            resultText.text = "Incorrect! Try again.";
        }
    }
}
