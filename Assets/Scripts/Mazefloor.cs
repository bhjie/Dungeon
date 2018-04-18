﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazefloor : MonoBehaviour {

    public GameObject[] movefloor;
    public float delay=1f;
    public Vector3 start;
    Vector3 swap;
    private int appear = 0;     //接触这个平面的时候将变为活动状态，离开时变为静止状态
    private float timer = 0f;   //计时器，用来延迟下落
    private int stay = 0;       //表示小球是否接触这个平面
    private int locking = 0;     //在这个平面激活后只要还在这个平面上就不会发生其他滑动效果
    private int outlock = 0;
    private Mazemoving bri;
    // Use this for initialization
    void Start () {
        bri = this.gameObject.GetComponent<Mazemoving>();

	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        
	}

    public void Emerge()
    {
        for (int i = 0; i < movefloor.Length; i++)
        {
            Mazemoving obj = movefloor[i].GetComponent<Mazemoving>();
            obj.direction = 1;
            obj.Active();
        }
        locking = 1;
    }

    public void Landed()
    {
        for (int i = 0; i < movefloor.Length; i++)
        {
            Mazemoving obj = movefloor[i].GetComponent<Mazemoving>();
            obj.direction = 0;
            obj.Active();

        }
        locking = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            appear = 1;
            if (locking==0)
                Emerge();
            outlock = 1;
           
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            appear = 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            appear = 0;
            timer = 0f;
            StartCoroutine(MyMethod());
            outlock = 0;
        }
    }
    IEnumerator MyMethod()
    {
        yield return new WaitForSeconds(0.5f);
        if (locking == 1 && appear == 0)
        {
            Landed();
            
        }
            
    }
}
