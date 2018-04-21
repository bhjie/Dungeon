using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour {

    float timeCount;
    bool timeLock;

	void Start () {
        timeCount = 0;
        timeLock = true;
	}

	void FixedUpdate () {
        float num = RenderSettings.skybox.GetFloat("_Rotation");
        RenderSettings.skybox.SetFloat("_Rotation", num + 0.05f);

        timeCount = timeCount + Time.deltaTime;
        if(timeCount > 0.5f)
        {
            timeLock = true;
            timeCount = 0;
        }

        if(timeLock)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                timeLock = false;
                if (StartAdventure.trigger)
                {
                    StartAdventure.trigger = false;
                    QuitGame.trigger = true;
                }
                else if (SelectStage.trigger)
                {
                    SelectStage.trigger = false;
                    StartAdventure.trigger = true;
                }
                else if (QuitGame.trigger)
                {
                    QuitGame.trigger = false;
                    SelectStage.trigger = true;
                }
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                timeLock = false;
                if (StartAdventure.trigger)
                {
                    StartAdventure.trigger = false;
                    SelectStage.trigger = true;
                }
                else if (SelectStage.trigger)
                {
                    SelectStage.trigger = false;
                    QuitGame.trigger = true;
                }
                else if (QuitGame.trigger)
                {
                    QuitGame.trigger = false;
                    StartAdventure.trigger = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.Return))
        {
            if(QuitGame.trigger)
            {
                Application.Quit();
            }
            else if(StartAdventure.trigger)
            {
                PlayerShoot.model = 1;
                StartAdventure.trigger = false;
            }
            else if(SelectStage.trigger)
            {
                PlayerShoot.model = 2;
                SelectStage.trigger = false;
            }
            
        }
    }
}
