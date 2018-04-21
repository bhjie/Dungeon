using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartAdventure : MonoBehaviour {

    public static bool trigger;
    public GameObject Player;
    Vector3 backPosition;
    Vector3 frontPosition;
    Vector3 playerPosition;

	void Start () {
        trigger = true;
        backPosition = new Vector3(0, 5, 5);
        frontPosition = new Vector3(0, 5, 0);
        playerPosition = new Vector3(-15, 5, 0);
        Rigidbody rg3d = Player.GetComponent<Rigidbody>();
        rg3d.angularVelocity = new Vector3(1, 1, 1);
	}
	
	void FixedUpdate () {
        if(transform.position.z > 2f)
        {
            SceneManager.LoadSceneAsync("Stage1");
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
	}
}
