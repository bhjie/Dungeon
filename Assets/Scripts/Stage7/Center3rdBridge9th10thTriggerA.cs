using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center3rdBridge9th10thTriggerA : MonoBehaviour {

    private Vector3 offset;
    private int working;
    private float oriY;

    void Start()
    {
        offset = new Vector3(0, 0.1f, 0f);
        working = 0;
        transform.position += offset;
        oriY = transform.position.y;
    }

    void Update()
    {
        if (working == 1)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - offset, 1f * Time.deltaTime);
        }
        if (working == 1 && transform.position.y < oriY - 0.1f)
        {
            working = 2;
        }
        if (working == 2)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + offset, 1f * Time.deltaTime);
        }
        if (working == 2 && transform.position.y > oriY)
        {
            working = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (working == 0 && collision.gameObject.CompareTag("Player"))
        {
            working = 1;
            CenterSys3rd.count++;
            CenterSys3rd.RotateController = true;
            CenterSys7th.count++;
            CenterSys7th.RotateController = true;
            if (Bridge10thController.state == 1)
            {
                Bridge9thTriggerA.working = 1;
                Bridge9thController.state = -1;
                Bridge9thController.RotateController = true;
                Bridge9thEndController.state = 0;
                Bridge9thEndController.RotateController = true;

                Bridge10thTriggerA.working = 0;
                Bridge10thController.state = 0;
                Bridge10thController.RotateController = true;
                Bridge10thEndController.state = 1;
                Bridge10thEndController.RotateController = true;

            }
            else
            {
                Bridge10thTriggerA.working = 1;
                Bridge10thController.state = 1;
                Bridge10thController.RotateController = true;
                Bridge10thEndController.state = 0;
                Bridge10thEndController.RotateController = true;

                Bridge9thTriggerA.working = 0;
                Bridge9thController.state = 0;
                Bridge9thController.RotateController = true;
                Bridge9thEndController.state = -1;
                Bridge9thEndController.RotateController = true;

            }
        }
    }
}
