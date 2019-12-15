using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    public Button Again;
    public Button FullScreen;
    public void ShowAgain()
    {
        Again.gameObject.SetActive(true);
        FullScreen.gameObject.SetActive(false);
    }

    public void ResetUI()
    {
        Again.gameObject.SetActive(false);
        FullScreen.gameObject.SetActive(true);
    }
}
