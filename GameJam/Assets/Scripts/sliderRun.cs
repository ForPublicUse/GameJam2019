using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderRun : MonoBehaviour
{
    /**获取力量和角度条Slider组件**/

    public Slider powerSlider;

    public Text powerText;

    public float powerSpeed = 30f;

    private int powerStyle = 1; //记录滑动条滑动方式（0 or 1）


    public int powerMax = 100;
    public int powerMin = 0;



    // Update is called once per frame
    void Update()
    {
        powerText.text = powerSlider.value.ToString();

        if(powerSlider.value >= powerMax)
        {
            powerStyle = 1;
        }

        if (powerSlider.value <= powerMin)
        {
            powerStyle = 0;
        }

        if(powerStyle == 1)
        {
            powerSlider.value -= powerSpeed * Time.deltaTime;
        }
        else if(powerStyle == 0)
        {
            powerSlider.value += powerSpeed * Time.deltaTime;
        }

    }
    public void pauseSlider()
    {
        this.GetComponent<sliderRun>().enabled = false;
    }
}
