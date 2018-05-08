using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycamera : MonoBehaviour {
    private GameObject Player;
    public float smoothing = 5f;
    public Vector3 dis;
    Vector3 targetCamPos;
    Vector3 offset;
    // Use this for initialization
    void Start () {
        this.gameObject.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
            transform.position = Player.transform.position + dis;
            transform.forward = Player.transform.position - transform.position;
        }
        
        offset = Player.transform.position + dis - transform.position;
        targetCamPos = transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

    }
}
