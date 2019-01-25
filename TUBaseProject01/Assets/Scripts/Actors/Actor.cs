using UnityEngine;
using System.Collections;



public class Actor : MonoBehaviour
{
    public enum ActorType
    {
        NONE,
        AMMO,
        POWDER
    };

    public ActorType type;
    public float weight;

    public bool isDying;

    public virtual void DestroyObject(int delay) { }
}
