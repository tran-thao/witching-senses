using UnityEngine;
using System.Collections.Generic;

public class CauldronScript : MonoBehaviour
{
    private SmellGameManager gameManagerScript;
    Color myColor;
    Color referenceColor;


    void Start()
    {
        gameManagerScript = GameObject.Find("smellGameManager").GetComponent<SmellGameManager>();
        referenceColor = gameManagerScript.referenceSmell.GetComponent<SpriteRenderer>().color;
        myColor = GameObject.Find("mySmell").GetComponent<SpriteRenderer>().color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player collide");
            if (!gameManagerScript.gameStarted)
            {
                gameManagerScript.startSmellGame();
                gameManagerScript.gameStarted = true;
            }
           
            
        }

        if (collision.gameObject.tag == "smellIngredient")
        {
            Debug.Log("ingredient collide");
            Color smellIngredientColor = collision.gameObject.GetComponentInChildren<SpriteRenderer>().color;
            Debug.Log("smell color: " + smellIngredientColor);

            if (!gameManagerScript.gameStarted)
            {

                //-Switch cases:
                //-Red + red = red
                //- Blue + blue = blue
                //- Yellow + yellow = yellow

                //- Red + blue = violet
                //- Blue + yellow = green
                //- Red + yellow = orange

                //if cauldron color is white, red,blue,yellow then just replace
                //else if color is purple, green,orange, then mix according to cauldron color

                //if ingred color is red, either replace if cauldron color is red/green/purple/orange or mix if cauldron color is blue or yellow,
                //if ingred color s yellow, either replace if cauldron color is yellow/green/purple/orange or mix if cauldron color is red or blue
                //if ingred color is blue either replace if cauldron color is blue/green/purple/orange or mix if cauldron color is red or yellow


                if (smellIngredientColor == Color.red)
                {
                    if (checkToReplace(smellIngredientColor))
                    {
                        myColor = smellIngredientColor;
                    }
                    else
                    {
                        mixColor(smellIngredientColor);
                    }
                }
            }
        }
    }

    bool checkToReplace(Color color)
    {
        if(myColor == Color.white || myColor == color || myColor == Color.green || myColor == new Color(0.5f, 0, 0.5f) || myColor ==  new Color(1, 0.5f, 0))
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

        Debug.Log("mixColor");
        if(color == Color.yellow)
        {
            if(myColor == Color.blue)
            {
                return Color.green;
            } else if (myColor == Color.red)
            {
                return new Color(1, 0.5f, 0); //orange
            }

        }
        else if (color == Color.blue)
        {
            if (myColor == Color.yellow)
            {
                return Color.green;
            }
            else if (myColor == Color.red)
            {
                return new Color(0.5f, 0, 0.5f); //purple
            }

        }
        else if (color == Color.red)
        {
            if (myColor == Color.yellow)
            {
                return new Color(1, 0.5f, 0); //orange
            }
            else if (myColor == Color.blue)
            {
                return new Color(0.5f, 0, 0.5f); //purple
            }
        }

        return color;
    }
}
