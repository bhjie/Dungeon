using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRevivePoint : MonoBehaviour {

    public Vector3 point;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManage.RevivePoint = point;
        }
    }
}
