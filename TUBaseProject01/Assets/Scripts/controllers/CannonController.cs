using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CannonController : MonoBehaviour
{
    public float minAngle = 0.0f;
    public float maxAngle = 25.0f;
    public float maxPowderLoad = 1000.0f;
    public Transform cannonBarrel;

    [SerializeField]
    private string loadedCannonBall;
    [SerializeField]
    private float cannonAngle = 0;
    [SerializeField]
    private float powder = 0;
    [SerializeField]
    public bool isCannonLoaded = false;
    [SerializeField]
    public bool isPowderLoaded = false;

    public bool IsCannonBallLoaded
    {
        set { isCannonLoaded = value; }
        get
        {
            return isCannonLoaded;
        }
    }

    public bool IsPowderLoaded
    {
        set { isPowderLoaded = value; }
        get
        {
            if (powder > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // We set up the angle of the cannon between 0 and under 90
    public bool SetCannonAngle(float newAngle)
    {
        if(newAngle < minAngle)
        {
            return false;
        }
        
        if(newAngle < maxAngle)
        {
            cannonAngle = newAngle;
            cannonBarrel.rotation = Quaternion.Euler(-cannonAngle, 0, 0);
            return true;
        }

        return false;
    }
    
    public float GetCannonAngle()
    {
        return cannonAngle;
    }
    
    public float AddPowder(float morePowder)
    {
        float extraPower = 0;
        powder += morePowder;
        if(powder > maxPowderLoad)
        {
            extraPower = powder - maxPowderLoad;
            powder = maxPowderLoad;
        }

        return extraPower;
    }
    
    public float GetPowder()
    {
        return powder;
    }

    public bool LoadCannonBall(string newCannonBall)
    {
        // Check to see if the cannon has already been laoded
        if(IsCannonBallLoaded)
        {
            // Load failed
            return false;
        }

        // Save the name of the cannon ball that was loaded so that it can be loaded from resources
        loadedCannonBall = newCannonBall;

        // Set the flag so that only one cannonball is loaded
        IsCannonBallLoaded = true;

        // Load successful
        return true;
    }

    public void Shoot()
    {
        if(!IsCannonBallLoaded || !IsPowderLoaded)
        {
            return;
        }

        IsCannonBallLoaded = false;

        // Create a cannonball to be fired of the same resource that was laoded
        GameObject cannonBall = Instantiate(Resources.Load<GameObject>(loadedCannonBall), cannonBarrel.position, cannonBarrel.rotation);

        // Change tag to prevent being reloaded when fired
        cannonBall.tag = "projectile";

        // Add a force to the cannonball to propel it towards it's target
        cannonBall.GetComponent<Rigidbody>().AddForce(cannonBarrel.forward * (powder * 3));

        // Clean the cannon to prepare it for the next round
        CleanCannon();

        return;
    }

    private void CleanCannon()
    {
        // Clear the cannonball
        loadedCannonBall = string.Empty;
        loadedCannonBall = null;
        
        // Clear the powder
        powder = 0;
    }

}
