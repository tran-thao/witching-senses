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

    public void LoadLevel1()
    {
        SceneManager.LoadScene("SampleScene1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Smell");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("LevelTouch");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("LevelSight");
    }

}
