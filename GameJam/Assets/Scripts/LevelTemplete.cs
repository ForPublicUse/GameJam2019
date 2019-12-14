using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTemplete : IQuestion
{
    public List<Button> buttons = new List<Button>();
    public float moveTime = 0.5f;
    protected bool hasWin = false;

    protected bool CheckWin()
    {
        var str = "";
        buttons.ForEach(b => str += b.name);
        return str == Result();
    }

    protected virtual String Result()
    {
        return "";
    }

    public override void Win()
    {
        foreach (var button in buttons)
        {
            var text = button.GetComponentInChildren<Text>();
            text.color = new Color(85 / 255f, 166 / 255f, 61 / 255f, 1);
        }
        base.Win();
    }
    public virtual void OnButtonClick(Button button)
    {
        if (hasWin || isLocked)
        {
            return;
        }
        var index = buttons.IndexOf(button);
        if (index < buttons.Count - 1)
        {
            LockQuestion();
            var nextButton = buttons[index + 1];
            var nextPos = nextButton.transform.localPosition;
            var pos = button.transform.localPosition;
            Action nextAction = () => { nextButton.gameObject.transform.localPosition = pos; UnLockQuestion(); CheckMakeTrouble(); };
            Action action = () => { button.gameObject.transform.localPosition = nextPos; };

            var nextHash = iTween.Hash("position", pos, "islocal", true, "time", moveTime, "oncomplete", nextAction);
            iTween.MoveTo(nextButton.gameObject, nextHash);
            var hash = iTween.Hash("position", nextPos, "islocal", true, "time", moveTime, "oncomplete", action);
            iTween.MoveTo(button.gameObject, hash);
            buttons[index] = nextButton;
            buttons[index + 1] = button;
            if (CheckWin())
            {
                hasWin = true;
                Invoke("Win", 0.7F);
            }
        }
    }

    void CheckMakeTrouble()
    {
        if (toMakeTrouble)
        {
            MakeTrouble();
        }
        toMakeTrouble = false;
    }

    bool toMakeTrouble = false;
    public override void MakeTrouble()
    {
        if (isLocked)
        {
            toMakeTrouble = true;
        }
        else
        {
            OnButtonClick(buttons[UnityEngine.Random.Range(0, buttons.Count)]);
        }
    }
}

