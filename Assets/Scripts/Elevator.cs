using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public Vector3 point_1;
    public Vector3 point_2;
    public GameObject door1;
    public GameObject door2;
    public GameObject minmap;


    public float up;
    private float dir = 1;
    private int open = 0;
    public float smoothing = 2f;
    public float delay = 2f;
    private float timer;
    private int swapcamera = 0;
    private Vector3 vec;
    private Vector3 vec_2;

    private SwapCamera came;
    // Use this for initialization
    void Start()
    {
        vec = point_1;
        vec_2 = point_2;
        timer = 0;
        came = GetComponent<SwapCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (open == 1 && dir == 1)
        {
            vec = point_1;
            vec_2 = point_2;
            //transform.position = transform.position + (vec_2 - vec).normalized * smoothing * Time.deltaTime;
            transform.Translate(Vector3.up * Time.deltaTime * smoothing * up,Space.World);
            timer += Time.deltaTime;
        }
        if (open == 1 && dir == 0)
        {
            vec = point_2;
            vec_2 = point_1;
            //transform.position = transform.position + (vec_2 - vec).normalized * smoothing * Time.deltaTime;
            transform.Translate(-Vector3.up * Time.deltaTime * smoothing * up, Space.World);
            timer += Time.deltaTime;
        }
        if (dir == 1 && timer >= (vec_2 - vec).magnitude / smoothing && open == 1) 
        {
            open = 0;
            dir = 1 - dir;
            timer = 0;
        }
        if (dir == 0 && timer >= (vec_2 - vec).magnitude / smoothing && open == 1)
        {
            open = 0;
            dir = 1 - dir;
            timer = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (door1.GetComponent<Rotate>().state==1)
            {
                door1.GetComponent<Rotate>().StartRotate();
                door2.GetComponent<Rotate>().StartRotate();
            }

            StartCoroutine(MyMethod());

            
        }
    }


    IEnumerator MyMethod()
    {
        yield return new WaitForSeconds(delay);
        open = 1;
        if (swapcamera==0)
        {
            came.SwitchCamera();
            swapcamera = 1;
        }
        
        if (dir ==1 && up==-1 || dir==0 && up==1)
        {
            yield return new WaitForSeconds((point_1-point_2).magnitude/smoothing);

            if (door1.GetComponent<Rotate>().state == 0)
            {
                door1.GetComponent<Rotate>().StartRotate();
                door2.GetComponent<Rotate>().StartRotate();
                came.SwitchCameraBack();
                swapcamera = 0;
            }
            
        }
        if (dir == 0 && up == -1 || dir == 1 && up == 1)
        {
            yield return new WaitForSeconds((point_1 - point_2).magnitude / smoothing);
            if (swapcamera == 1)
            {
                came.SwitchCameraBack();
                swapcamera = 0;
            }
        }
    }
}
