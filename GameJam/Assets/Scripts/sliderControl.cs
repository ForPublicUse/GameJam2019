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

    private Color bgColor;
    private Color filledColor;
    private Color powerTextColor;

    private float bgAlpha;
    private float filledAlpha;
    private float powerTextAlpha;

    public float colorSpeed;
    public float sleepSecond;

    public int style;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        style = 0;
        count = 0;
        bgAlpha = 1;
        filledAlpha = 1;
        powerTextAlpha = 1;
        bgColor = bgGround.GetComponent<Image>().color;
        filledColor = filled.GetComponent<Image>().color;
        powerTextColor = powerText.GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && style == 1 )
        {
            SendMessage("pauseSlider");
            count = 1;
        }
        if (count == 1)
        {
            Invoke("calmDown",sleepSecond);
        }
        if (Input.GetMouseButtonDown(0) && style == 0 )
        {
            controlCanvas.gameObject.SetActive(true);
            style = 1;
        }
    }
    public void calmDown()
    {
        if (bgAlpha > 0)
        {
            bgAlpha -= Time.deltaTime * colorSpeed;
            bgColor.a = bgAlpha;
            bgGround.GetComponent<Image>().color = bgColor;

            filledAlpha -= Time.deltaTime * colorSpeed;
            filledColor.a = filledAlpha;
            filled.GetComponent<Image>().color = filledColor;

            powerTextAlpha -= Time.deltaTime * colorSpeed;
            powerTextColor.a = powerTextAlpha;
            powerText.GetComponent<Text>().color = powerTextColor;
        }
    }
}
