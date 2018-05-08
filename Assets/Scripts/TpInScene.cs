using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpInScene : MonoBehaviour {

    public Vector3 target;

    private Rigidbody rig;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            rig = other.GetComponent<Rigidbody>();
            rig.velocity = new Vector3(0, 0, 0);
            other.transform.position = target;
        }
    }
}
