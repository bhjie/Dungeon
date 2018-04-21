using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

    public static bool trigger;
    public GameObject Player;
    Vector3 backPosition;
    Vector3 frontPosition;
    Vector3 playerPosition;

    void Start()
    {
        trigger = false;
        backPosition = new Vector3(0, -5, 5);
        frontPosition = new Vector3(0, -5, 0);
        playerPosition = new Vector3(-10, -5, 0);
    }

    void FixedUpdate()
    {
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
    }
}
