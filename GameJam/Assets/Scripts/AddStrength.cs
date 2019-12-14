using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStrength : MonoBehaviour
{
    public GameObject Shpere;
    public GameObject Camera;
    public bool bClick;
    public float fMinStrength;
    public float fMaxStrength;
    //if fSmallRate == 1, look scale always the same.
    public float fSmallRate;
    //0-100
    public float fStrengthPercentage;

    private Vector3 CurrRotation = new Vector3(0,0,0);
    private bool bForward;
    private float fOriginalDistance;
    // Start is called before the first frame update
    void Start()
    {
        fOriginalDistance = Vector3.Distance(Shpere.transform.position, Camera.transform.position);
        Shpere.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(bClick)
        {
            bClick = false;
            //test
            CurrRotation = Camera.transform.forward;
            Shpere.GetComponent<Rigidbody>().useGravity = true;
            PushSphere(CurrRotation, (fMaxStrength - fMinStrength) * fStrengthPercentage + fMinStrength);

            //SetScale();
        }
        
    }

    void PushSphere(Vector3 vector3, float strength)
    {
        Shpere.GetComponent<Rigidbody>().AddForce(vector3.normalized * strength);
    }

    void SetScale()
    {
        float distance = Vector3.Distance(Shpere.transform.position, Camera.transform.position);

        Shpere.transform.localScale = new Vector3(
            1 + (distance - fOriginalDistance) * fSmallRate, 
            1 + (distance - fOriginalDistance) * fSmallRate, 
            1 + (distance - fOriginalDistance) * fSmallRate);
    }

    void ClickButton() { }
}
