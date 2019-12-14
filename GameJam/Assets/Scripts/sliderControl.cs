using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderControl : MonoBehaviour
{
    public Canvas controlCanvas;
    public GameObject powerText;
    public GameObject filled;
    public GameObject bgGround;

    public DogRunSphere DogRunSphere;
    public AddStrength AddStrength;

    public sliderRun sliderRun;

    private Color bgColor;
    private Color filledColor;
    private Color powerTextColor;

    private Color oriBgColor;
    private Color oriFilledColor;
    private Color oriPowerTextColor;

    private float bgAlpha;
    private float filledAlpha;
    private float powerTextAlpha;

    public float colorSpeed;
    public float sleepSecond;

    //0:hide slide 1:show slide 2:pause slide 3:fade slide 4:wait reset
    public int style;
    public int PushShpereCount;

    // Start is called before the first frame update
    void Start()
    {
        style = 0;
        PushShpereCount = 0;
        bgAlpha = 1;
        filledAlpha = 1;
        powerTextAlpha = 1;
        bgColor = bgGround.GetComponent<Image>().color;
        filledColor = filled.GetComponent<Image>().color;
        powerTextColor = powerText.GetComponent<Text>().color;

        oriBgColor = bgGround.GetComponent<Image>().color;
        oriFilledColor = filled.GetComponent<Image>().color;
        oriPowerTextColor = powerText.GetComponent<Text>().color;
    }
    bool isRunning = false;
    public void StartRunning()
    {
        isRunning = true;
    }

    public void StopRunning()
    {
        isRunning = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(style == 0)
            {
                controlCanvas.gameObject.SetActive(true);
                //sliderRun.slideRun = true;
                style = 1;
            }
            else if(style == 1)
            {
                DogRunSphere.bPushSphere = true;
                AddStrength.bClick = true;

                AddStrength.fStrengthPercentage = sliderRun.getPercent();

                SendMessage("pauseSlider", AddStrength.bClick);
                PushShpereCount++;
                style = 2;
                Invoke("fadeSlide", sleepSecond);
            }
            
        }

        if(style == 3)
        {
            if(bgAlpha > 0)
            {
                calmDown();
            }
            else
            {
                //sliderRun.slideRun = false;
                style = 4;

                PushShpereCount = 0;
                bgAlpha = 1;
                filledAlpha = 1;
                powerTextAlpha = 1;
                bgGround.GetComponent<Image>().color = oriBgColor;
                filled.GetComponent<Image>().color = oriFilledColor;
                powerText.GetComponent<Text>().color = oriPowerTextColor;
                sliderRun.GetComponent<sliderRun>().enabled = true;
                controlCanvas.gameObject.SetActive(false);
            }
        }

        
    }
    public void calmDown()
    {
        //if (bgAlpha > 0)
        //{
            bgAlpha -= Time.deltaTime * colorSpeed;
            bgColor.a = bgAlpha;
            bgGround.GetComponent<Image>().color = bgColor;

            filledAlpha -= Time.deltaTime * colorSpeed;
            filledColor.a = filledAlpha;
            filled.GetComponent<Image>().color = filledColor;

            powerTextAlpha -= Time.deltaTime * colorSpeed;
            powerTextColor.a = powerTextAlpha;
            powerText.GetComponent<Text>().color = powerTextColor;
        //}
    }

    void fadeSlide()
    {
        style = 3;
    }
}
