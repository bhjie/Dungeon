using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFriction : MonoBehaviour {
    private GameObject player;
    private int flag;
    private Rigidbody PlayerRg3d;
    private Rigidbody thisRg3d;

    void Start () {
        flag = 0;
        player = GameObject.Find("Player");
        thisRg3d = GetComponent<Rigidbody>();
    }
	

	void FixedUpdate () {
        if (player == null || PlayerRg3d == null)
        {
            player = GameObject.Find("Player");
            PlayerRg3d = player.GetComponent<Rigidbody>();
        }
        if(thisRg3d == null)
        {
            thisRg3d = GetComponent<Rigidbody>();
        }
        if(flag == 1 && player != null && thisRg3d != null)
        {
            PlayerRg3d.AddForce((thisRg3d.velocity - PlayerRg3d.velocity) * 3);            
        }
    }

    private void OnCollisionStay(Collision other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            flag = 1;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            flag = 0;
        }
    }
}
