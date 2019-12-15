using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    public Button button;
    public Button FullScreen;
    // Start is called before the first frame update
    public void ResetUI()
    {
        button.gameObject.SetActive(false);
        FullScreen.gameObject.SetActive(true);
    }
    public void ShowNextWeekend()
    {
        button.gameObject.SetActive(GameManager.Instance.Round == 0);
        FullScreen.gameObject.SetActive(false);
    }
}
