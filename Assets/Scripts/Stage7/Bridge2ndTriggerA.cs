using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge2ndTriggerA : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Bridge2ndController.state = 1;
            Bridge2ndController.RotateController = true;
        }
    }
}
