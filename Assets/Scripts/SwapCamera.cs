using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCamera : MonoBehaviour {

    // Use this for initialization
    public GameObject cameras;
    public Vector3 offset;
    private Vector3 temp;

    private void Start()
    {
        temp = cameras.GetComponent<CameraController>().offset;
    }
    void Update()
    {
        
        
    }

    public void SwitchCamera()
    {
        cameras.GetComponent<CameraController>().originRotationX = 90;
        temp = cameras.GetComponent<CameraController>().offset;
        cameras.GetComponent<CameraController>().offset = offset;
    }
    public void SwitchCameraBack()
    {
        cameras.GetComponent<CameraController>().originRotationX = 60;
        cameras.GetComponent<CameraController>().offset = temp;
    }

}
