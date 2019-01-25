using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballBehaviour : Actor
{
    //public bool isActive;
    //public GameObject holdingCopy;
    // This value should start at the first hit after active
    public float secondsOfLifeAfterHit = 3;

    //private Vector3 spawnPoint;
    //private bool isDying = false;

    public override void DestroyObject(int delay)
    {
        if(!isDying)
        {
            Destroy(gameObject, secondsOfLifeAfterHit);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isDying)
        //{
        //    secondsOfLifeAfterHit -= Time.deltaTime;
        //    if(secondsOfLifeAfterHit < 0)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.name == "CannonRotation" && !isActive)
        //{
        //    isActive = true;

        //    // Code for loading the cannon
        //    CannonController cannonController = other.gameObject.transform.parent.GetComponent<CannonController>();
        //    cannonController.loadCannonball(gameObject.name);

        //    Destroy(this.gameObject);
        //}
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
