using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ChestScript : MonoBehaviour
    {
        public string chestType;  // Type of chest (hot, cold, vibration)
        private bool canBeOpened = true;  // Flag to allow chest opening
        public LevelManagerTouch levelManagerTouch;  // Reference to the LevelManager script
        


    void Start()
        {
        levelManagerTouch = GameObject.Find("LevelManagerTouch").GetComponent<LevelManagerTouch>();
       
    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (canBeOpened && other.CompareTag("Player"))
            {
            
            // Check if the player is holding a key
            if (levelManagerTouch.IsKeyHeld())
                {
                    // Check if the key's sensation matches the chest's sensation
                    string heldKeyType = levelManagerTouch.GetHeldKeyType();  // Get the type of held key
                    if (heldKeyType == chestType)
                    {
                        OpenChest();  // Open the chest
                        levelManagerTouch.ChestOpened();  // Notify LevelManager that a chest is opened
                        ResetKeyHeld();  // Reset keyHeld status to false
                }
                    else
                    {
                        Debug.Log("Wrong chest! Try another key.");
                        ResetKeyHeld();  // Reset keyHeld status to false
                                         //keyScript.ResetToInitialPosition();  // Reset the key to initial position

                    // Show feedback for wrong chest attempt

                        Debug.Log("Wrong chest! Key reset.");

                    levelManagerTouch.ResetCollectedKey();


                }
                }
            }
        }

        void OpenChest()
        {
            
            Debug.Log("Chest opened! You found the right key.");
            canBeOpened = false;  // Prevent further openings
                             // Play chest opening animation or effects

    }

    public void ResetKeyHeld()
    {
        levelManagerTouch.SetKeyHeld(false);  // Reset keyHeld status to false
    }

  


}

