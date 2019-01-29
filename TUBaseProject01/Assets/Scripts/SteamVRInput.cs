using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SteamVRInput : MonoBehaviour
{
    public SteamVR_Action_Boolean upButtonAction;
    public SteamVR_Action_Boolean downButtonAction;


    // Update is called once per frame
    void Update()
    {
        if(SteamVR_Input._default.inActions.ButtonPressDown.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("Down Button Pressed");
        }

        if (SteamVR_Input._default.inActions.ButtonPressUp.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("Up Button Pressed");
         }
    }
}
