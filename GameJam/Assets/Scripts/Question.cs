using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class IQuestion:MonoBehaviour
{
    public LaptopGame LaptopGame;
    public TabButton tabButton;
    public virtual void Win()
    {
        isClear = true;
        LaptopGame.OnQuestionSolved();
        tabButton.IsCorrect = true;
        tabButton.UpdateUI(true);
    }

    protected bool isClear = false;

    public bool IsClear()
    {
        return isClear;
    }
    public GameObject obj()
    {
        return gameObject;
    }

    protected bool isLocked = false;
    protected void LockQuestion()
    {
        isLocked = true;
    }

    protected void UnLockQuestion()
    {
        isLocked = false;
    }

    public virtual void MakeTrouble()
    {

    }
}