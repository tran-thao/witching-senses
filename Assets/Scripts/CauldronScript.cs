using UnityEngine;
using System.Collections.Generic;

public class CauldronScript : MonoBehaviour
{
    private SmellGameManager gameManagerScript;
    SpriteRenderer mySmellSprite;
    SpriteRenderer referenceColor;
    SmellPopUp smellPopUp;

    void Start()
    {
        gameManagerScript = GameObject.Find("smellGameManager").GetComponent<SmellGameManager>();
        smellPopUp = GameObject.Find("Canvas").GetComponent<SmellPopUp>();
        
        mySmellSprite = GameObject.Find("mySmell").GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {

            if (!gameManagerScript.gameStarted && gameManagerScript.testGameDone)
            {
                Debug.Log("startsmellgame");
                gameManagerScript.startSmellGame();
                gameManagerScript.gameStarted = true;
            }

            else
            {
                Debug.Log("else");
                if (collision.gameObject.transform.childCount > 0)
                {
                    Color smellIngredientColor = collision.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>().color;

                    if (!gameManagerScript.testGameDone)
                    {
                        Debug.Log("testgame done");
                        mySmellSprite.color = Color.yellow;
                        gameManagerScript.invokeMethod("HandleTestGame", 1.5f);
                        DestroyObject(collision.gameObject);
                    }

                    if (gameManagerScript.gameStarted)
                    {
                        if (checkToReplace(smellIngredientColor))
                        {
                            Debug.Log("replace");
                            mySmellSprite.color = smellIngredientColor;

                        } else {
                            Debug.Log("mix");
                            mySmellSprite.color = mixColor(smellIngredientColor);

                            if (checkCorrectColor(mySmellSprite.color))
                            {
                                handleSuccess();
                               
                            } else
                            {
                                Invoke("handleWrongColor", 1f);
                                //handleWrongColor();
                            }
                        }

                        updateColorCount();
                        DestroyObject(collision.gameObject);

                    } else {
                        //Debug.Log("This GameObject does not have any child objects.");
                    }
                }
            }
        }
    }


    bool checkToReplace(Color color)
    {
        if(mySmellSprite.color == Color.white || mySmellSprite.color == color || mySmellSprite.color == Color.green || mySmellSprite.color == new Color(0.5f, 0, 0.5f) || mySmellSprite.color ==  new Color(1, 0.5f, 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    Color mixColor(Color color)
    {

        //Debug.Log("mixColor");
        if(color == Color.yellow)
        {
            if(mySmellSprite.color == Color.blue)
            {
                return Color.green;
            } else if (mySmellSprite.color == Color.red)
            {
                return new Color(1, 0.5f, 0); //orange
            }

        }
        else if (color == Color.blue)
        {
            if (mySmellSprite.color == Color.yellow)
            {
                return Color.green;
            }
            else if (mySmellSprite.color == Color.red)
            {
                return new Color(0.5f, 0, 0.5f); //purple
            }

        }
        else if (color == Color.red)
        {
            if (mySmellSprite.color == Color.yellow)
            {
                return new Color(1, 0.5f, 0); //orange
            }
            else if (mySmellSprite.color == Color.blue)
            {
                return new Color(0.5f, 0, 0.5f); //purple
            }
        }

        return color;
    }

    private void updateColorCount()
    {
        if (mySmellSprite.color == Color.blue)
        {
            gameManagerScript.blueCount--;
        }
        else if (mySmellSprite.color == Color.red)
        {
            gameManagerScript.redCount--;
        }
        else if (mySmellSprite.color == Color.yellow)
        {
            gameManagerScript.yellowCount--;
        }
    }

    private bool checkCorrectColor(Color color)
    {
        //Debug.Log("color mixed: " + color);
        //Debug.Log("ref color: " + referenceColor);
        if(color == gameManagerScript.referenceSmellSprite.color)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void DestroyObject(GameObject gameObject)
    {
        // compare children of game object
        for (var i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }

    private void handleWrongColor()
    {
        Debug.Log("Wrong Color");
        smellPopUp.ShowPopUp(smellPopUp.wrongPanel);
        mySmellSprite.color = Color.white;
    }

    private void handleSuccess()
    {
        gameManagerScript.success = true;
        smellPopUp.ShowPopUp(smellPopUp.successPanel);
        Debug.Log("Success");
        gameManagerScript.DestroyAllIngredients();
        gameManagerScript.SpawnIngredients();
    }
}


