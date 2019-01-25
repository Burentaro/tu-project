using UnityEngine;

public class DispenserButton : MonoBehaviour
{
    public int inventoryId = 0;                             // Inventory Id for the item that this button will dispense
    public DispenserButtonEvent onDispenserButtonPressed;   // Custom event to send a message to the dispenser to dispense an item
    
    public void OnButtonTriggered()
    {
        // Check that the UnityEnvent is not null to avoid a null exception
        if (onDispenserButtonPressed != null)
        {
            // Let the dispenser/listener know that it should dispense an item
            onDispenserButtonPressed.Invoke(inventoryId);
        }
    }


}
