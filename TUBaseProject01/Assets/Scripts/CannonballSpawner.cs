using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballSpawner : MonoBehaviour
{
	public Rigidbody cannonBallPrefab;
	public Transform barrelEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
        	Rigidbody rocketInstance;
        	rocketInstance = Instantiate(cannonBallPrefab, barrelEnd.position, barrelEnd.rotation);
        	rocketInstance.AddForce(barrelEnd.forward * 5000);
        }
    }
}
