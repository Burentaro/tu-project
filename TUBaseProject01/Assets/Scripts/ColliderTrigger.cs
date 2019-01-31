using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour {

    public string tagName = "Button";     // tag used to filter out only the objects that we want
    public UnityEvent onColliderTriggered;    // UnityEvent to notify listeners when the button was triggered

    void OnTriggerEnter(Collider other)
    {
        // Check that the object collided with is a button
        Debug.Log("On TriggerEnter 1");
        if (other.tag == tagName)
        {
            // Check that the UnityEnvent is not null to avoid a null exception
            Debug.Log("On TriggerEnter 2");
            if (onColliderTriggered != null)
            {
                // Let all listeners know that the button has been triggered
                Debug.Log("On TriggerEnter 3");
                onColliderTriggered.Invoke();
            }
        }
    }
}
