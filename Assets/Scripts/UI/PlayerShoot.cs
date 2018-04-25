using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    Vector3 startPos1 = new Vector3(-30, 5, -14);
    Vector3 startPos2 = new Vector3(-30, 0, -14);
    Vector3 startPos3 = new Vector3(-30, -5, -14);
    Rigidbody rg3d;

    public static int model;
    bool prepare;

	void Start () {
        model = 0;
        prepare = false;
        rg3d = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
		if(model != 0 && !prepare)
        {
            if(model == 1)
            {
                transform.position = Vector3.Lerp(transform.position, startPos1, 10f * Time.deltaTime);
                if (transform.position.x - startPos1.x < 20f)
                {
                    transform.position = startPos1;
                    prepare = true;
                }
            }
            else if(model == 2)
            {
                transform.position = Vector3.Lerp(transform.position, startPos2, 10f * Time.deltaTime);
                if (transform.position.x - startPos2.x < 20f)
                {
                    transform.position = startPos2;
                    prepare = true;
                }
            }
            else if(model == 3)
            {
                transform.position = Vector3.Lerp(transform.position, startPos3, 10f * Time.deltaTime);
                if (transform.position.x - startPos3.x < 20f)
                {
                    transform.position = startPos3;
                    prepare = true;
                }
            }
        }
        else if(model == 1 && prepare)
        {
            rg3d.angularVelocity = Vector3.zero;
            rg3d.velocity = new Vector3(58f, -59f, 23f);
            model = 4;
            prepare = false;
        }
        else if(model == 2 && prepare)
        {
            rg3d.angularVelocity = Vector3.zero;
            rg3d.velocity = new Vector3(58f, -31.5f, 27.5f);
            model = 4;
            prepare = false;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Ground") && model == 4)
        {
            rg3d.velocity = new Vector3(rg3d.velocity.x / 2f, rg3d.velocity.y / 3f, -rg3d.velocity.z / 5f);
            rg3d.useGravity = true;
        }
    }
}
