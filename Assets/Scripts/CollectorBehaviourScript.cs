using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.ENEMY))
        {
            Destroy(collision.gameObject);
        }
    }
}
