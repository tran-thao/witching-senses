using UnityEngine;

public class MaskController : MonoBehaviour
{
    public Transform playerTransform; 
    public float distanceFromPlayer = 5f; // Adjust as needed

    void Update()
    {
        // Ensure playerTransform is assigned
        if (playerTransform != null)
        {
            // Update the position of the mask GameObject to follow the player
            transform.position = playerTransform.position + playerTransform.forward * distanceFromPlayer;
        }
    }
}
