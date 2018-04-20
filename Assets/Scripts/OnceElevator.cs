using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnceElevator : MonoBehaviour {
    public Vector3 point_1;
    public float smoothing = 2f;
    public float delay = 2f;
    private int open = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (open == 1)
        {
            Vector3 vec = point_1;
            transform.position = Vector3.Lerp(transform.position, vec, smoothing * Time.deltaTime);
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
