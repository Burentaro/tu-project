using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour {

    public string buttonTag = "Button";     // tag used to filter out only the objects that we want
    public UnityEvent onButtonTriggered;    // UnityEvent to notify listeners when the button was triggered

    void OnTriggerEnter(Collider other)
    {
        // Check that the object collided with is a button
        if (other.tag == buttonTag)
        {
            // Check that the UnityEnvent is not null to avoid a null exception
            if (onButtonTriggered != null)
            {
                // Let all listeners know that the button has been triggered
                onButtonTriggered.Invoke();
            }
        }
    }
}
