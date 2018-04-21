using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpentheDoor : MonoBehaviour {
    public string type;
    GameObject trigger;

    void Start () {
        trigger = GameObject.Find(type);
    }
	

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(type.Contains("Bridge"))
            {
                Bridge bridge_s = trigger.GetComponent<Bridge>();
                bridge_s.Appear();
            }
            if(type.Contains("ComponentEnable"))
            {
                ComponentEnable componentenable = trigger.GetComponent<ComponentEnable>();
                componentenable.UnLock();
            }
            StartCoroutine(EnableEffect());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (type.Contains("Bridge"))
            {
                Bridge bridge_s = trigger.GetComponent<Bridge>();
                bridge_s.Appear();
            }
            if (type.Contains("ComponentEnable"))
            {
                ComponentEnable componentenable = trigger.GetComponent<ComponentEnable>();
                componentenable.UnLock();
            }
            StartCoroutine(EnableEffect());
        }
    }

    IEnumerator EnableEffect()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }

}
