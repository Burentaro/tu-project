using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteController : MonoBehaviour
{
    public CannonController cannonController;
    public bool isHeld = false;

    // Start is called before the first frame update
    private bool fire = false;
    private float upDownAxis = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            if (Input.GetKeyDown("Fire1"))
            {
                fire = true;
            }
            if (Input.GetKeyUp("Fire1"))
            {
                fire = false;
            }
            upDownAxis = Input.GetAxis("UpDown");
        }
    }

    private void actions()
    {
        if (fire)
        {
            Debug.Log("Shoot");
        }
        if(upDownAxis < 0)
        {
            Debug.Log("Up?");
        }
        if(upDownAxis > 0)
        {
            Debug.Log("Down?");
        }
    }
}
