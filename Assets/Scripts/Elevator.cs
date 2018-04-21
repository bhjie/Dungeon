using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public Vector3 point_1;
    public Vector3 point_2;
    private int dir = 1;
    private int open = 0;
    public float smoothing = 2f;
    public float delay = 2f;
    private float timer;
    private Vector3 vec;
    private Vector3 vec_2;
    // Use this for initialization
    void Start()
    {
        vec = point_1;
        vec_2 = point_2;
        timer = (vec_2 - vec).magnitude / smoothing;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (open == 1 && dir == 1)
        {
            vec = point_1;
            vec_2 = point_2;
            //transform.position = Vector3.Lerp(transform.position, vec, smoothing * Time.deltaTime);
            transform.position = transform.position + (vec_2 - vec).normalized * smoothing * Time.deltaTime;
            timer -= Time.deltaTime;
        }
        if (open == 1 && dir == 0)
        {
            Vector3 vec = point_2;
            transform.position = Vector3.Lerp(transform.position, vec, smoothing * Time.deltaTime);
        }
        if (dir == 1 && timer<=0 && open == 1)
        {
            open = 0;
            dir = 1 - dir;
        }
        if (dir == 0 && timer<=0 && open == 1)
        {
            open = 0;
            dir = 1 - dir;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MyMethod());

        }
    }



    IEnumerator MyMethod()
    {
        yield return new WaitForSeconds(delay);
        open = 1;


    }
}
