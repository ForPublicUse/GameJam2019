using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderRun : MonoBehaviour
{
    /**获取力量和角度条Slider组件**/
    //public Slider angleSlider;
    public Slider powerSlider;
    //public Text angleText;
    public Text powerText;

    public float powerSpeed = 30f;
    //public float angleSpeed = 60f;

    private int powerStyle = 1; //记录滑动条滑动方式（0 or 1）
    //private int angleStyle = 1; //记录滑动条滑动方式（0 or 1）

    public int powerMax = 100;
    public int powerMin = 0;
    //public int angleMax = 90;
    //public int angleMin = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //angleText.text = angleSlider.value.ToString();
        powerText.text = powerSlider.value.ToString();

        if(powerSlider.value >= powerMax)
        {
            powerStyle = 1;
        }
        //if(angleSlider.value >= angleMax)
        //{
        //    angleStyle = 1;
        //}
        if (powerSlider.value <= powerMin)
        {
            powerStyle = 0;
        }
        //if (angleSlider.value <= angleMin)
        //{
        //    angleStyle = 0;
        //}

        if(powerStyle == 1)
        {
            powerSlider.value -= powerSpeed * Time.deltaTime;
        }
        else if(powerStyle == 0)
        {
            powerSlider.value += powerSpeed * Time.deltaTime;
        }

        //if (angleStyle == 1)
        //{
        //    angleSlider.value -= angleSpeed * Time.deltaTime;
        //}
        //else if (angleStyle == 0)
        //{
        //    angleSlider.value += angleSpeed * Time.deltaTime;
        //}

    }
}
