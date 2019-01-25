using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballBehaviour : MonoBehaviour
{
    public bool active;
    public GameObject holdingCopy;
    // This value should start at the first hit after active
    public float secondsOfLifeAfterHit = 3;

    private Vector3 spawnPoint;
    private bool dying = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dying)
        {
            secondsOfLifeAfterHit -= Time.deltaTime;
            if(secondsOfLifeAfterHit < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CannonRotation" && !active)
        {
            // Code for loading the cannon
            CannonController cc = (CannonController)other.gameObject.transform.parent.GetComponent(typeof(CannonController));
            active = true;
            cc.loadCannonball(gameObject.name);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (active && !dying)
        {
            // Here goes the code to handle the landing
            dying = true;
            Debug.Log("Distance: " + Vector3.Distance(transform.position, spawnPoint));
        }
    }
}
