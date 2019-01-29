using UnityEngine;
using System.Collections;



public class Actor : MonoBehaviour
{
    public string actorName;
    public float weight;

    public bool isDying;

    public virtual void DestroyObject(int delay) { }
}
