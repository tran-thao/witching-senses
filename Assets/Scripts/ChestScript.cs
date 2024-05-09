using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ChestScript : MonoBehaviour
    {
        public string chestType;  // Type of chest (hot, cold, vibration)
        private bool canBeOpened = true;  // Flag to allow chest opening
        public LevelManagerTouch levelManagerTouch;  // Reference to the LevelManager script
        public PopUpTouch popUpTouch;// Reference to the PopUpTouch script



    void Start()
        {

        // Disable the particle system at the start

        GetComponent<ParticleSystem>().Stop();  // Stop the particle system (if it's playing)

        levelManagerTouch = GameObject.Find("LevelManagerTouch").GetComponent<LevelManagerTouch>();
        popUpTouch = GameObject.Find("PopUpTouch").GetComponent<PopUpTouch>();
        
    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (canBeOpened && other.CompareTag("Player"))
            {

            ActivateParticleSystem(); //Enable to particles when player touch the chest

            // Check if the player is holding a key
            if (levelManagerTouch.IsKeyHeld())
                {
                    // Check if the key's sensation matches the chest's sensation
                    string heldKeyType = levelManagerTouch.GetHeldKeyType();  // Get the type of held key
                    if (heldKeyType == chestType)
                    {
                    //Debug.Log("Enter chest open");
                    Invoke("OpenChest",1f);  // Open the chest
                        
                    levelManagerTouch.ChestOpened();  // Notify LevelManager that a chest is opened
                       
                }
                    else
                    {
                        Debug.Log("Wrong chest! Try another key.");
                        levelManagerTouch.ResetCollectedKey();
                        ResetKeyHeld();  // Reset keyHeld status to false

                    // Show feedback for wrong chest 

                    Invoke("WrongChestMessage", 1f);


                }
                }
            }
        }

        void OpenChest()
        {
            
            Debug.Log("Chest opened! You found the right key.");
       
            canBeOpened = false;  // Prevent further openings
                                  // Play chest opening animation or effects
            ResetKeyHeld();  // Reset keyHeld status to false

            // Show feedback for correct Chest

            popUpTouch.ShowPopUp(popUpTouch.chestOpenPanel);
    }

    public void ResetKeyHeld()
    {
        levelManagerTouch.SetKeyHeld(false);  // Reset keyHeld status to false
    }

    void ActivateParticleSystem()
    {
        GetComponent<ParticleSystem>().Play();
    }

    void WrongChestMessage()
    {

        popUpTouch.ShowPopUp(popUpTouch.wrongChestPanel);
    }


}

