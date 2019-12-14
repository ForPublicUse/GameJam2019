using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : IQuestion
{
    public Dictionary<Vector2,MapUnit> mapUnits = new Dictionary<Vector2, MapUnit>();
    private int xMax = 0;
    private int yMax = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var child in GetComponentsInChildren<MapUnit>())
        {
            mapUnits.Add(child.pos, child);
            child.level3 = this;
            if (child.pos.x > xMax)
            {
                xMax = (int)child.pos.x;
            }
            if (child.pos.y > yMax)
            {
                yMax = (int)child.pos.y;
            }
        }
    }

    public void OnChildClick(Vector2 vector)
    {
        mapUnits[vector].Turn();
        var upVector = new Vector2(vector.x, vector.y - 1);
        var downVector = new Vector2(vector.x, vector.y + 1);
        var rightVector = new Vector2(vector.x+1, vector.y);
        var leftVector = new Vector2(vector.x-1, vector.y);

        var list = new List<Vector2> { upVector, downVector, rightVector, leftVector };
        foreach(var vec in list)
        {
            if (mapUnits.ContainsKey(vec))
            {
                mapUnits[vec].Turn();
            }
        }
        if (CheckWin())
        {
            Win();
        }
    }

    bool CheckWin()
    {
        foreach (var unit in mapUnits.Values)
        {
            if(unit.isRight == false)
            {
                return false;
            }
        }
        return true;
    }


    public void CheckMakeTrouble()
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
            OnChildClick(new Vector2(Random.Range(0, xMax), Random.Range(0, yMax)));
        }
    }
}
