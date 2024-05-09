using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
   
    public string keyType;  // To identify the key type (vibration, cold, hot)
    public LevelManagerTouch levelManagerTouch;  // Reference to the LevelManager script
    private bool touchedByPlayer = false; //check the collision
    private bool canBePickedUp = true;  // Flag to allow key pickup
    private Vector3 initialPosition;  // Initial position of the key
    //private ParticleSystem particlesSys;  // Reference to the Particle System component 


    // Start is called before the first frame update
    void Start()
    {
        levelManagerTouch = GameObject.Find("LevelManagerTouch").GetComponent<LevelManagerTouch>();

        initialPosition = transform.position;  // Store initial position
        Debug.Log(initialPosition);

        KeyInfo keyInfo = GetComponent<KeyInfo>();
        if (keyInfo != null)
        {
            keyType = keyInfo.keyType;
            Debug.Log("Key Type: " + keyType);  // Debug log to check keyType
        }

        // Get the Particle System component from the GameObject
 
        // Disable the particle system at the start
        
            GetComponent<ParticleSystem>().Stop();  // Stop the particle system (if it's playing)
           // particlesSys.gameObject.SetActive(false);  // Deactivate the GameObject
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canBePickedUp && other.CompareTag("Player"))
        {

            Debug.Log("Player triggered key: " + keyType);
            touchedByPlayer = true;

            ActivateParticleSystem();


            // Check if the player is not already holding a key
            if (!levelManagerTouch.IsKeyHeld())
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
            

           // Invoke("ResetToInitialPosition", 3f); //testing reset key option
           
        }
    }

    void CollectKey()
    {
        Debug.Log(levelManagerTouch.IsKeyHeld());
        if (levelManagerTouch != null)
        {
            // Notify GameManager about the key collection
            if (!levelManagerTouch.IsKeyHeld())
            {
                canBePickedUp = false;  // Prevent further pickups

                // Set the keyHeld status to true and store the held key type
                levelManagerTouch.SetKeyHeld(true);// Set key held to true
                levelManagerTouch.SetHeldKeyType(keyType);// Set key Type 



                //Destroy(gameObject);  // Destroy the key object after collection

                levelManagerTouch.SetCollectedKey(this);  //Send the collected key to level Manager

                
                //Disable the renderer instead of destroying 

                // Disable the key's renderer and collider
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
            }
        }

        
    }

    public void ResetToInitialPosition()
    {
        // Enable the key's renderer and collider
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        // Reset key to initial position
        // transform.position = initialPosition;
        //levelManagerTouch.SetKeyHeld(true); // Reset keyHeld status
        canBePickedUp = true;
    }

    void ActivateParticleSystem()
    {
        GetComponent<ParticleSystem>().Play();
    }


}
