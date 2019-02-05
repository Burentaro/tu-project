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
        SetTextData(SceneManager.Instance.GetTargetDistance(), history);
    }

    public void OnTargetHit(ShootHistory history)
    {
        // Update Text fields
        SetTextData(SceneManager.Instance.GetTargetDistance(), history);
    }

    private void SetTextData(float targetDistance, ShootHistory history)
    {
        if (targetDistanceText != null)
        {
            targetDistanceText.text = targetDistance.ToString() + "m";
        }

        if (shotDistanceText != null)
        {
            shotDistanceText.text = history.GetShotDistance().ToString() + "m";
        }

        if (cannonballText != null)
        {
            cannonballText.text = history.GetCannonBall() + "m";
        }

        if (powderText != null)
        {
            powderText.text = history.GetPowder().ToString() + "m";
        }

        if (angleText != null)
        {
            angleText.text = history.GetAngle().ToString() + "m";
        }
    }
}
