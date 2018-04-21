using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAndDoor : MonoBehaviour {

    public GameObject[] fire;
    public GameObject door1;
    public GameObject door2;
    private int size;
    private int locking = 1;
    private int sum=0;
	// Use this for initialization
	void Start () {
        size = fire.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (locking==1)
        {
            for (int i=0;i<size;i++)
            {
                sum += fire[i].GetComponent<RiseFire>().flag;
            }
            if (sum == size)
            {
                door1.GetComponent<Rotate>().StartRotate();
                door2.GetComponent<Rotate>().StartRotate();
                sum = 0;
                locking = 0;
            }
            else
                sum = 0;
        }
	}
}
