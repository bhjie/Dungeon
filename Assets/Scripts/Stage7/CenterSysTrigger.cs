using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSysTrigger : MonoBehaviour {

    private Vector3 offset = new Vector3(0, 0.1f, 0f);
    private int working = 0;
    private float oriY;
	void Start () {
        transform.position += offset;
        oriY = transform.position.y;
	}

	void Update () {
		if(working == 1)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - offset, 1f * Time.deltaTime);
        }
        if(working == 1 && transform.position.y < oriY - 0.1f)
        {
            working = 2;
        }
        if(working == 2)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + offset, 1f * Time.deltaTime);
        }
        if(working == 2 && transform.position.y > oriY)
        {
            working = 0;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(working == 0 && collision.gameObject.CompareTag("Player"))
        {
            working = 1;
            RotatingOrb.count++;
            RotatingOrb.RotateController = true;
        }
    }
}
