using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopGame : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Menu;
    public List<IQuestion> questions;
    public Text text;
    private int questionNum;
    public float totalTime = 300;
    public Slider TimeSlider;
    public float LeftTime;
    public List<Button> tabs;
    private IQuestion CurrentLevel;
    public bool CheckAlive()
    {
        return LeftTime > 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        RightPosition = new Vector3(-Screen.width, 0, 0);
        transform.localPosition = RightPosition;
        LeftTime = totalTime;
        CurrentLevel = questions[0];
        for (int i = 0; i < tabs.Count; i++)
        {
            var index = i;
            tabs[index].onClick.AddListener(() =>
            {
                foreach (var question in questions)
                {
                    question.obj().SetActive(false);
                }
                questions[index].obj().SetActive(true);
                CurrentLevel = questions[index];
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        LeftTime -= Time.deltaTime;
        if (CheckAlive() == false)
        {
            gameManager.FailLogic();
        }
        TimeSlider.value = LeftTime / totalTime;


        if (Input.GetKeyDown(KeyCode.K))
        {
            MakeTrouble();
        }
    }

    public void Success()
    {
        questionNum = 0;
        foreach(var question in questions)
        {
            if (!question.IsClear())
            {
                questionNum++;
            }
        }
        text.text = $@"{questionNum} Errors";
    }

    public void Fail()
    {

    }

    public void AllSuccess()
    {
        gameManager.SuccessLogic();
    }

    private Vector3 LeftPosition = Vector3.zero;
    public Vector3 RightPosition = new Vector3(-1920,0,0);
    private bool inLeft = false;
    public float moveTime = 2f;
    public void RightClick()
    {
        //Action action = () => { transform.localPosition = inLeft ? RightPosition : LeftPosition; };
        var hash = iTween.Hash("position", inLeft ? RightPosition : LeftPosition, "islocal", true, "time", moveTime);
        iTween.MoveTo(gameObject, hash);
        inLeft = !inLeft;
    }

    public void MakeTrouble()
    {
        ShakeLaptop();
        CurrentLevel.MakeTrouble();
    }
    void ShakeLaptop()
    {
        iTween.ShakePosition(gameObject, ShakeVec, 0.5f);
    }
    public Vector3 ShakeVec = new Vector3(5, 5, 5);


    public void OnQuestionSolved()
    {

    }
}
