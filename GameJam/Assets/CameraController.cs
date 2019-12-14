using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float VertiMaxAngle;
    public float HoriMaxAngle;

    private Transform cameraTransform;
    private Vector3 cameraAngle;
    private Transform OriTransform;
    // Start is called before the first frame update
    void Start()
    {
        //隐藏鼠标
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        OriTransform = Camera.main.transform;

        cameraTransform = Camera.main.transform;
        cameraAngle = cameraTransform.eulerAngles;
    }

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
