using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaptopGame : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Menu;
    public List<Question> questions;
    public Text text;
    private int questionNum;

    // Start is called before the first frame update
    void Start()
    {
        RightClick();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            RightClick();
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
    private Vector3 RightPosition = new Vector3(-1920,0,0);
    private bool inLeft = true;
    public float moveTime = 2f;
    public void RightClick()
    {
        var hash = iTween.Hash("position", inLeft?RightPosition:LeftPosition, "islocal",true, "time", moveTime);
        iTween.MoveTo(gameObject, hash);
        inLeft = !inLeft;
    }
}
