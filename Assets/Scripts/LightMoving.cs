using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMoving : MonoBehaviour {

    public float smoothing;
    public Vector3 distance;
    private Vector3 offset;
    private GameObject Player;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Player==null)
        {
            Player = GameObject.Find("Player");
            transform.position = Player.transform.position + distance;
        }
        offset = Player.transform.position + distance - transform.position;
        Vector3 targetCamPos = transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
