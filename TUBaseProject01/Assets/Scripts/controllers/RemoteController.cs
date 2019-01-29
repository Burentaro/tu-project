using UnityEngine;

public class RemoteController : MonoBehaviour
{
    public CannonController cannonController;

    [SerializeField]
    private bool isHeld = false;

    /// TO-DO : Talk about this with Andres. I'm not 100% happy about doing it this way
    /// From a teaching perspective, it may be better to split into two methods. What do you think?
    public void HoldRemote()
    {
        bool oldHoldValue = isHeld;
        if(oldHoldValue)
        {
            isHeld = false;
        }
        else
        {
            isHeld = true;
        }
    }

    public void Fire()
    {
        if (isHeld)
        {
            Debug.Log("RemoteController: Fire");
            cannonController.Shoot();
        }
    }

    public void IncreaseAngle()
    {
        if (isHeld)
        {
            Debug.Log("RemoteController: IncreaseAngle");
            cannonController.AddCannonAngle(-1);
        }
    }

    public void DecreaseAngle()
    {
        if (isHeld)
        {
            Debug.Log("RemoteController: DecreaseAngle");
            cannonController.AddCannonAngle(1);
        }
    }
}
