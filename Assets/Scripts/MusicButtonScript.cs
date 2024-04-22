using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicButtonScript : MonoBehaviour
{
    public Color initialColor = new Color(1f, 1f, 1f, 0.0f);
    public Color highlightColor = Color.green;
    public AudioClip noteSound;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D musicButtonCollider;
    private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        musicButtonCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        // Check if components are assigned
        if (audioSource == null || spriteRenderer == null || musicButtonCollider == null)
        {
            Debug.LogError("One or more components are missing!");
            return;
        }


        // Set the audio clip and disable play on awake
        audioSource.clip = noteSound;
        audioSource.playOnAwake = false;

        spriteRenderer.color = initialColor;


    }
    private void OnTriggerEnter2D(Collider2D other) // Change to OnTriggerEnter2D
    {
        if (other.CompareTag("Player"))
        {
            Highlight();
        }
    }

    public void Highlight()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = highlightColor;
        }
        else
        {
            Debug.Log(gameObject.name);
            Debug.LogError("SpriteRenderer is not assigned!");
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource is not assigned!");
        }

        Invoke("ResetColor", 1f); // Reset color after 1 second
    }

    private void ResetColor()
    {
        spriteRenderer.color = initialColor;
    }
}
