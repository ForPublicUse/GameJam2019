using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level0 : LevelTemplete
{
    private string result = "12345";
    // Start is called before the first frame update
    protected override String Result()
    {
        return result;
    }
}
