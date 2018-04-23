using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSys4th : MonoBehaviour {

    private Quaternion targetRotation;
    public float RotateAngle = 90;
    public static int count;
    public static bool RotateController = false;

    private void Start()
    {
        count = 0;
    }

    void Update()
    {
        if (RotateController)
        {
            targetRotation = Quaternion.Euler(0, RotateAngle * count, 0) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);

            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                RotateController = false;
            }
        }
    }
}
