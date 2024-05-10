using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAnagram : MonoBehaviour
{
    public Canvas AnagramCanvas;

    // Start is called before the first frame update
    void Start()
    {
        AnagramCanvas = GameObject.Find("AnagramCanvas").GetComponent<Canvas>();
        AnagramCanvas.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AnagramCanvas.enabled = true;
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
