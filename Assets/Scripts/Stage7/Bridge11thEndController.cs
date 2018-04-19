using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge11thEndController : MonoBehaviour {

    public static int state;
    public static bool RotateController;
    private Quaternion targetRotation;
    public float RotateAngle = 135;

    void Start()
    {
        state = -1;
    }

    void Update()
    {
        if (RotateController)
        {
            targetRotation = Quaternion.Euler(0, -180, RotateAngle * state + Bridge11thController.RotateAngle * Bridge11thController.state) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);

            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.01f)
            {
                transform.rotation = targetRotation;
                RotateController = false;
            }
        }
    }
}
