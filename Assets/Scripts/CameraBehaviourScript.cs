using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviourScript : MonoBehaviour
{
    [SerializeField] float minimumXPosition, maximumXPosition;
    Transform playerTransform;
    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    // makes the Camera move smoother, because the Player Position is already calculated
    void LateUpdate()
    {
        if (playerTransform != null)
        {
            cameraPosition = transform.position;
            cameraPosition.x = playerTransform.position.x;
            cameraPosition.y = playerTransform.position.y;
            if (cameraPosition.x < minimumXPosition) cameraPosition.x = minimumXPosition;
            if (cameraPosition.x > maximumXPosition) cameraPosition.x = maximumXPosition;
            if (cameraPosition.y < 0) cameraPosition.y = 0;
            transform.position = cameraPosition;
        }
    }
}
