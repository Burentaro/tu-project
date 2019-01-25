using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DispenserButtonEvent : UnityEvent<int> { }

public class DispenserController : MonoBehaviour
{
    public GameObject[] inventoryItems; // List of items that are in the dispenser
    public bool isDispensing;           // Flag for ensureing that the dispenser is only dispensing one item at a time
    public Transform spawnPoint;        // Position where the items were come out

    public void OnDispenserButtonPressed(int inventoryId)
    {
        // Check that the dispenser is not already dispensing an item
        if(isDispensing)
        {
            return;
        }

        // Check that the passed inventoryId is not out of range
        if (inventoryId < inventoryItems.Length)
        {
            // Set the flag to ensure only one item is dispensed at a time
            isDispensing = true;

            // Instantiate the prefab from the list of inventory items
            GameObject newItem = GameObject.Instantiate(inventoryItems[inventoryId]);
            // Set the new item's starting position to the spawn point
            newItem.transform.position = spawnPoint.position;

            // Reset the flag to let the dispenser dispense another item
            isDispensing = false;
        }
    }
}
