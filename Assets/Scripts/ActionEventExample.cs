using UnityEngine;
using System;

public class ActionEventExample : MonoBehaviour
{
    public event Action<string> OnActionEvent; // Define the action event

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Trigger the action event and pass a string parameter
            OnActionEvent?.Invoke("Space key pressed!");
        }
    }
}
