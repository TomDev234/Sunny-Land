using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureBehaviourScript : MonoBehaviour
{
    float amplitude = 1.0f;  // The amplitude of the sinusoidal movement
    float frequency = 1.0f;  // The frequency of the sinusoidal movement
    Vector3 startPosition;  // The initial position of the object

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;  // Store the initial position of the object
    }

    void FixedUpdate()
    {
        // Calculate the new position based on time and the sinusoidal function
        float newYPosition = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        // Update the object's position
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
