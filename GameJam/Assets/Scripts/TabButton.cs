using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    public Image Correct;
    public Image Error;
    public Image CorrectDark;
    public Image ErrorDark;

    public bool IsCorrect = false;
    public void UpdateUI(bool clicked)
    {
        Correct.gameObject.SetActive(clicked && IsCorrect);
        Error.gameObject.SetActive(clicked && !IsCorrect);
        CorrectDark.gameObject.SetActive(!clicked && IsCorrect);
        ErrorDark.gameObject.SetActive(!clicked && !IsCorrect);
    }
}
