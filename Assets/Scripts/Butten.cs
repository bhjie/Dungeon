using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butten : MonoBehaviour {

    public GameObject[] obj;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i=0;i<obj.Length;i++)
            {
                obj[i].GetComponent<RiseFire>().Rises();
            }
        }
    }
}
