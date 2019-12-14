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
    public GameObject gamePlayPrefab;
    public GameObject gamePlay;

    public cameraLookAround cameraLookAround;
    public sliderControl sliderControl;

    public void FailLogic()
    {
        if (laptop != null)
        {
            Destroy(laptop);
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
        }
        SuccessEnd.SetActive(true);
        sliderControl.StopRunning();
        cameraLookAround.StopRunning();
        gamePlayRunning = false;
    }

    public void StartGame()
    {
        SuccessEnd.SetActive(false);
        FailEnd.SetActive(false);
       
        laptop = Instantiate(laptopPrefab) as GameObject;
        laptop.transform.SetParent(transform);
        laptopGame = laptop.GetComponent<LaptopGame>();
        laptop.transform.localPosition = laptopGame.RightPosition;
        laptopGame.gameManager = this;
        laptop.SetActive(true);

        //gamePlay = Instantiate(gamePlayPrefab) as GameObject;

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
    }
}
