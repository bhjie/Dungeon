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
    public static float RotationOffsetY;
    float RotationOffsetX;
    float rotatespeed;
    public float originRotationY = 10;
    public float originRotationX = 60;

    void Start () {
        rotatespeed = 2f;
        RotationOffsetY = originRotationY;
        RotationOffsetX = originRotationX;
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
            if (Input.GetKey(KeyCode.Q))
            {
                RotationOffsetY = RotationOffsetY - rotatespeed;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                RotationOffsetY = RotationOffsetY + rotatespeed;
            }


            targetCamPos = Player.transform.position + Quaternion.AngleAxis(RotationOffsetY, Vector3.up) * offset;

            if(Input.GetAxis("Mouse ScrollWheel") > 0 && offset.y < 25)
            {
                offset = 1.1f * offset;
            }
            if(Input.GetAxis("Mouse ScrollWheel") < 0 && offset.y > 5)
            {
                offset = 0.9f * offset;
            }

            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

            targetRotation = Quaternion.Euler(originRotationX, RotationOffsetY, 0) * Quaternion.identity;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);
            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.1f)
            {
                transform.rotation = targetRotation;
            }
        }
        else if(CameraModel == 2)
        {
            float moveY = 0;
            if(Input.GetKey(KeyCode.Q))
            {
                RotationOffsetY = RotationOffsetY - rotatespeed;
            }
            else if(Input.GetKey(KeyCode.E))
            {
                RotationOffsetY = RotationOffsetY + rotatespeed;
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                moveY = -1;
            }
            else if(Input.GetKey(KeyCode.Space))
            {
                moveY = 1;
            }
            

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                offset2 = offset2 + transform.forward;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                offset2 = offset2 - transform.forward;
            }


            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            cameramovement = new Vector3(moveX, 2 * moveY, 0);
            RotationOffsetX = RotationOffsetX - moveZ;

            targetRotation = Quaternion.Euler(RotationOffsetX, RotationOffsetY, 0) * Quaternion.identity;

            cameramovement = Quaternion.AngleAxis(RotationOffsetY, Vector3.up) * cameramovement;

            offset2 = offset2 + cameramovement;
            targetCamPos = Player.transform.position + offset2;


            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3f);

            
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
            if (Quaternion.Angle(targetRotation, transform.rotation) < 0.1f)
            {
                transform.rotation = targetRotation;
            }
        }
        
        if(timelock && Input.GetKey(KeyCode.V) && HealthManage.LiveOrNot)
        {
            
            if (CameraModel == 1)
            {
                offset2 = 1.5f * offset;
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
