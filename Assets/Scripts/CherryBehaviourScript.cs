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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.enabled = false;
        boxCollider2d.enabled = false;
        audioSource.PlayOneShot(audioSource.clip);
        Destroy(gameObject, audioSource.clip.length);
    }
}
