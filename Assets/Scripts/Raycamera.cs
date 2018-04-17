using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycamera : MonoBehaviour {
    private GameObject Player;
    public float smoothing = 5f;
    public float dis;
    Vector3 targetCamPos;
    Vector3 offset;
    Vector3 rot;
    Rigidbody rig;
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        rig = Player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
            rig = Player.GetComponent<Rigidbody>();
        }
        offset = -rig.velocity.normalized * dis;
        transform.forward = Player.transform.position - transform.position;
        targetCamPos = Player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

    }
}
