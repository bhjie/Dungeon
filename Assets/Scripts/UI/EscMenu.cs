using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour {

	void Start () {
		
	}

	void Update ()
    {
		if(Input.GetKey(KeyCode.Escape) && HealthManage.LiveOrNot)
        {
            if(GameManage.IsPause)
            {
                GameManage.IsPause = false;
                GameManage.ResumeGame();
            }
            else
            {
                GameManage.IsPause = true;
                GameManage.PauseGame();
            }
        }
	}
}
