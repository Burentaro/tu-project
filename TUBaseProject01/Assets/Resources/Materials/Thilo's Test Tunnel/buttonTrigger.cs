using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTrigger : MonoBehaviour
{
	public Transform ObjectToSpawn;
	public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
    	if (other.CompareTag("Button"))
    	{
    		Instantiate(ObjectToSpawn, spawnPoint.position, spawnPoint.rotation);
    	}
    }
}
