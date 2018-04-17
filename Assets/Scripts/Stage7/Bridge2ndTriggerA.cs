using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge2ndTriggerA : MonoBehaviour {

    private Vector3 offset;
    public static int working;
    private float oriY;

    void Start () {
        offset = new Vector3(0, 0.1f, 0f);
        working = 0;
        transform.position += offset;
        oriY = transform.position.y;
    }
	
	void Update () {
        if (working == 1)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - offset, 1f * Time.deltaTime);
        }
        if (working == 1 && transform.position.y < oriY - 0.1f)
        {
            working = 2;
        }
        if(working == 0 && transform.position.y < oriY)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + offset, 1f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(working == 0 && collision.gameObject.CompareTag("Player"))
        {
            working = 1;
            Bridge2ndController.state = 1;
            Bridge2ndController.RotateController = true;
            Bridge2ndEndController.state = 0;
            Bridge2ndEndController.RotateController = true;

            Bridge1stTriggerA.working = 0;
            Bridge1stController.state = 0;
            Bridge1stController.RotateController = true;
            Bridge1stEndController.state = -1;
            Bridge1stEndController.RotateController = true;
        }
    }
}
