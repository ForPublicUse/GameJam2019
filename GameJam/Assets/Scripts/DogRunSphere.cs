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

    public DogAudioScript DogWalkAudioScript;
    public DogAudioScript DogHaAudioScript;
    /*
    public int MaxAudioDistance;
    public int MinAudioDistance;
    public float MaxAudioPercent;
    public float MinAudioPercent;
    */
    public Animator Animator;
    public DogAudioScript DogBarkAudioScript;


    public float fTroubleTIME;

    public float fMaxTimeOut = 30;
    private float fCurrTimeOut = 0;

    public bool bPushSphere;
    public float fInvokeTime;
    public float fDogMoveSpeed;
    //Dog and Player
    public float fMinDistance;

    public float fMaxHeight;

    private float fWaitTime;

    private float fTroubleTime;
    private bool bBeginTrouble;


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
        bBeginTrouble = false;
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
            BeginReturn();
            //return;
        }
        if (bPushSphere)
        {
            bPushSphere = false;
            bActiveDog = true;
            fCurrTimeOut = 0;
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

            if(fCurrTimeOut < fMaxTimeOut)
            {
                fCurrTimeOut += Time.deltaTime;

            }
            else
            {
                fCurrTimeOut = 0;
                GetBall();
            }
        }
        else
        {
            GetDogTransform().position = LastVec;
            CallPlayer();
            fTroubleTime += Time.deltaTime;

            if(fTroubleTime >= fTroubleTIME)
            {
                bBeginTrouble = true;
            }
            if(bBeginTrouble)
            {
                fTroubleTime = 0;
                bBeginTrouble = false;
                LaptopGame?.MakeTrouble();
            }
        }
    }

    void RunSphere()
    {
        //GetDogTransform().LookAt(DogSphere.transform.position);
        //Vector3 LookAtVec = Dog.transform.LookAt(DogSphere.transform.position);
        //if (Vector3.Distance(GetDogTransform().position, DogSphere.transform.position) <= fMinDistance)
        //{
        //    //GetBall();
        //}
        //else
        {

            Ray ray = new Ray(DogSphere.transform.position, Vector3.down);
            RaycastHit hit;
            bool isHit = Physics.Raycast((Ray)ray, out hit);
            if (isHit)
            {
                //Vector3 vec = hit.transform.position + new Vector3(0, 0, 90);
                if (hit.distance > fMaxHeight)
                {
                    Dog.transform.LookAt(new Vector3(DogSphere.transform.position.x, (Dog.transform.position.y + fMaxHeight), DogSphere.transform.position.z));
                }
                else
                {
                    //Dog.transform.LookAt(DogSphere.transform.position);
                    Dog.transform.LookAt(new Vector3(DogSphere.transform.position.x, DogSphere.transform.position.y, DogSphere.transform.position.z));
                    Dog.transform.localEulerAngles = new Vector3(Dog.transform.localEulerAngles.x, Dog.transform.localEulerAngles.y,0);
                }
            }
            Vector3 Vec = GetDogTransform().forward.normalized * Time.deltaTime * fDogMoveSpeed;
            GetDogTransform().Translate(Vec, Space.World);
            DogWalkAudio();
        }
    }

    private void GetBall()
    {
        MouseSphere.SetActive(true);
        DogSphere.SetActive(false);
        Invoke("BeginReturn", fInvokeTime);
        bBreakTick = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject == DogSphere)
        {
            GetBall();
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
            sliderControl.ResetUI();
        }
        else
        {
            GetDogTransform().LookAt(Player.transform.position);
            GetDogTransform().Translate(GetDogTransform().forward * Time.deltaTime * fDogMoveSpeed, Space.World);
            DogWalkAudio();
        }
        
    }

    void CallPlayer()
    {
        GetDogTransform().LookAt(Player.transform.position);
        DogSphere.SetActive(false);
        //do animation
        Animator.SetBool("Bark_b", true);
        DogBarkAudio();

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

    public LaptopGame LaptopGame
    {
        get
        {
            if (laptopGame== null )
            {
                laptopGame = FindObjectOfType<LaptopGame>();
            }
            return laptopGame;
        }
    }
    private LaptopGame laptopGame;
    public void SetLaptopGame(LaptopGame laptopGame)
    {
        this.laptopGame = laptopGame;
    }

    public void DogWalkAudio()
    {
        //DogWalkAudioScript.AudioMaker.volume = //CheckAudioPercent();
        if (!DogWalkAudioScript.DogAudioIsPlaying())
        {
            DogWalkAudioScript.PlayWalkAudio();
        }
        
        if(!DogHaAudioScript.DogAudioIsPlaying())
        {
            DogHaAudioScript.PlayHaAudio();
        }
        
    }

    public void DogBarkAudio()
    {
        //DogWalkAudioScript.AudioMaker.volume = //CheckAudioPercent();
        if (DogBarkAudioScript.DogAudioIsPlaying())
        {
            DogWalkAudioScript.PauseAudio();
            DogHaAudioScript.PauseAudio();
            return;
        }
        DogBarkAudioScript.PlayBarkAudio();
        
    }
    /*
    float CheckAudioPercent()
    {
        float AudioPercent;
        float Dist = Vector3.Distance(GetDogTransform().position, Player.transform.position);

        if (Dist > MaxAudioDistance)
        {
            AudioPercent = MinAudioPercent;
        }
        else if (Dist < MinAudioDistance)
        {
            AudioPercent = MaxAudioPercent;
        }
        else
        {
            AudioPercent = MaxAudioPercent - (MaxAudioPercent - MinAudioPercent) * MaxAudioDistance / Dist;
        }

        return AudioPercent;
    }
    */
}
