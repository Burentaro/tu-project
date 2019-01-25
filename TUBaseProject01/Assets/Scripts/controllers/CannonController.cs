using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CannonController : MonoBehaviour
{
    public float MAX_Powder = 1000;

    private Transform cannonTransform;
    private string cannonBallType;
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

    public bool loadCannonball(string newCannonball)
    {
        if(cannonBallType != null && !cannonBallType.Equals(""))
        {
            return false;
        }
        cannonBallType = newCannonball;
        return true;
    }

    public bool isCannonballLoaded()
    {
        return cannonBallType != null && !cannonBallType.Equals("");
    }

    public bool shoot()
    {
        if(cannonBallType == null || cannonBallType.Equals("") || powder == 0)
        {
            return false;
        }
        GameObject cannonBall = (GameObject)Instantiate(Resources.Load(cannonBallType), cannonTransform.position, cannonTransform.rotation);
        cannonBall.GetComponent<CannonballBehaviour>().active = true;
        cannonBall.GetComponent<Rigidbody>().AddForce(cannonTransform.forward * (powder * 3));

        cannonBallType = null;
        powder = 0;

        return true;
    }

}
