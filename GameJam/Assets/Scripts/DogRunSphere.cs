using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRunSphere : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DogSphere;
    public GameObject MouseSphere;
    public GameObject Player;
    //public GameObject PlayerLocation;
    public GameObject Dog;

    public sliderControl sliderControl;

    public Animator Animator;

    public bool bPushSphere;
    public float fInvokeTime;
    public float fDogMoveSpeed;
    //Dog and Player
    public float fMinDistance;

    public float fMaxHeight;

    private float fWaitTime;
    private bool bActiveDog;
    private bool bDogReturn;

    private Vector3 LastVec; 
    private Vector3 LastPos;

    private bool bBreakTick;
    void Start()
    {
        bBreakTick = false;
        bActiveDog = false;
        bDogReturn = false;
        MouseSphere.SetActive(false);
        //Dog.GetComponent<Animator>().CrossFade("", 0.1, -1, 0);
        DogSphere.transform.position = Player.transform.position;
        LastVec = GetDogTransform().position;
        LastPos = DogSphere.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(bBreakTick)
        {
            return;
        }
        if (bPushSphere)
        {
            bPushSphere = false;
            bActiveDog = true;
            DogSphere.SetActive(true);
            fWaitTime = fInvokeTime;
            Animator.SetBool("Bark_b", false);
        }

        if(bActiveDog)
        {
            if (fWaitTime > 0)
            {
                GetDogTransform().LookAt(Player.transform.position);
                fWaitTime -= Time.deltaTime;
            }

            if (fWaitTime <= 0)
            {
                if (!bDogReturn)
                {
                    RunSphere();
                }
                else
                {
                    RunReturn();
                }
            }
        }
        else
        {
            GetDogTransform().position = LastVec;
            CallPlayer();
            
        }
    }

    void RunSphere()
    {
        //GetDogTransform().LookAt(DogSphere.transform.position);
        Vector3 Vec = GetDogTransform().forward * Time.deltaTime * fDogMoveSpeed;

        object ray = Camera.main.ScreenPointToRay(-GetDogTransform().up); //屏幕坐标转射线
        RaycastHit hit;
        bool isHit = Physics.Raycast((Ray) ray, out hit);
        if(isHit)
        {
            if(hit.distance > fMaxHeight)
            {
                Dog.transform.LookAt(new Vector3(DogSphere.transform.position.x, DogSphere.transform.position.y, (Dog.transform.position.z + fMaxHeight)));
            }
            else
            {
                Dog.transform.LookAt(DogSphere.transform.position);
            }
        }
        GetDogTransform().Translate( Vec, Space.World);

    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject == DogSphere)
        {
            MouseSphere.SetActive(true);
            DogSphere.SetActive(false);
            Invoke("BeginReturn", fInvokeTime);
            bBreakTick = true;
        }
        /*
        if (collider.gameObject == Player)
        {
            bDogReturn = false;
            bActiveDog = false;
            //MouseSphere.SetActive(false);
        }
        */
    }

    void RunReturn()
    {
        if(Vector3.Distance(GetDogTransform().position, Player.transform.position) <= fMinDistance)
        {
            //reset
            bDogReturn = false;
            bActiveDog = false;
            MouseSphere.SetActive(false);
            LastVec = GetDogTransform().position;
            DogSphere.GetComponent<Rigidbody>().useGravity = false;
            DogSphere.transform.position = LastPos;
            DogSphere.SetActive(true);
            sliderControl.style = 0;
        }
        else
        {
            GetDogTransform().LookAt(Player.transform.position);
            GetDogTransform().Translate(GetDogTransform().forward * Time.deltaTime * fDogMoveSpeed, Space.World);
        }
        
    }

    void CallPlayer()
    {
        GetDogTransform().LookAt(Player.transform.position);
        DogSphere.SetActive(false);
        //do animation
        Animator.SetBool("Bark_b", true);
    }

    Transform GetDogTransform()
    {
        return Dog.transform;
    }

    void BeginReturn()
    {
        bDogReturn = true;
        bBreakTick = false;
    }
}
