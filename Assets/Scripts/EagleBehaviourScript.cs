using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleBehaviourScript : MonoBehaviour
{
    AIPath aiPath;
    Vector3 previousVelocity;

    private void Start()
    {
        aiPath = FindObjectOfType<AIPath>();
        previousVelocity = aiPath.desiredVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sign(aiPath.desiredVelocity.x) != Mathf.Sign(previousVelocity.x))
        {
            // Direction change detected
            Vector3 scale = transform.localScale;
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
        previousVelocity = aiPath.desiredVelocity;
    }
}
