using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstScene : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Tutorial Level");  
    }
}
