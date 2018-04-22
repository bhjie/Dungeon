using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    public GameObject target;
    public Vector3 move;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.velocity = new Vector3(0, 0, 0);
            collision.transform.position = target.transform.position + move;
        }
    }
}
