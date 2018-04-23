using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge8thEndController : MonoBehaviour {

    public static int state;  //0表示平行，1上仰，-1下俯
    public static bool RotateController;
    private Quaternion targetRotation; 
    public float RotateAngle = 135;  

    void Start()
    {
        state = 1;
    }

    void Update()
    {
        if (RotateController)
        {
            targetRotation = Quaternion.Euler(0, 0, RotateAngle * state + Bridge8thController.RotateAngle * Bridge8thController.state) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);

            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                RotateController = false;
            }
        }
    }
}
