using UnityEngine;
using System.Collections;

public class ContinuousButtonTrigger : MonoBehaviour
{
    public bool isPressed = false;
    public float adjustmentLevel = 0;                             // Inventory Id for the item that this button will dispense
    public PowderLoaderEvent onPitchChanged;

    private void OnCollisionEnter(Collision collision)
    {
        isPressed = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isPressed = false;
    }

    private void Update()
    {
        if(isPressed)
        {
            // Check that the UnityEnvent is not null to avoid a null exception
            if (onPitchChanged != null)
            {
                // Let the dispenser/listener know that it should dispense an item
                onPitchChanged.Invoke(adjustmentLevel);
            }
        }
    }
}
