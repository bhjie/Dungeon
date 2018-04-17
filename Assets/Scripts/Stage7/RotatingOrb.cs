using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingOrb : MonoBehaviour {

    private float origionY;                //声明初始的Y轴旋转值
    private Quaternion targetRotation;    //声明旋转目标角度
    public float RotateAngle = 90;       //定义每次旋转的角度
    public static int count = 1;                  //声明一个量记录到目标角度需要进行旋转RotateAngle度的个数
                                        // 由于每次旋转转  90(RotateAngle）度，所以从（0，0，0）到（0，180，0）需要旋转两个 90(RotateAngle) 度
    public static bool RotateController = false;


    private void Start()
    {
        origionY = transform.rotation.y;    //获取当前Y轴旋转值赋给origionY
    }

    void Update()
    {
        if (RotateController)
        {
            targetRotation = Quaternion.Euler(0, RotateAngle * count + origionY, 0) * Quaternion.identity;  //给旋转目标值赋值，由于只有Y轴动，所以目标值应是  (旋转角(RotateAngle)*需要旋转的个数(count)+origionY(物体初始Y轴旋转角))*Quarternion.identity(四元数的初始值,记住写就行！)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.2f);//利用Slerp插值让物体进行旋转  2是旋转速度 越大旋转越快

            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.1f)
            {
                transform.rotation = targetRotation;                        //当物体当前角度与目标角度差值小于1度直接将目标角度赋予物体 让旋转角度精确到我们想要的度数
                RotateController = false;
            }
        }
    }
}
