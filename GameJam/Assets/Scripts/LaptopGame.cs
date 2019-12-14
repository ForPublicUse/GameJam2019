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
    public List<IQuestion> questions2;
    public Text text;
    private int questionNum;
    public float totalTime = 300;
    public Slider TimeSlider;
    public float LeftTime;
    public List<Button> tabs;
    public List<Button> tabs2;
    public GameObject add30;
    private IQuestion CurrentLevel;
    public bool CheckAlive()
    {
        return LeftTime > 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        LeftPosition = new Vector3(-Screen.width, 0, 0);
        transform.localPosition = LeftPosition;
        LeftTime = totalTime;
        List<IQuestion> _question = GetCurrntQuestion();
        CurrentLevel = _question[0];
        CurrentLevel.obj().SetActive(true);
        for (int i = 0; i < tabs.Count; i++)
        {
            var index = i;
            tabs[index].onClick.AddListener(() =>
            {
                foreach (var question in _question)
                {
                    question.obj().SetActive(false);
                }
                _question[index].obj().SetActive(true);
                CurrentLevel = _question[index];
            });
        }
        Success();
    }

    private List<IQuestion> GetCurrntQuestion()
    {
        return gameManager.Round == 0 ? questions : questions2;
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
        List<IQuestion> _question = GetCurrntQuestion();
        foreach (var question in _question)
        {
            if (!question.IsClear())
            {
                questionNum++;
            }
        }
        text.text = $@"{questionNum} Errors";
        if(questionNum == 0)
        {
            AllSuccess();
        }
    }

    public void AllSuccess()
    {
        gameManager.SuccessLogic();
    }

    private Vector3 RightPosition = Vector3.zero;
    public Vector3 LeftPosition = new Vector3(-1920,0,0);
    private bool inLeft = true;
    public float moveTime = 2f;
    public void RightClick()
    {
        //Action action = () => { transform.localPosition = inLeft ? RightPosition : LeftPosition; };
        var hash = iTween.Hash("position", inLeft ?  RightPosition: LeftPosition, "islocal", true, "time", moveTime);
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
        if (!inLeft)
        {
            iTween.ShakePosition(gameObject, ShakeVec, 0.5f);
        }
    }
    public Vector3 ShakeVec = new Vector3(5, 5, 5);


    public void OnQuestionSolved()
    {
        add30.SetActive(true);
        LeftTime += 30;
        Invoke("HideAddLabel", 2f);
    }

    void HideAddLabel()
    {
        add30.SetActive(false);
        Success();
    }
}
