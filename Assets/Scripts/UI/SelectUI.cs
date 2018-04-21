using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour {

    public GameObject stageView1;
    public GameObject stageView2;
    public GameObject stageView3;
    public GameObject stageView4;
    public Image View1pic;
    public Image View2pic;
    public Image View3pic;
    public Image View4pic;

    private Animator animator1;
    private Animator animator2;
    private Animator animator3;


    private float timeCount;
    private bool timeLock;
    private int nowStageNum;
    private int nextLoadStageNum;
    private int nowViewNum;
    private int numberOfStages;
    private string[] stagenames;

    void Start ()
    {
        animator1 = stageView1.GetComponent<Animator>();
        animator2 = stageView2.GetComponent<Animator>();
        animator3 = stageView3.GetComponent<Animator>();

        timeCount = 0;
        timeLock = true;
        nowStageNum = 1;
        nowViewNum = 1;
        numberOfStages = 5;

        stagenames = new string[numberOfStages + 1];
        for(int i=1; i <= numberOfStages; i++)
        {
            stagenames[i] = "Stage" + i + "Pic";
        }
	}
	

	void Update ()
    {
        timeCount = timeCount + Time.deltaTime;
        if(timeCount > 0.2f)
        {
            timeLock = true;
            timeCount = 0;
        }

        if(timeLock)
        {
            timeLock = false;
            timeCount = 0;
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
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
                    CenterToLeft(stageView1);
                    LeftToOut(stageView4);
                    OutToRight(stageView3);
                    RightToCenter(stageView2);
                    View3pic.sprite = newsprite;
                }
                else if(nowViewNum == 2)
                {
                    CenterToLeft(stageView2);
                    LeftToOut(stageView1);
                    OutToRight(stageView4);
                    RightToCenter(stageView3);
                    View4pic.sprite = newsprite;
                }
                else if (nowViewNum == 3)
                {
                    CenterToLeft(stageView3);
                    LeftToOut(stageView2);
                    OutToRight(stageView1);
                    RightToCenter(stageView4);
                    View1pic.sprite = newsprite;
                }
                else if (nowViewNum == 4)
                {
                    CenterToLeft(stageView4);
                    LeftToOut(stageView3);
                    OutToRight(stageView2);
                    RightToCenter(stageView1);
                    View2pic.sprite = newsprite;
                }

                nowViewNum++;
                if (nowViewNum > 4)
                {
                    nowViewNum = 1;
                }
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
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
                    CenterToRight(stageView1);
                    RightToOut(stageView2);
                    OutToLeft(stageView3);
                    LeftToCenter(stageView4);
                    View3pic.sprite = newsprite;
                }
                else if (nowViewNum == 2)
                {
                    CenterToRight(stageView2);
                    RightToOut(stageView3);
                    OutToLeft(stageView4);
                    LeftToCenter(stageView1);
                    View4pic.sprite = newsprite;
                }
                else if (nowViewNum == 3)
                {
                    CenterToRight(stageView3);
                    RightToOut(stageView4);
                    OutToLeft(stageView1);
                    LeftToCenter(stageView2);
                    View1pic.sprite = newsprite;
                }
                else if (nowViewNum == 4)
                {
                    CenterToRight(stageView4);
                    RightToOut(stageView1);
                    OutToLeft(stageView2);
                    LeftToCenter(stageView3);
                    View2pic.sprite = newsprite;
                }

                nowViewNum--;
                if (nowViewNum == 0)
                {
                    nowViewNum = 4;
                }
            }
        }

	}

    private void CenterToRight(GameObject view)
    {

    }

    private void CenterToLeft(GameObject view)
    {

    }

    private void RightToCenter(GameObject view)
    {

    }

    private void LeftToCenter(GameObject view)
    {

    }

    private void RightToOut(GameObject view)
    {

    }

    private void LeftToOut(GameObject view)
    {

    }

    private void OutToRight(GameObject view)
    {

    }

    private void OutToLeft(GameObject view)
    {

    }
}
