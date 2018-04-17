using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject Player;
    public float smoothing = 5f;
    Vector3 targetCamPos;
    public Vector3 offset = new Vector3(-0.8f, 9f, -5f);
    Vector3 highspeed;
    Vector3 rot;
    Rigidbody rig;
    void Start () {
        Player = GameObject.Find("Player");
    }
	
	void FixedUpdate () {
        if(Player == null) Player = GameObject.Find("Player");
        targetCamPos = Player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        
        
    }


}
