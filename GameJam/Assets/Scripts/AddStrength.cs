using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStrength : MonoBehaviour
{
    public GameObject Shpere;
    public GameObject Camera;
    public bool bClick;
    public float fStrength;
    public float fRoopTime;

    private Vector3 CurrRotation = new Vector3(0,0,0);
    private bool bForward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bClick)
        {
            bClick = false;
            //test
            CurrRotation = Camera.transform.forward;
            PushSphere(CurrRotation, fStrength);

        }
        
    }

    void PushSphere(Vector3 vector3, float strength)
    {
        Shpere.GetComponent<Rigidbody>().AddForce(vector3.normalized * strength);
    }

    void ClickButton() { }
}
