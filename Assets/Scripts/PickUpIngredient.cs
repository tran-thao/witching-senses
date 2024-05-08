using UnityEngine;

public class PickUpIngredient : MonoBehaviour
{
    public string pickupTag = "smellIngredient"; // Tag for the pickup objects
    public KeyCode interactKey = KeyCode.E;
    public float moveSpeed = 30f; // Player movement speed
    private GameObject carriedIngredient;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = moveDirection * moveSpeed;

        // Interaction with objects
        if (Input.GetKeyDown(interactKey))
        {
            if (carriedIngredient == null)
            {
                PickUpIngred();
            }
            else
            {
                DropIngred();
            }
        }
    }

    void PickUpIngred()
    {
        if (carriedIngredient == null)
        {
            // Check for any nearby pickup objects
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag(pickupTag))
                {
                    carriedIngredient = collider.gameObject;
                    carriedIngredient.transform.parent = transform; // Attach the ingredient to the player
                    carriedIngredient.transform.localPosition = new Vector3(0f,0f, -2f); // Set position relative to the player
                    carriedIngredient.GetComponent<BoxCollider2D>().isTrigger = false;
                    break;
                }
            }
        }
    }

    void DropIngred()
    {
        if (carriedIngredient != null)
        {
            carriedIngredient.transform.parent = null; // Unparent the ingredient from the player
            carriedIngredient = null;
            carriedIngredient.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
