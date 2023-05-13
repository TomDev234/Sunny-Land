using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    [HideInInspector] public float speed;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called at fixed Time Steps for Physics Calculations
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }
}
