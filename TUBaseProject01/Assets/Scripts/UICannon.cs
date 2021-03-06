﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICannon : MonoBehaviour
{
    public Text cannonballText;
    public Text powderText;
    public Text angleText;

    public void OnCannonUpdated(float angle, float powder, string cannonBall)
    {
        // Update the UI elements
        if (cannonballText != null)
        {
            if(string.IsNullOrEmpty(cannonBall))
            {
                cannonballText.text = "0";
            }
            else
            {
                cannonballText.text = cannonBall;
            }
        }

        if(powderText != null)
        {
            powderText.text = powder.ToString() + "g";
        }

        if(angleText != null)
        {
            angleText.text = angle.ToString() + " degrees";
        }
        
    }
}
