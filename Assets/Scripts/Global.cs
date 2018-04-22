﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour {
    public Vector3 point;

	void Start ()
    {
        LoadPlayer();
        if(GameManage.GameModel == 1)
        {
            if (SceneManager.GetActiveScene().name == "Stage4")
            {
                ItemManage.LoadItemStage4();
            }
            if (SceneManager.GetActiveScene().name == "Stage6")
            {
                ItemManage.LoadItemStage6();
            }
        }
    }

    void LoadPlayer()
    {
        Object playerperfab = Resources.Load("Perfabs/Player", typeof(GameObject));
        GameObject player = Instantiate(playerperfab) as GameObject;
        player.transform.position = point;
        player.name = "Player";
    }
	
}
