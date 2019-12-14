using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject SuccessEnd;
    public GameObject FailEnd;
    public GameObject ComicLevel;//过场漫画
    public GameObject laptopPrefab;
    public GameObject laptop;
    public LaptopGame laptopGame;
    public GameObject timeSlider;
    public WinPanel winPanel;

    public cameraLookAround cameraLookAround;
    public sliderControl sliderControl;

    public int Round = 0;
    private void Start()
    {
        sliderControl = FindObjectOfType<sliderControl>();
        cameraLookAround = FindObjectOfType<cameraLookAround>();
    }

    public void FailLogic()
    {
        if (laptop != null)
        {
            Destroy(laptop);
            Destroy(timeSlider);

        }
        FailEnd.SetActive(true);
        sliderControl.StopRunning();
        cameraLookAround.StopRunning();
        gamePlayRunning = false;
    }

    public void SuccessLogic()
    {
        if (laptop != null)
        {
            Destroy(laptop);
            Destroy(timeSlider);
        }
        SuccessEnd.SetActive(true);
        sliderControl.StopRunning();
        cameraLookAround.StopRunning();
        gamePlayRunning = false;
        winPanel.ShowNextWeekend(Round == 0);
    }

    public void StartGame()
    {
        SuccessEnd.SetActive(false);
        FailEnd.SetActive(false);
       
        laptop = Instantiate(laptopPrefab) as GameObject;
        laptop.transform.SetParent(transform);
        laptopGame = laptop.GetComponent<LaptopGame>();
        laptop.transform.localPosition = laptopGame.LeftPosition;
        laptopGame.gameManager = this;
        laptop.SetActive(true);
        timeSlider = laptopGame.TimeSlider.gameObject;
        timeSlider.transform.SetParent(transform);
        timeSlider.transform.localPosition = new Vector3(0, -Screen.height / 2 + 105, 0);

        StartMenu.SetActive(false);

        sliderControl.StartRunning();
        cameraLookAround.StartRunning();
        gamePlayRunning = true;
    }

    bool gamePlayRunning = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            laptopGame.RightClick();
            if (gamePlayRunning)
            {
                sliderControl.StopRunning();
                cameraLookAround.StopRunning();
                gamePlayRunning = false;
            }
            else
            {
                sliderControl.StartRunning();
                cameraLookAround.StartRunning();
                gamePlayRunning = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FailLogic();
        }
    }

    public void NextWeekend()
    {
        if(Round == 0)
        {
            Round = 1;
            StartGame();
        }
    }

}
