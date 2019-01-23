using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float MAX_Powder = 1000;

    private Transform cannonTransform;
    private float cannonAngle = 0;
    private float powder = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).tag.Equals("cannonBody"))
            {
                cannonTransform = this.gameObject.transform.GetChild(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // We set up the angle of the cannon between 0 and under 90
    public bool setCannonAngle(float newAngle)
    {
        if(newAngle < 0)
        {
            return false;
        }
        
        if(newAngle < 90)
        {
            cannonAngle = newAngle;
            cannonTransform.rotation = Quaternion.Euler(-cannonAngle, 0, 0);
            return true;
        }

        return false;
    }

    // 
    public float getCannonAngle()
    {
        return cannonAngle;
    }

    // 
    public float addPowder(float morePowder)
    {
        float extraPower = 0;
        powder += morePowder;
        if(powder > MAX_Powder)
        {
            extraPower = powder - MAX_Powder;
            powder = MAX_Powder;
        }

        return extraPower;
    }

    // 
    public float getPowder()
    {
        return powder;
    }
}
