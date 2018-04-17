using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {
    private int locks = 0;
    public Vector3 targetpos;
    public Vector3 startpos;
    public float smoothing;
    public int scriptlock = 0;
    void Start () {
        transform.position = startpos;
    }
	
	void FixedUpdate()
    {
        if (locks == 1 && scriptlock==0)
        {
            Vector3 vec = targetpos;
            transform.position = Vector3.Lerp(transform.position, vec, smoothing * Time.deltaTime);
        }
        
    }
    public void Appear()
    {
        locks = 1;
    }

    
}
