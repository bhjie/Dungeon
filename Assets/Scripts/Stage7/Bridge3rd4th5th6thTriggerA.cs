﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge3rd4th5th6thTriggerA : MonoBehaviour {

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
            if (Bridge4thController.state == 1)
            {
                Bridge3rdTriggerA.working = 1;
                Bridge3rdController.state = -1;
                Bridge3rdController.RotateController = true;
                Bridge3rdEndController.state = 0;
                Bridge3rdEndController.RotateController = true;

                Bridge4thTriggerA.working = 0;
                Bridge4thController.state = 0;
                Bridge4thController.RotateController = true;
                Bridge4thEndController.state = 1;
                Bridge4thEndController.RotateController = true;

            }
            else
            {
                Bridge4thTriggerA.working = 1;
                Bridge4thController.state = 1;
                Bridge4thController.RotateController = true;
                Bridge4thEndController.state = 0;
                Bridge4thEndController.RotateController = true;

                Bridge3rdTriggerA.working = 0;
                Bridge3rdController.state = 0;
                Bridge3rdController.RotateController = true;
                Bridge3rdEndController.state = -1;
                Bridge3rdEndController.RotateController = true;

            }
            if (Bridge6thController.state == 1)
            {
                Bridge5thTriggerA.working = 1;
                Bridge5thController.state = -1;
                Bridge5thController.RotateController = true;
                Bridge5thEndController.state = 0;
                Bridge5thEndController.RotateController = true;

                Bridge6thTriggerA.working = 0;
                Bridge6thController.state = 0;
                Bridge6thController.RotateController = true;
                Bridge6thEndController.state = 1;
                Bridge6thEndController.RotateController = true;

            }
            else
            {
                Bridge6thTriggerA.working = 1;
                Bridge6thController.state = 1;
                Bridge6thController.RotateController = true;
                Bridge6thEndController.state = 0;
                Bridge6thEndController.RotateController = true;

                Bridge5thTriggerA.working = 0;
                Bridge5thController.state = 0;
                Bridge5thController.RotateController = true;
                Bridge5thEndController.state = -1;
                Bridge5thEndController.RotateController = true;

            }
        }
    }
}