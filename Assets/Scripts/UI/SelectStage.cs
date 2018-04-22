using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStage : MonoBehaviour {

    public GameObject SelectStageUI;

    public static bool trigger;
    public GameObject Player;
    Vector3 backPosition;
    Vector3 frontPosition;
    Vector3 playerPosition;

    void Start()
    {
        trigger = false;
        backPosition = new Vector3(0, 0, 5);
        frontPosition = new Vector3(0, 0, 0);
        playerPosition = new Vector3(-11, 0, 0);
    }

    void FixedUpdate()
    {
        if (PlayerShoot.model == 4 && transform.position.z > 6f)
        {
            SelectStageUI.SetActive(true);
            PlayerShoot.model = 5;
        }

        if (PlayerShoot.model == 0)
        {
            if (trigger)
            {
                transform.position = Vector3.Lerp(transform.position, frontPosition, 5f * Time.deltaTime);
                Player.transform.position = Vector3.Lerp(Player.transform.position, playerPosition, 5f * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, backPosition, 5f * Time.deltaTime);
            }
        }
        else if (PlayerShoot.model == 6)
        {
            Rigidbody rg3d = GetComponent<Rigidbody>();
            rg3d.velocity = new Vector3(0, 0, 0);
            PlayerShoot.model = 0;
        }
    }
}
