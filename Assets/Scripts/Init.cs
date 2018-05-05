using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour {
    public Vector3 point;

	void Start ()
    {
        GameManage.RevivePoint = point;
        LoadBGM();
        LoadPlayer();
        if(GameManage.GameModel == 1)
        {
            if (SceneManager.GetActiveScene().name == "Stage4")
            {
                ItemManage.LoadItemStage4();
            }
            if (SceneManager.GetActiveScene().name == "Stage5")
            {
                ItemManage.LoadItemStage5();
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

    void LoadBGM()
    {
        if(GameObject.Find("BGM") == null)
        {
            Object bgmperfab = Resources.Load("Perfabs/BGM", typeof(GameObject));
            GameObject bgm = Instantiate(bgmperfab) as GameObject;
            bgm.transform.position = point;
            bgm.name = "BGM";
            DontDestroyOnLoad(bgm);
        }      
    }	
}
