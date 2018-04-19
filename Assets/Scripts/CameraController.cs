using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private int CameraModel;      //1为小球视角，2为自由视角
    private GameObject Player;
    public GameObject ui;
    public float smoothing = 5f;
    Vector3 targetCamPos;
    public Vector3 offset = new Vector3(-0.8f, 9f, -5f);
    private Vector3 cameramovement;
    private Vector3 offset2;
    private Quaternion targetRotation;
    private int counttime;
    private bool timelock;
    float rotationoffset;
    float rotatespeed;

    void Start () {
        rotatespeed = 3f;
        rotationoffset = 0;
        CameraModel = 1;
        Player = GameObject.Find("Player");
        offset2 = 1.5f * offset;
        counttime = 0;
        timelock = true;
    }
	
	void FixedUpdate () {
        counttime++;
        if(counttime == 20)
        {
            counttime = 0;
            timelock = true;
        }
        if (Player == null)
        {
            Player = GameObject.Find("Player");
        }

        if(CameraModel == 1)
        {
            targetCamPos = Player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
        else if(CameraModel == 2)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                rotationoffset = rotationoffset - rotatespeed;
            }
            else if(Input.GetKey(KeyCode.E))
            {
                rotationoffset = rotationoffset + rotatespeed;
            }
            targetRotation = Quaternion.Euler(0, rotationoffset, 0) * Quaternion.identity;

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            float moveY = Input.GetAxis("Mouse ScrollWheel");
            cameramovement = new Vector3(moveX, 15 * moveY, moveZ);
            offset2 = offset2 + cameramovement;
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + offset2, smoothing * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1f);

        }
        
        if(timelock && Input.GetKey(KeyCode.V))
        {
            
            if (CameraModel == 1)
            {
                CameraModel = 2;
                PlayerMovement.FreezePlayer();
                ui.SetActive(false);
            }
            else
            {
                CameraModel = 1;
                PlayerMovement.UnFreezePlayer();
                ui.SetActive(true);
            }
            counttime = 0;
            timelock = false;
        }
    }


}
