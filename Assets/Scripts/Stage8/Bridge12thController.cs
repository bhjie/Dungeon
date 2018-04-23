using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge12thController : MonoBehaviour {

    public static int state;  //0表示平行，1上仰，-1下俯
    public static bool RotateController;
    private Quaternion targetRotation;
    public static float RotateAngle = 20;

    void Start()
    {
        state = 1;
    }

    void Update()
    {
        if (RotateController)
        {
            targetRotation = Quaternion.Euler(0, 0, RotateAngle * state) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);

            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                RotateController = false;
            }
        }
    }
}
