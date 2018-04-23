using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinmapInCastle : MonoBehaviour {

    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player==null)
        {
            player = GameObject.Find("Player");
        }

        if (player.transform.position.y<0 && player.transform.position.x>0)
        {
            transform.position = new Vector3(25, 0, 0);
        }
        if (player.transform.position.y>0 && player.transform.position.y<10 && player.transform.position.x > 0)
        {
            transform.position = new Vector3(25, 10, 0);
        }
        if (player.transform.position.y > 10 && player.transform.position.y < 25 && player.transform.position.x > 0)
        {
            transform.position = new Vector3(25, 25, 0);
        }
        if (player.transform.position.y > 25 && player.transform.position.y < 35 && player.transform.position.x > 0)
        {
            transform.position = new Vector3(25, 35, 0);
        }
    }
}
