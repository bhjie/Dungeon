using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Gate : MonoBehaviour {

    bool flag = true;

    void OnCollisionEnter(Collision other)
    {
        if (flag && other.gameObject.CompareTag("Player"))
        {
            flag = false;
            Rigidbody rig;

            GameObject gate = GameObject.Find("Bridge2");
            Bridge gatebridge = gate.GetComponent<Bridge>();
            gatebridge.Appear();

            Object playerperfab_1 = Resources.Load("Perfabs/Enemy", typeof(GameObject));
            GameObject enemy_1 = Instantiate(playerperfab_1) as GameObject;
            enemy_1.transform.position = new Vector3(32f, 3.5f, 20f);
            enemy_1.name = "enemy_1";
            enemy_1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rig = enemy_1.GetComponent<Rigidbody>();
            rig.velocity = new Vector3(0, 0, -10);

            Object playerperfab_2 = Resources.Load("Perfabs/Enemy", typeof(GameObject));
            GameObject enemy_2 = Instantiate(playerperfab_2) as GameObject;
            enemy_2.transform.position = new Vector3(34f, 3.5f, 20f);
            enemy_2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            enemy_2.name = "enemy_2";
            rig = enemy_2.GetComponent<Rigidbody>();
            rig.velocity = new Vector3(0, 0, -10);
        }
    }
}
