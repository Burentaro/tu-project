using UnityEngine;

public class PowderLoaderButton : MonoBehaviour
{
    public float powderLoad = 0;                             // Inventory Id for the item that this button will dispense
    public PowderLoaderEvent onPowderLoaded;   // Custom event to send a message to the dispenser to dispense an item

    public void OnButtonTriggered()
    {
        // Check that the UnityEnvent is not null to avoid a null exception
        if (onPowderLoaded != null)
        {
            // Let the dispenser/listener know that it should dispense an item
            onPowderLoaded.Invoke(powderLoad);
        }
    }


}
