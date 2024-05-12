using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMain : MonoBehaviour
{
    public void LoadGameScene()
    {
        Debug.Log("Attempting to load MainMenu scene.");
        SceneManager.LoadScene("Levels/Scenes/MainMenu");
    }


}
