using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazemoving : MonoBehaviour {

    public int direction = 1;
    public Vector3 start;
    public Vector3 target;
    public float smoothing = 5F;
    private int act = 0;
    private int scriptlock;
    private float timer;
    private int delaymoving = 0;
    private int ele=0;
    // Use this for initialization
    void Start () {
		if (this.gameObject.name.Contains("elevator"))
        {
            ele = 1;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (direction == 1 && scriptlock == 0 && act == 1) 
        {
            Vector3 vec = target;
            transform.position = Vector3.Lerp(transform.position, vec, smoothing * Time.deltaTime);
       
        }
        if (direction == 0 && scriptlock == 0 && act == 1) 
        {
            Vector3 vec = start;
            transform.position = Vector3.Lerp(transform.position, vec, smoothing * Time.deltaTime);
        }
        if (delaymoving==1 && direction == 0 && scriptlock == 0 && ele==0)
        {
            timer += Time.deltaTime;
            if (timer>=1f)
            {
                Vector3 vec = start;
                transform.position = Vector3.Lerp(transform.position, vec, smoothing * Time.deltaTime);
            }
            if (transform.position==start)
            {
                delaymoving = 0;
            }
        }
    }

    public void Active()
    {
        act = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scriptlock = 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scriptlock = 0;
            if (act==1)
            {
                delaymoving = 1;
                timer = 0f;
            }
            act = 0;
        }
    }
}
