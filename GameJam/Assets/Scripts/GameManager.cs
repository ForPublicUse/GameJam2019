using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject StartMenu;
    public GameObject SuccessEnd;
    public GameObject FailEnd;
    public GameObject ComicLevelPrefab;//过场漫画
    private GameObject ComicLevel;//过场漫画
    public GameObject laptopPrefab;
    private GameObject laptop;
    private LaptopGame laptopGame;
    private GameObject timeSlider;
    public WinPanel winPanel;

    private cameraLookAround cameraLookAround;
    private sliderControl sliderControl;

    public int Round = 0;
    private void Start()
    {
        Instance = this;
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
    }
    public void StartGamePlay()
    {
        Destroy(ComicLevel);

        laptop = Instantiate(laptopPrefab) as GameObject;
        laptop.transform.SetParent(transform);
        laptopGame = laptop.GetComponent<LaptopGame>();
        laptop.transform.localPosition = laptopGame.LeftPosition;
        laptopGame.gameManager = this;
        laptop.SetActive(true);
        timeSlider = laptopGame.TimeSlider.gameObject;
        timeSlider.transform.SetParent(transform);
        timeSlider.transform.localPosition = new Vector3(0, -Screen.height / 2 + 105, 0);

        sliderControl.StartRunning();
        cameraLookAround.StartRunning();
        gamePlayRunning = true;
    }

    public void StartGame()
    {
        SuccessEnd.SetActive(false);
        FailEnd.SetActive(false);

        ComicLevel = Instantiate(ComicLevelPrefab) as GameObject;
        ComicLevel.transform.SetParent(transform);
        ComicLevel.transform.localPosition = Vector3.zero;
        var rect = ComicLevel.GetComponent<RectTransform>();
        rect.offsetMin = new Vector2(0, 0);
        rect.offsetMax = new Vector2(-0, -0);
        ComicLevel.GetComponent<ComicLevel>().UpdateQianyan();
        ComicLevel.SetActive(true);


        StartMenu.SetActive(false);
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
