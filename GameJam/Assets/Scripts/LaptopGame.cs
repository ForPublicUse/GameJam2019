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
    public bool CheckAlive()
    {
        return LeftTime > 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        LeftTime = totalTime;
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
}
