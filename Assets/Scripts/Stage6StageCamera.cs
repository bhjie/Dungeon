using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage6StageCamera : MonoBehaviour {

    private GameObject player;

    private Vector3 level1pos = new Vector3(0, 35, 0);
    private Vector3 level2pos = new Vector3(0, 70, 0);

	void Start ()
    {
        player = GameObject.Find("Player");
	}
	

	void Update ()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
        }
		if(player.transform.position.y > 15f)
        {
            transform.position = Vector3.Lerp(transform.position, level2pos, 5f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, level1pos, 5f * Time.deltaTime);
        }
	}
}
