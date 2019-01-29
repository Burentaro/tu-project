using UnityEngine;
using System.Collections;

public class PitchAdjuster : MonoBehaviour
{

    public float adjustmentLevel = 0;                             // Inventory Id for the item that this button will dispense
    public PowderLoaderEvent onPitchChanged;   // Custom event to send a message to the dispenser to dispense an item

    public void OnButtonTriggered()
    {
        // Check that the UnityEnvent is not null to avoid a null exception
        if (onPitchChanged != null)
        {
            // Let the dispenser/listener know that it should dispense an item
            onPitchChanged.Invoke(adjustmentLevel);
        }
    }
}
