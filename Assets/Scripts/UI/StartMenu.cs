using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour {

    public GameObject confirm;

    private float timeCount;
    private AudioSource sound;
    private float num;
    private AudioSource confirmsound;

    void Start () {
        timeCount = 0;
        sound = GetComponent<AudioSource>();
        confirmsound = confirm.GetComponent<AudioSource>(); 
        num = RenderSettings.skybox.GetFloat("_Rotation");
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }

    void FixedUpdate () {
        num = RenderSettings.skybox.GetFloat("_Rotation");
        RenderSettings.skybox.SetFloat("_Rotation", num + 0.05f);

        timeCount = timeCount + Time.deltaTime;

        if(timeCount > 0.5f)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                timeCount = 0;
                sound.Play();
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
                timeCount = 0;
                sound.Play();
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

        if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)) && timeCount > 0.2f)
        {
            if(QuitGame.trigger)
            {
                RenderSettings.skybox.SetFloat("_Rotation", 0);
                Application.Quit();
            }
            else if(StartAdventure.trigger)
            {
                confirmsound.Play();
                PlayerShoot.model = 1;
                StartAdventure.trigger = false;
            }
            else if(SelectStage.trigger)
            {
                confirmsound.Play();
                PlayerShoot.model = 2;
                SelectStage.trigger = false;
            }
            
        }
    }
}
