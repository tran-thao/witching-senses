using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
   
    public string keyType;  // To identify the key type (vibration, cold, hot)
    public LevelManagerTouch levelManagerTouch;  // Reference to the LevelManager script
    private bool touchedByPlayer = false; //check the collision
    private bool canBePickedUp = true;  // Flag to allow key pickup
    public  UIManager uiManager;//reference to UIManager script


    // Start is called before the first frame update
    void Start()
    {
        levelManagerTouch = GameObject.Find("LevelManagerTouch").GetComponent<LevelManagerTouch>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        KeyInfo keyInfo = GetComponent<KeyInfo>();
        if (keyInfo != null)
        {
            keyType = keyInfo.keyType;
            Debug.Log("Key Type: " + keyType);  // Debug log to check keyType
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canBePickedUp && other.CompareTag("Player"))
        {

            Debug.Log("Player triggered key: " + keyType);
            touchedByPlayer = true;

            // Check if the player is not already holding a key
            if (!uiManager.IsKeyHeld())
            {
                // Play corresponding sensation (vibration, hot, cold)
                switch (keyType)
                {
                    case "Vibration":
                        // Play vibration effect
                        Debug.Log("Vibration key");
                        break;
                    case "Hot":
                        // Play hot effect
                        Debug.Log("Hot key");
                        break;
                    case "Cold":
                        // Play cold effect
                        Debug.Log("Cold key");
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            touchedByPlayer = false;
        }
    }

    void Update()
    {
        if (touchedByPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            CollectKey();
        }
    }

    void CollectKey()
    {
        Debug.Log(uiManager.IsKeyHeld());

        // Notify GameManager about the key collection
        if (!uiManager.IsKeyHeld())
        {
            canBePickedUp = false;  // Prevent further pickups
            // Set the keyHeld status to true and store the held key type
            uiManager.SetKeyHeld(true);

            if (levelManagerTouch != null)
            {
                levelManagerTouch.KeyCollected(keyType);  // Notify LevelManager about the collected key
            }

            Destroy(gameObject);  // Destroy the key object after collection
        }
    }
}
