using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject SuccessEnd;
    public GameObject FailEnd;
    public GameObject ComicLevel;//过场漫画
    public GameObject laptopPrefab;
    public GameObject laptop;
    public LaptopGame laptopGame;

    public void FailLogic()
    {
        if (laptop != null)
        {
            Destroy(laptop);
        }
        FailEnd.SetActive(true);
    }

    public void SuccessLogic()
    {
        if (laptop != null)
        {
            Destroy(laptop);
        }
        SuccessEnd.SetActive(true);
    }

    public void StartGame()
    {
        SuccessEnd.SetActive(false);
        FailEnd.SetActive(false);
       
        laptop = Instantiate(laptopPrefab) as GameObject;
        laptop.transform.SetParent(transform);
        laptop.transform.localPosition = new Vector3(0, 0, 0);
        laptopGame = laptop.GetComponent<LaptopGame>();
        laptopGame.gameManager = this;
        laptop.SetActive(true);
    }
}
