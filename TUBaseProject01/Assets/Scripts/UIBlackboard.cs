using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBlackboard : MonoBehaviour
{
    public Text targetDistanceText;
    public Text shotDistanceText;
    public Text cannonballText;
    public Text powderText;
    public Text angleText;

    public void OnTargetMissed(ShootHistory history)
    {
        // Update Text fields

    }

    public void OnTargetHit(ShootHistory history)
    {
        // Update Text field;
    }
}
