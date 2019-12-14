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

    // Start is called before the first frame update
    void Start()
    {
        //隐藏鼠标
        Cursor.visible = false;
        Cursor.lockState =  CursorLockMode.Confined;
        cameraTransform = Camera.main.transform;
        cameraAngle = cameraTransform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        cameraMove();
    }

    public void cameraMove()
    {
        float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");
        if((cameraAngle.x - x) > xAngleMin && (cameraAngle.x - x) < xAngleMax)
        {
            cameraAngle.x -= x;
        }
        if((cameraAngle.y + y) > yAngleMin && (cameraAngle.y + y) < yAngleMax)
        {
            cameraAngle.y += y;
        }
        cameraTransform.eulerAngles = cameraAngle;
    }

}
