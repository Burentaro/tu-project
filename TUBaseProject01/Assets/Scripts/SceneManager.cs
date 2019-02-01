using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class OnTargetMissedEvent : UnityEvent<ShootHistory> { }

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField]
    private Transform cannonStartPoint;            // Holds a reference to the current target's location

    [SerializeField]
    private Transform currentTarget;            // Holds a reference to the current target's location

    [SerializeField]
    private CannonController cannonController;  // Reference to the CannonController for other objects to be able to access
    
    public OnTargetMissedEvent onTargetHit;              // Event for objects to listen for the event when the projectile hits the target
    public OnTargetMissedEvent onTargetMissed;           // Event for objects to listen for the event when the projectile missed the target

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

    public void SetDistanceFromCannon(float distance)
    {
        if(lastShootHistory != null)
        {
            lastShootHistory.SetShotDistance(distance);
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


    public Transform CannonStartPoint
    {
        get
        {
            return cannonStartPoint;
        }

        set
        {
            cannonStartPoint = value;
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
            lastShootHistory.SetHitTarget("MISS");
            lastShootHistory.SetShotDistance(Vector3.Distance(point, CannonStartPoint.position));
        }

        if(onTargetMissed != null)
        {
            onTargetMissed.Invoke(lastShootHistory);
        }
    }

    public void CannonShot(float angle, float powder, string cannonBall)
    {
        lastShootHistory = new ShootHistory(angle, powder, cannonBall);
    }

    public ShootHistory GetLastShoot()
    {
        return lastShootHistory;
    }

    public float GetTargetDistance()
    {
        return 0.0f;
    }

    public void MissedTarget(Vector3 point)
    {
        SpawnMarkerOnPoint(point);
    }

    public void HitTarget()
    {
        lastShootHistory.SetHitTarget("HIT");
        lastShootHistory.SetShotDistance(GetTargetDistance());

        if (onTargetHit != null)
        {
            onTargetHit.Invoke(lastShootHistory);
        }
    }
}
