using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField]
    private Transform currentProjectile;        // Holds a reference to the current projectile that has been fired
    [SerializeField]
    private float distanceFromCannon;           // Record of the last recorded distance of the cannonball to the cannon
    [SerializeField]
    private Transform currentTarget;            // Holds a reference to the current target's location

    [SerializeField]
    private CannonController cannonController;  // Reference to the CannonController for other objects to be able to access
    
    public UnityEvent onTargetHit;              // Event for objects to listen for the event when the projectile hits the target
    public UnityEvent onTargetMissed;           // Event for objects to listen for the event when the projectile missed the target

    private GameObject lastMarker;


    private bool hasProjectileFired = false;
    private bool isActive = false;

    public CannonController CannonController
    {
        get
        {
            return cannonController;
        }

        set
        {
            cannonController = value;
        }
    }

    public float DistanceFromCannon
    {
        get
        {
            return distanceFromCannon;
        }

        set
        {
            distanceFromCannon = value;
        }
    }

    public Transform CurrentProjectile
    {
        get
        {
            return currentProjectile;
        }

        set
        {
            currentProjectile = value;
        }
    }

    public Transform CurrentTarget
    {
        get
        {
            return currentTarget;
        }

        set
        {
            currentTarget = value;
        }
    }


    private void Awake()
    {
        // Set the isActive flag to true to let the update function run
        isActive = false;
    }

    private void Update()
    {
        if(isActive)
        {
            // Do something
        }
    }

    private void OnDestroy()
    {
        // Set the isActive flage to false to prevent any errors if SceneManager is destoryed earlier than other classes
        isActive = false;
    }

    public void SpawnMarkerOnPoint(Vector3 point)
    {
        if(lastMarker != null)
        {
            Destroy(lastMarker);
        }
        GameObject newHitMark = Resources.Load<GameObject>("Prefabs/HitMark");
        if(newHitMark != null)
        {
            lastMarker = Instantiate(newHitMark, point, new Quaternion());
        }
    }
}
