using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour {

    public GameObject pausemask;
    public GameObject resumeText;
    public GameObject restartText;
    public GameObject titleText;

    private Text resumetext;
    private Text restarttext;
    private Text titletext;

    private float timeCount;
    private int selection; 

	void Start () {
        timeCount = 0;
        selection = 1;
        resumetext = resumeText.GetComponent<Text>();
        restarttext = restartText.GetComponent<Text>();
        titletext = titleText.GetComponent<Text>();
        resumetext.color = Color.red;
	}

	void Update ()
    {
        timeCount = timeCount + Time.deltaTime;
        if(!GameManage.IfFinish)
        {
            if (Input.GetKey(KeyCode.Escape) && HealthManage.LiveOrNot && timeCount > 0.3f)
            {
                if (GameManage.IsPause)
                {
                    timeCount = 0;
                    GameManage.IsPause = false;
                    GameManage.ResumeGame();
                    pausemask.SetActive(false);
                }
                else
                {
                    timeCount = 0;
                    GameManage.IsPause = true;
                    GameManage.PauseGame();
                    pausemask.SetActive(true);
                    selection = 1;
                    resumetext.color = Color.red;
                    restarttext.color = Color.black;
                    titletext.color = Color.black;
                }
            }

            if (timeCount > 0.3f && GameManage.IsPause)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    timeCount = 0;
                    if (selection == 1)
                    {
                        selection = 3;
                        resumetext.color = Color.black;
                        titletext.color = Color.red;
                    }
                    else if (selection == 2)
                    {
                        selection = 1;
                        restarttext.color = Color.black;
                        resumetext.color = Color.red;
                    }
                    else if (selection == 3)
                    {
                        selection = 2;
                        titletext.color = Color.black;
                        restarttext.color = Color.red;
                    }
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    timeCount = 0;
                    if (selection == 1)
                    {
                        selection = 2;
                        resumetext.color = Color.black;
                        restarttext.color = Color.red;
                    }
                    else if (selection == 2)
                    {
                        selection = 3;
                        restarttext.color = Color.black;
                        titletext.color = Color.red;
                    }
                    else if (selection == 3)
                    {
                        selection = 1;
                        titletext.color = Color.black;
                        resumetext.color = Color.red;
                    }
                }
            }

            if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)) && GameManage.IsPause)
            {
                if (selection == 1)
                {
                    GameManage.IsPause = false;
                    GameManage.ResumeGame();
                    pausemask.SetActive(false);
                }
                else if (selection == 2)
                {
                    GameManage.IsPause = false;
                    GameManage.RestartGame();
                }
                else if (selection == 3)
                {
                    GameManage.IsPause = false;
                    SceneManager.LoadSceneAsync("StartMenu");
                }
            }
        }
	}
}
