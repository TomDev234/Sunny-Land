using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemBehaviourScript : MonoBehaviour
{
    [HideInInspector] public static int gemsCollected = 0;
    Text gemtText;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2d;
    AudioSource audioSource;

    private void Start()
    {
        GameObject gemTextObject = GameObject.FindWithTag(Tags.GEM_TEXT);
        gemtText = gemTextObject.GetComponent<Text>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER_TAG))
        {
            gemsCollected++;
            gemtText.text = "Gems " + gemsCollected;
            spriteRenderer.enabled = false;
            boxCollider2d.enabled = false;
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
