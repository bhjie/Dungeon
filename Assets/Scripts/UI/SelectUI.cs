using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectUI : MonoBehaviour {

    public GameObject stageView1;
    public GameObject stageView2;
    public GameObject stageView3;
    public GameObject stageView4;
    public Image View1pic;
    public Image View2pic;
    public Image View3pic;
    public Image View4pic;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public GameObject Player;

    private GameObject CenterView;
    private GameObject LeftView;
    private GameObject RightView;
    private GameObject OutView;

    private bool flagLeftToRight;
    private bool flagRightToLeft;

    private bool timeLock;
    private int nowStageNum;
    private int nextLoadStageNum;
    private int nowViewNum;
    private int numberOfStages;
    private string[] stagenames;

    private Vector3 origin;
    private float smooth;

    void Start ()
    {
        flagLeftToRight = false;
        flagRightToLeft = false;

        timeLock = true;
        nowStageNum = 1;
        nowViewNum = 1;
        numberOfStages = 8;

        origin = new Vector3(1, 1, 1);
        smooth = 6f;

        stagenames = new string[numberOfStages + 1];
        for(int i=1; i <= numberOfStages; i++)
        {
            stagenames[i] = "Stage" + i + "Pic";
        }

        text4.text = "STAGE-" + numberOfStages;
	}
	

	void Update ()
    {
        if(timeLock)
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                timeLock = false;
                nowStageNum++;
                if (nowStageNum > numberOfStages)
                {
                    nowStageNum = 1;
                }
                nextLoadStageNum = nowStageNum;

                nextLoadStageNum++;
                if (nextLoadStageNum > numberOfStages)
                {
                    nextLoadStageNum = 1;
                }

                Sprite newsprite = Resources.Load("Textures/" + stagenames[nextLoadStageNum], typeof(Sprite)) as Sprite;


                if (nowViewNum == 1)
                {
                    CenterView = stageView1;
                    LeftView = stageView4;
                    RightView = stageView2;
                    OutView = stageView3;
                    text3.text = "STAGE-" + nextLoadStageNum;
                    text1.color = Color.black;
                    text2.color = Color.red;
                    View3pic.sprite = newsprite;
                }
                else if(nowViewNum == 2)
                {
                    CenterView = stageView2;
                    LeftView = stageView1;
                    RightView = stageView3;
                    OutView = stageView4;
                    text4.text = "STAGE-" + nextLoadStageNum;
                    text2.color = Color.black;
                    text3.color = Color.red;
                    View4pic.sprite = newsprite;
                }
                else if (nowViewNum == 3)
                {
                    CenterView = stageView3;
                    LeftView = stageView2;
                    RightView = stageView4;
                    OutView = stageView1;
                    text1.text = "STAGE-" + nextLoadStageNum;
                    text3.color = Color.black;
                    text4.color = Color.red;
                    View1pic.sprite = newsprite;
                }
                else if (nowViewNum == 4)
                {
                    CenterView = stageView4;
                    LeftView = stageView3;
                    RightView = stageView1;
                    OutView = stageView2;
                    text2.text = "STAGE-" + nextLoadStageNum;
                    text4.color = Color.black;
                    text1.color = Color.red;
                    View2pic.sprite = newsprite;
                }

                RectTransform rect = OutView.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(1000, 0, 0);
                flagRightToLeft = true;
                nowViewNum++;
                if (nowViewNum > 4)
                {
                    nowViewNum = 1;
                }
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                timeLock = false;
                nowStageNum--;
                if (nowStageNum == 0)
                {
                    nowStageNum = numberOfStages;
                }
                nextLoadStageNum = nowStageNum;

                nextLoadStageNum--;
                if(nextLoadStageNum == 0)
                {
                    nextLoadStageNum = numberOfStages;
                }

                Sprite newsprite = Resources.Load("Textures/" + stagenames[nextLoadStageNum], typeof(Sprite)) as Sprite;

                if (nowViewNum == 1)
                {
                    CenterView = stageView1;
                    LeftView = stageView4;
                    RightView = stageView2;
                    OutView = stageView3;
                    text3.text = "STAGE-" + nextLoadStageNum;
                    text1.color = Color.black;
                    text4.color = Color.red;
                    View3pic.sprite = newsprite;
                }
                else if (nowViewNum == 2)
                {
                    CenterView = stageView2;
                    LeftView = stageView1;
                    RightView = stageView3;
                    OutView = stageView4;
                    text4.text = "STAGE-" + nextLoadStageNum;
                    text2.color = Color.black;
                    text1.color = Color.red;
                    View4pic.sprite = newsprite;
                }
                else if (nowViewNum == 3)
                {
                    CenterView = stageView3;
                    LeftView = stageView2;
                    RightView = stageView4;
                    OutView = stageView1;
                    text1.text = "STAGE-" + nextLoadStageNum;
                    text3.color = Color.black;
                    text2.color = Color.red;
                    View1pic.sprite = newsprite;
                }
                else if (nowViewNum == 4)
                {
                    CenterView = stageView4;
                    LeftView = stageView3;
                    RightView = stageView1;
                    OutView = stageView2;
                    text2.text = "STAGE-" + nextLoadStageNum;
                    text4.color = Color.black;
                    text3.color = Color.red;
                    View2pic.sprite = newsprite;
                }

                RectTransform rect = OutView.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(-1000, 0, 0);
                flagLeftToRight = true;
                nowViewNum--;
                if (nowViewNum == 0)
                {
                    nowViewNum = 4;
                }
            }
        }

        if(flagLeftToRight)
        {
            RectTransform rect = CenterView.GetComponent<RectTransform>();
            rect.localPosition = Vector3.Lerp(rect.localPosition, new Vector3(600, 30, 0), smooth * Time.deltaTime);
            rect.localScale = origin * (1f - rect.localPosition.x / 1200f);
            rect = LeftView.GetComponent<RectTransform>();
            rect.localPosition = Vector3.Lerp(rect.localPosition, new Vector3(0, 30, 0), smooth * Time.deltaTime);
            rect.localScale = origin * (1f + rect.localPosition.x / 1200f);
            rect = RightView.GetComponent<RectTransform>();
            rect.localPosition = Vector3.Lerp(rect.localPosition, new Vector3(1000, 30, 0), smooth * Time.deltaTime);
            rect = OutView.GetComponent<RectTransform>();
            rect.localPosition = Vector3.Lerp(rect.localPosition, new Vector3(-600, 30, 0), smooth * Time.deltaTime);
            if(rect.localPosition.x + 600 > -2f)
            {
                flagLeftToRight = false;
                timeLock = true;
            }
        }
        else if(flagRightToLeft)
        {
            RectTransform rect = CenterView.GetComponent<RectTransform>();
            rect.localPosition = Vector3.Lerp(rect.localPosition, new Vector3(-600, 30, 0), smooth * Time.deltaTime);
            rect.localScale = origin * (1f + rect.localPosition.x / 1200f);
            rect = LeftView.GetComponent<RectTransform>();
            rect.localPosition = Vector3.Lerp(rect.localPosition, new Vector3(-1000, 30, 0), smooth * Time.deltaTime);
            rect = RightView.GetComponent<RectTransform>();
            rect.localPosition = Vector3.Lerp(rect.localPosition, new Vector3(0, 30, 0), smooth * Time.deltaTime);
            rect.localScale = origin * (1f - rect.localPosition.x / 1200f);
            rect = OutView.GetComponent<RectTransform>();
            rect.localPosition = Vector3.Lerp(rect.localPosition, new Vector3(600, 30, 0), smooth * Time.deltaTime);
            if(rect.localPosition.x - 600 < 2f)
            {
                flagRightToLeft = false;
                timeLock = true;
            }
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            StartAdventure.trigger = false;
            SelectStage.trigger = true;
            QuitGame.trigger = false;
            PlayerShoot.model = 6;
            Rigidbody rg3d = Player.GetComponent<Rigidbody>();
            rg3d.angularVelocity = new Vector3(1, 1, 1);
            rg3d.velocity = new Vector3(0, 0, 0);
            Player.transform.position = new Vector3(-11, 0, 0);

            this.gameObject.SetActive(false);
        }
        else if((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space)) && PlayerShoot.model == 5)
        {
            GameManage.GameModel = 2;
            PlayerShoot.model = 7;
            string NextStage = "Stage" + nowStageNum;
            SceneManager.LoadSceneAsync(NextStage);
            HealthManage.PlayerHealth = 1;
        }
	}
}
