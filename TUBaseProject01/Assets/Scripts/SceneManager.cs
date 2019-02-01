using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField]
    private Transform currentProjectile;        // Holds a reference to the current projectile that has been fired
    [SerializeField]
    private Transform currentTarget;            // Holds a reference to the current target's location

    [SerializeField]
    private CannonController cannonController;  // Reference to the CannonController for other objects to be able to access
    
    public UnityEvent onTargetHit;              // Event for objects to listen for the event when the projectile hits the target
    public UnityEvent onTargetMissed;           // Event for objects to listen for the event when the projectile missed the target

    private GameObject lastMarker;
    private ShootHistory lastShootHistory;


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

    public void setDistanceFromCannon(float distance)
    {
        if(lastShootHistory != null)
        {
            lastShootHistory.setShotDistance(distance);
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
            lastShootHistory.setHitTarget("MISS");
        }
    }


    public void CannonShooted(float angle, float powder, string cannonBall)
    {
        lastShootHistory = new ShootHistory(angle, powder, cannonBall);
    }

    public ShootHistory getLastShoot()
    {
        return lastShootHistory;
    }
}
