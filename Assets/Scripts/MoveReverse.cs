using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoMoveReverse : MonoBehaviour
{
    public MusicButtonManager musicButtonManager;

    public float speed = 10.5f;
    float vertical, horizontal;
    Rigidbody2D myRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        movePrincess();
    }

   void movePrincess()

    {

        horizontal = -1*Input.GetAxisRaw("Horizontal");
        vertical = -1*Input.GetAxisRaw("Vertical");
        myRigidbody2D.velocity= new Vector2(horizontal*speed, vertical*speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MusicButton"))
        {
            musicButtonManager.CheckInput(other.gameObject);
        }
    }
}
