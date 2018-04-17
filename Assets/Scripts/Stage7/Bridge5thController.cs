using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge5thController : MonoBehaviour {

    private float origionZ;
    public static int state;  //0表示平行，1上仰，-1下俯
    public static bool RotateController;
    private Quaternion targetRotation;    //声明旋转目标角度
    public static float RotateAngle = 20;       //定义每次旋转的角度

    void Start()
    {
        state = 0;
        origionZ = transform.rotation.z;
    }

    void Update()
    {
        if (RotateController)
        {
            targetRotation = Quaternion.Euler(0, 0, RotateAngle * state + origionZ) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);

            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.1f)
            {
                transform.rotation = targetRotation;                        //当物体当前角度与目标角度差值小于1度直接将目标角度赋予物体 让旋转角度精确到我们想要的度数
                RotateController = false;
            }
        }
    }
}
