using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicLevel : MonoBehaviour
{
    public GameObject Comic1;
    public GameObject Comic2;
    public GameObject Comic3;
    public GameObject startBtn;
    public GameObject nexgtBtn;
    public GameObject text1;
    public GameObject text2;
    public GameObject qianyan;

    // Start is called before the first frame update
    int nextCount = 0;

    public void UpdateQianyan()
    {
        text1.SetActive(GameManager.Instance.Round == 0);
        text2.SetActive(GameManager.Instance.Round == 1);

    }
    public void Next()
    {
        if(nextCount == 0)
        {
            ShowComic1();
        }
        else
        {
            HideComic1();
        }
        nextCount++;
    }

    void ShowComic1()
    {
        qianyan.SetActive(false);
        Comic1.SetActive(true);
    }

    public void HideComic1()
    {
        nexgtBtn.SetActive(false);
        Comic1.SetActive(false);
        Comic2.SetActive(true);
        nextCount = 0;
        Invoke("Shake", 0.25F);
    }

    void Shake()
    {
        Comic1.SetActive(false);
        iTween.ShakePosition(Comic2, new Vector3(3,3,3), 0.5f);

        Invoke("Shake2", 1F);

    }

    void Shake2()
    {
        iTween.ShakePosition(Comic2, new Vector3(5, 5, 5), 0.5f);

        Invoke("Move", 0.75F);
    }

    void Move()
    {
        var hash = iTween.Hash("position", Comic2.transform.localPosition+new Vector3(-600,0), "islocal", true, "time", 0.5f);
        iTween.MoveTo(Comic2, hash);

        Invoke("ShowComic3", 0.5F);
    }

    void ShowComic3()
    {
        Comic3.SetActive(true);
        Comic3.transform.position = Comic2.transform.position;
        var hash = iTween.Hash("position", Comic2.transform.localPosition + new Vector3(800, 0), "islocal", true, "time", 0.5f);
        iTween.MoveTo(Comic3, hash);
        Comic3.transform.localScale = Vector3.zero;
        iTween.ScaleTo(Comic3, Vector3.one, 0.5f);
        Invoke("ShowStartBtn", 0.5F);
    }

    void ShowStartBtn()
    {
        startBtn.SetActive(true);
    }


    public void StartGame()
    {
        GameManager.Instance.StartGamePlay();
    }
}
