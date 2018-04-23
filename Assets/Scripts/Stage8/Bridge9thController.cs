using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge9thController : MonoBehaviour {

    public static int state; 
    public static bool RotateController;
    private Quaternion targetRotation;    
    public static float RotateAngle = 20;  

    void Start()
    {
        state = 0;
    }

    void Update()
    {
        if (RotateController)
        {
            targetRotation = Quaternion.Euler(0, -180, RotateAngle * state) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);

            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.1f)
            {
                transform.rotation = targetRotation;   
                RotateController = false;
            }
        }
    }
}
