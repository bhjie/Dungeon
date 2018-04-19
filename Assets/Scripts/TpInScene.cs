using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpInScene : MonoBehaviour {

    public Vector3 target;
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
            other.transform.position = target;
        }
    }
}
