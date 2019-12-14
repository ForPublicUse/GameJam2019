using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Hashtable args = new Hashtable();

        //放大的倍数
        args.Add("scale", new Vector3(1.1f, 1.1f, 1.1f));


        //动画的时间
        args.Add("time", 0.6f);
        ////延迟执行时间
        //args.Add("delay", 1f);

        //这里是设置类型，iTween的类型又很多种，在源码中的枚举EaseType中
        args.Add("easeType", iTween.EaseType.linear);
        //三个循环类型 none loop pingPong (一般 循环 来回)	
        //args.Add("loopType", "none");
        //args.Add("loopType", "loop");	
        args.Add("loopType", iTween.LoopType.pingPong);

        iTween.ScaleTo(gameObject, args);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
