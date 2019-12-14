using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLookAround : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 cameraAngle;
    //private float cameraHeight = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        //隐藏鼠标
        Cursor.visible = false;
        Cursor.lockState =  CursorLockMode.Confined;

        cameraTransform = Camera.main.transform;
        cameraTransform.position = transform.position;
        cameraTransform.rotation = transform.rotation;
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
        Debug.Log(y);
        float x = Input.GetAxis("Mouse Y");
        Debug.Log(x);
        cameraAngle.x -= x;
        cameraAngle.y += y;
        cameraTransform.eulerAngles = cameraAngle;
    }

}
