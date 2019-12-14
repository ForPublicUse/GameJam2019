using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLookAround : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 cameraAngle;

    public int xAngleMin;
    public int xAngleMax;
    public int yAngleMin;
    public int yAngleMax;

    public int cameraSpeed;

    private Transform PriTrans;
    // Start is called before the first frame update
    void Start()
    {
        
        cameraTransform = Camera.main.transform;
        cameraAngle = cameraTransform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            cameraMove();
        }
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

    public void cameraMove()
    {
        float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");
        if ((cameraAngle.x - x * cameraSpeed) > xAngleMin && (cameraAngle.x - x * cameraSpeed) < xAngleMax)
        {
            if (x != 0)
            {
                var tempX = Mathf.Min(Mathf.Abs(x), 1) * Mathf.Abs(x) / x * cameraSpeed;
                cameraAngle.x -= tempX;
            }
        }
        if ((cameraAngle.y + y * cameraSpeed) > yAngleMin && (cameraAngle.y + y * cameraSpeed) < yAngleMax)
        {
            if (y != 0)
            {
                var tempY = Mathf.Min(Mathf.Abs(y), 1) * Mathf.Abs(y) / y * cameraSpeed;
                cameraAngle.y += tempY;
            }
        }
        cameraTransform.eulerAngles = cameraAngle;
    }

    void ShowMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideMouse()
    {
        //隐藏鼠标
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void ResetMouse()
    {

    }
}

    



//if((cameraAngle.x - x * cameraSpeed) > xAngleMin && (cameraAngle.x - x * cameraSpeed) < xAngleMax)
//        {
//            //if (x != 0)
//            //{
//                //var tempX = Mathf.Min(Mathf.Abs(x),1) * Mathf.Abs(x) / x;
//                cameraAngle.x -= x * cameraSpeed;
//           // }
//        }
//        if((cameraAngle.y + y * cameraSpeed) > yAngleMin && (cameraAngle.y + y * cameraSpeed) < yAngleMax)
//        {
//            //if (y != 0)
//           // {
//             //   var tempY = Mathf.Min(Mathf.Abs(y), 1) * Mathf.Abs(y) / y;
//                cameraAngle.y += y * cameraSpeed;
//            //}
//        }



