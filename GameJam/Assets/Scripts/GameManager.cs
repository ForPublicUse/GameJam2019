using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject RestartMenu;
    public GameObject SuccessEnd;
    public GameObject FailEnd;
    public GameObject ComicLevel;//过场漫画
    public float totalTime=300;
    public Slider TimeSlider;

    public float LeftTime;

    private void Start()
    {
        LeftTime = totalTime;
    }
    public bool CheckAlive()
    {
        return LeftTime > 0;
    }

    private void Update()
    {
        LeftTime -= Time.deltaTime;
        if (CheckAlive() == false)
        {
            FailLogic();
        }
        TimeSlider.value = LeftTime / totalTime;
    }

    void FailLogic()
    {

    }

    public void SuccessLogic()
    {
    }
}
