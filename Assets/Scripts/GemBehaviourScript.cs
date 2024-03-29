using System;
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
    int gemsInScene;

    private void Start()
    {
        GameObject gemTextObject = GameObject.Find(Tags.GEM_TEXT);
        gemtText = gemTextObject.GetComponent<Text>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        gemsInScene = countGemsInScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER))
        {
            boxCollider2d.enabled = false;
            spriteRenderer.enabled = false;
            gemsCollected++;
            gemtText.text = "Gems " + gemsCollected + "/" + gemsInScene;
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(gameObject, audioSource.clip.length);
        }
    }

    int countGemsInScene()
    {
        int count;
        GameObject gemsObject = GameObject.Find("Gems");
        count = gemsObject.transform.childCount;
        return count;
    }
}
