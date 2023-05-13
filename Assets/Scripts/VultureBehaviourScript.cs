using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureBehaviourScript : MonoBehaviour
{
    Vector3 position;
    bool moveUpwards;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    void FixedUpdate()
    {
        if (counter == 100)
        {
            counter = 0;
            if (position.y > 20)
                moveUpwards = false;
            if (position.y < 5)
                moveUpwards = true;
            if (moveUpwards)
                position.y++;
            if (!moveUpwards)
                position.y--;
            transform.position = position;

        }
        counter++;
    }
}
