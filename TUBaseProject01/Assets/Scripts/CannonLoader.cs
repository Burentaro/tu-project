using UnityEngine;
using System.Collections;

public class CannonLoader : MonoBehaviour
{
    public CannonController cannonController;
    public Actor.ActorType typeToLoad = Actor.ActorType.NONE;

    private void OnTriggerEnter(Collider other)
    {
        // Get the Actor class
        Actor actor = other.gameObject.GetComponent<Actor>();

        if (actor != null)
        {
            if (actor.gameObject.tag == "Ammo" && typeToLoad == Actor.ActorType.AMMO)
            {
                // Check to see if the cannon is already loaded so that you don't override the current load
                if (cannonController.IsCannonBallLoaded)
                {
                    // Play Wonk SE
                    return;
                }

                // Pass to the cannon the weight and ammo type
                cannonController.LoadCannonBall(other.gameObject.name);
                
                // Desctory the object as it's no longer needed
                actor.DestroyObject(0);
            }
            else if (actor.gameObject.tag == "Powder" && typeToLoad == Actor.ActorType.POWDER)
            {
                // Add the powder to the cannon
                cannonController.AddPowder(actor.weight);

                // Desctory the object as it's no longer needed
                actor.DestroyObject(0);
            }
            else
            {
                // Play Wonk SE
                return;
            }
        }
            
    }
}
