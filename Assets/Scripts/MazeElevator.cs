using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeElevator : MonoBehaviour {

    public Vector3 point_1;
    public Vector3 point_2;
    private int dir=1;
    private int open = 0;
    public float smoothing = 2f;
    public float delay = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (open==1 && dir==1)
        {
            Vector3 vec = point_1;
            transform.position = Vector3.Lerp(transform.position, vec, smoothing * Time.deltaTime);
        }
        if (open==1 && dir==0)
        {
            Vector3 vec = point_2;
            transform.position = Vector3.Lerp(transform.position, vec, smoothing * Time.deltaTime);
        }
        if (dir==1 && transform.position==point_1 && open==1)
        {
            open = 0;
            dir = 1 - dir;
        }
        if (dir == 0 && transform.position == point_2 && open==1)
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

    private void OnCollisionStay(Collision collision)
    {
        open = 1;
    }

    IEnumerator MyMethod()
    {
        yield return new WaitForSeconds(delay);
        open = 1;
        

    }
}
