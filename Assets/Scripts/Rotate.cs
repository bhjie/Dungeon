using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {


    public Vector3 dir; //旋转方向，1为顺时针，-1为逆时针
    public float angle; //旋转角度
    public GameObject axis; //中心轴
    private int open=0; //活动状态
    private float rotate;   //当前旋转角度

    public int state = 0; //g关闭时为0，开启时为1
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (open==1 && state==0)
        {
            transform.RotateAround(axis.transform.position, dir, 30 * Time.deltaTime);
            rotate += 30 * Time.deltaTime;
            if (rotate>=angle)
            {
                open = 0;
                state = 1;
                rotate = 0;
            }
        }
        if (open==1 &&state==1)
        {
            transform.RotateAround(axis.transform.position, -dir, 30 * Time.deltaTime);
            rotate += 30 * Time.deltaTime;
            if (rotate >= angle)
            {
                open = 0;
                state = 0;
                rotate = 0;
            }
        }
	}

    public void StartRotate()
    {
        open = 1;
    }
}
