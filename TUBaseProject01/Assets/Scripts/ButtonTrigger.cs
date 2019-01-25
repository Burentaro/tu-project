using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour {

    [SerializeField]
    private Transform boxPrefab;
    [SerializeField]
    private Transform spawnPoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: ButtonTrigger -1 : " + gameObject.name);
        if (other.tag == "Button")
        {
            Debug.Log("OnTriggerEnter: ButtonTrigger -2: " + gameObject.name);
            Transform t = Instantiate(boxPrefab);

            t.position = spawnPoint.position;
            Debug.Log("OnTriggerEnter: ButtonTrigger -3: " + gameObject.name);
        }
    }
}
