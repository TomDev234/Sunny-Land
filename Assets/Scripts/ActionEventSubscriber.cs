using UnityEngine;

public class ActionEventSubscriber : MonoBehaviour
{
    private ActionEventExample actionEventExample; // Reference to the ActionEventExample script

    private void Start()
    {
        actionEventExample = FindObjectOfType<ActionEventExample>();

        // Subscribe to the action event by adding a method as a listener
        actionEventExample.OnActionEvent += HandleActionEvent;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the action event when this script is destroyed
        actionEventExample.OnActionEvent -= HandleActionEvent;
    }

    private void HandleActionEvent(string message)
    {
        // Debug.Log("Action event received in subscriber: " + message);
    }
}
