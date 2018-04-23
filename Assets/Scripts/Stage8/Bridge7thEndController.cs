using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge7thEndController : MonoBehaviour {

    public static int state;  //0表示平行，1上仰，-1下俯
    public static bool RotateController;
    private Quaternion targetRotation;    //声明旋转目标角度
    public float RotateAngle = 135;       //定义每次旋转的角度

    void Start()
    {
        state = -1;
    }

    void Update()
    {
        if (RotateController)
        {
            targetRotation = Quaternion.Euler(0, -180, RotateAngle * state + Bridge7thController.RotateAngle * Bridge7thController.state) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);

            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.01f)
            {
                transform.rotation = targetRotation;                        //当物体当前角度与目标角度差值小于1度直接将目标角度赋予物体 让旋转角度精确到我们想要的度数
                RotateController = false;
            }
        }
    }
}
