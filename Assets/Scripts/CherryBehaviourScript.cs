using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBehaviourScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2d;
    AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER_TAG))
        {
            spriteRenderer.enabled = false;
            boxCollider2d.enabled = false;
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
