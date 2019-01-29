using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class SteamVRInput : MonoBehaviour
{
    // Steam VR Actions
    public SteamVR_Action_Boolean upButtonAction;
    public SteamVR_Action_Boolean downButtonAction;

    // Events
    public UnityEvent onButtonPressUp;
    public UnityEvent onButtonPressDown;
    public UnityEvent onTriggerSqueezed;

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input._default.inActions.ButtonPressDown.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("Down Button Pressed");
            if (onButtonPressDown != null)
            {
                onButtonPressDown.Invoke();
            }
        }

        if (SteamVR_Input._default.inActions.ButtonPressUp.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("Up Button Pressed");
            if (onButtonPressUp != null)
            {
                onButtonPressUp.Invoke();
            }
        }
    }
}
