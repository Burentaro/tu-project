using UnityEngine;
using System.Collections;

public class Projectile : Actor
{
    public bool hasHitTarget = false;
    Vector3 startPoint = Vector3.zero;

    private void Awake()
    {
        // Initialize the starting point
        startPoint = transform.position;
    }

    /// <summary>
    /// Used to perform actions when a projectile has collided with another object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        // Check the tag of the GameObject that we collided with to know what logic to use
        if(collision.gameObject.tag == "Target")
        {
            Debug.Log("Projectile: " + gameObject.name + " hit a target!");

            // Set the flag that the projectile has hit a target
            hasHitTarget = true;

            // Notify the SceneManager that it has hit a target
            SceneManager.Instance.HitTarget();
        }
        else if (collision.gameObject.tag == "Ground")
        {
            if(hasHitTarget)
            {
                return;
            }

            Debug.Log("Projectile: " + gameObject.name + " hit the ground");

            // Get the point in the world where the collsion happened
            if (collision.contactCount > 0)
            {
                // Get the ContactPoint info of the collision
                ContactPoint contactPoint = collision.GetContact(0);

                // Pass the point of contact to the SceneManager to place a marker
                SceneManager.Instance.MissedTarget(contactPoint.point);

                
            }
        }
    }
}
