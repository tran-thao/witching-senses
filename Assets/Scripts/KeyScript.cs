using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
   
    public string keyType;  // To identify the key type (vibration, cold, hot)
    public LevelManagerTouch levelManagerTouch;  // Reference to the GameManager script
    private bool touchedByPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        levelManagerTouch = GameObject.Find("LevelManagerTouch").GetComponent<LevelManagerTouch>();
        KeyInfo keyInfo = GetComponent<KeyInfo>();
        if (keyInfo != null)
        {
            keyType = keyInfo.keyType;
            Debug.Log("Key Type: " + keyType);  // Debug log to check keyType
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Player triggered key: " + keyType);
            touchedByPlayer = true;

            
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
       
        // Notify GameManager about the key collection
        if (levelManagerTouch != null)
        {
            levelManagerTouch.KeyCollected(keyType);  // Notify GameManager about the collected key
        }

        Destroy(gameObject);  // Destroy the key object after collection
    }
}
