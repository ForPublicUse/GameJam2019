using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{

    public Button button;
    // Start is called before the first frame update
    public void ShowNextWeekend(bool show)
    {
        button.gameObject.SetActive(show);
    }
}
