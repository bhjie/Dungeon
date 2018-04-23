using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageFinish : MonoBehaviour {

    public Text CongratulationsText;
    public Text PlayAgainText;
    public Text TitleText;

    

    private float timeCount;
    private int selection;
    private bool congratulationsTextLock;

    void Start ()
    {
        GameManage.IfFinish = false;
        timeCount = 0f;
        selection = 2;
        congratulationsTextLock = true;
    }
	
	void Update ()
    {
        if (GameManage.IfFinish && congratulationsTextLock)
        {
            CongratulationsText.rectTransform.localScale = CongratulationsText.rectTransform.localScale * 1.1f;
            if(CongratulationsText.rectTransform.localScale.x > 1.5)
            {
                congratulationsTextLock = false;
            }
        }

        timeCount = timeCount + Time.deltaTime;

        if (timeCount > 0.3f && GameManage.IfFinish)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                timeCount = 0;
                if (selection == 1)
                {
                    selection = 2;
                    PlayAgainText.color = Color.black;
                    TitleText.color = Color.red;
                }
                else if (selection == 2)
                {
                    selection = 1;
                    TitleText.color = Color.black;
                    PlayAgainText.color = Color.red;
                }
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                timeCount = 0;
                if (selection == 1)
                {
                    selection = 2;
                    PlayAgainText.color = Color.black;
                    TitleText.color = Color.red;
                }
                else if (selection == 2)
                {
                    selection = 1;
                    TitleText.color = Color.black;
                    PlayAgainText.color = Color.red;
                }
            }
        }

        if (timeCount > 0.3f && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)) && IfFinish)
        {
            if (selection == 1)
            {
                GameManage.IfFinish = false;
                GameManage.RestartGame();
            }
            else if (selection == 2)
            {
                GameManage.IfFinish = false;
                SceneManager.LoadSceneAsync("StartMenu");
            }
        }
    }
}
