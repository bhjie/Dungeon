using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseFire : MonoBehaviour {

    public GameObject fire;
    public int flag=0;
	// Use this for initialization
	void Start () {
        if (flag == 0)
            fire.SetActive(false);
        else
            fire.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Rises()
    {
        flag = 1 - flag;
        if (flag == 1)
        {
            fire.SetActive(true);
        }
        else
            fire.SetActive(false);
    }
}
