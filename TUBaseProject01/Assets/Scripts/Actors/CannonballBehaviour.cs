using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballBehaviour : Actor
{
    // This value should start at the first hit after active
    public float secondsOfLifeAfterHit = 3;
    
    public override void DestroyObject(int delay)
    {
        if(!isDying)
        {
            Destroy(gameObject, delay);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (isActive && !isDying)
        //{
        //    // Here goes the code to handle the landing
        //    isDying = true;
        //    Debug.Log("Distance: " + Vector3.Distance(transform.position, spawnPoint));
        //}
    }
}
