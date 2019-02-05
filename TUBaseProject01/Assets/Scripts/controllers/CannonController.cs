using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[System.Serializable]
public class PowderLoaderEvent : UnityEvent<float>{ }

[System.Serializable]
public class CannonUpdateEvent : UnityEvent<float,float,string> { }

public class CannonController : MonoBehaviour
{
    public float maxPowderLoad = 1000.0f;
    public Transform cannonBarrel;
    public float moveSpeed = 2;
    public AudioClip shootSound;
    public float maxAngle = 90.0f;

    public CannonUpdateEvent OnCannonUpdate;

    [SerializeField]
    private string loadedCannonBall;
    [SerializeField]
    private double cannonAngle = 0.0f;
    private Quaternion targetRotation;
    [SerializeField]
    private float powder = 0;


    [SerializeField]
    public bool isCannonLoaded = false;
    [SerializeField]
    public bool isPowderLoaded = false;
    private float minAngle = 0.0f;


    private void Start()
    {
        targetRotation = cannonBarrel.transform.rotation;
        SceneManager.Instance.CannonStartPoint = cannonBarrel.transform;
    }

    public bool IsCannonBallLoaded
    {
        set { isCannonLoaded = value; }
        get
        {
            return isCannonLoaded;
        }
    }

    public bool IsPowderLoaded()
    {
        return powder > 0;
    }

    public void AddCannonAngle(double angleValue)
    {
        // Calculate the new angle
        double newAngle = cannonAngle + angleValue;
        
        // Check that the new angle is within the min max bounds
        if(newAngle >= minAngle && newAngle <= maxAngle)
        {
            // Set the new angle
//            targetRotation = Quaternion.Euler((float)-cannonAngle, cannonBarrel.transform.rotation.y, cannonBarrel.transform.rotation.z);
            // Set the new angle
            targetRotation = Quaternion.Euler((float)-cannonAngle, 0, 0);
            cannonAngle = newAngle;

            // Notify listeners of the update
            if (OnCannonUpdate != null)
            {
                OnCannonUpdate.Invoke((float)cannonAngle, powder, loadedCannonBall);
            }
        }

    }
    
    public double GetCannonAngle()
    {
        return cannonAngle;
    }

    public void AddPowder(float morePowder)
    {
        float extraPower = 0;
        powder += morePowder;
        if(powder > maxPowderLoad)
        {
            extraPower = powder - maxPowderLoad;
            powder = maxPowderLoad;
        }

        // Notify listeners of the update
        if (OnCannonUpdate != null)
        {
            OnCannonUpdate.Invoke((float)cannonAngle, powder, loadedCannonBall);
        }
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

        // Notify listeners of the update
        if (OnCannonUpdate != null)
        {
            OnCannonUpdate.Invoke((float)cannonAngle, powder, loadedCannonBall);
        }

        // Load successful
        return true;
    }

    public void Shoot()
    {
        if(!IsCannonBallLoaded || !IsPowderLoaded())
        {
            return;
        }


        // Create a cannonball to be fired of the same resource that was laoded
        GameObject newProjectile = Resources.Load<GameObject>(loadedCannonBall);
        if (newProjectile != null)
        {
            GameObject cannonBall = Instantiate(newProjectile, cannonBarrel.position, cannonBarrel.rotation);

            // Change tag to prevent being reloaded when fired
            cannonBall.tag = "projectile";

            // Add a force to the cannonball to propel it towards it's target
            cannonBall.GetComponent<Rigidbody>().AddForce(cannonBarrel.forward * (powder * 3));
            AudioSource.PlayClipAtPoint(shootSound, cannonBarrel.transform.position);
            SceneManager.Instance.CannonShot((float)cannonAngle, powder, "Some Cannonball");
        }
        else
        {
            Debug.Log("Didn't load the resource");
        }

        // Clean the cannon to prepare it for the next round
        CleanCannon();

        // Notify listeners of the update
        if (OnCannonUpdate != null)
        {
            OnCannonUpdate.Invoke((float)cannonAngle, powder, loadedCannonBall);
        }
    }

    private void CleanCannon()
    {
        // Clear the cannonball
        loadedCannonBall = string.Empty;
        loadedCannonBall = null;
        IsCannonBallLoaded = false;

        // Clear the powder
        powder = 0;
    }

    private void AdjustCannon()
    {
        cannonBarrel.localRotation = Quaternion.Lerp(cannonBarrel.localRotation, targetRotation, Time.deltaTime * moveSpeed);
    }

    private void Update()
    {
        if(cannonBarrel.transform.rotation.x != targetRotation.x)
        {
            AdjustCannon();
        }
    }
}
