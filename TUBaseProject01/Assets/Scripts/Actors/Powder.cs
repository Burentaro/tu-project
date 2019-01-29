using UnityEngine;
using System.Collections;

public class Powder : Actor
{
    public CannonController cannonController;

    public void OnLoadPowder()
    {
        if (cannonController != null)
        {
            cannonController.AddPowder(weight);
        }
    }

    public override void DestroyObject(int delay)
    {

    }
}
