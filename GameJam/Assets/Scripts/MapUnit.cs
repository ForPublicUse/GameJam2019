using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUnit : MonoBehaviour
{
    public Vector2 pos;
    public Text Right;
    public Text Error;
    public Level3 level3;
    public bool isRight;
    public Button button;
    private Vector3 rightEuler = new Vector3(0,180,0);
    private Vector3 leftEuler = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
        gameObject.transform.localEulerAngles = isRight ? rightEuler : leftEuler;
        button.onClick.AddListener(OnClick);
    }

    private bool islock = false;

    public void Turn()
    {
        islock = true;
        isRight = !isRight;
        iTween.RotateTo(gameObject, isRight ? rightEuler : leftEuler, 0.5f);
        Invoke("UpdateUI", 0.15f);
        Invoke("Unlock", 0.5f);
    }

    void UpdateUI()
    {
        Right.gameObject.SetActive(isRight);
        Error.gameObject.SetActive(!isRight);
    }

    void Unlock()
    {
        islock = false;
        level3.CheckMakeTrouble();
    }

    public void OnClick()
    {
        level3.OnChildClick(pos);
    }
}
