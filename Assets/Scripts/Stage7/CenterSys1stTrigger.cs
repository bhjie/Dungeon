using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSys1stTrigger : MonoBehaviour {

    private Vector3 offset;
    private int working;
    private float oriY;
	void Start () {
        offset = new Vector3(0, 0.1f, 0f);
        working = 0;
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
            CenterSys1st.count++;
            CenterSys1st.RotateController = true;
            CenterSys5th.count++;
            CenterSys5th.RotateController = true;
        }
    }
}
