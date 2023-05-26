using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BatBehaviourScript : EnemyBehaviourScript
{
    const float desiredHeight = 1.65f; // Desired constant height from the ground
    [SerializeField] LayerMask groundLayerMask; // select the Layer in the Editor
    CircleCollider2D circleCollider2D;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        // Cast a ray downward from the current position
        float distance = DistanceToGround();
        // Calculate the desired position with the constant height from the ground
        Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y - distance + desiredHeight, transform.position.z);
        // Move the current object to the desired position
        transform.position = desiredPosition;
    }

    // FixedUpdate is called at fixed Time Steps for Physics Calculations
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }

    float DistanceToGround()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(circleCollider2D.bounds.center, Vector2.down, Mathf.Infinity, groundLayerMask);
        Color rayColour;
        if (hitinfo.collider != null) rayColour = Color.green;
        else rayColour = Color.red;
        Debug.DrawRay(circleCollider2D.bounds.center, Vector2.down * hitinfo.distance, rayColour);
        return hitinfo.distance;
    }
}
