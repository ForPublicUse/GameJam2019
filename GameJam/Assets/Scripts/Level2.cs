using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2 : LevelTemplete
{
    private string result = "110010100";
    // Start is called before the first frame update
    
    public Text text;
    // Start is called before the first frame update

    private void Start()
    {
        text.text = concateStr();
    }
    string concateStr()
    {
        var s = $@"int NotFound = 404;
<color=#D9D9D9>//点击数字与后一个数字交换，使之等于404
int NotFoundBinary = 0b                                   ;
// NotFoundBinary = {currentValue()}</color>
if( NotFound != NotFoundBinary)
";
        s += "      print(\"I found a girlfriend\");\nelse\n      print(\"We broke up\");";
        return s;
    }

    string currentValue()
    {
        int sum = 0;
        int mutiple = 1;
        for (int i = buttons.Count - 1; i >= 0; i--)
        {
            if (buttons[i].name == "1")
            {
                sum += mutiple;
            }
            mutiple *= 2;
        }
        return $"{sum} ";
    }

    public override void OnButtonClick(Button button)
    {
        base.OnButtonClick(button);
        text.text = concateStr();
    }

    protected override String Result()
    {
        return result;
    }
}
