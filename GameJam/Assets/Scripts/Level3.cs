using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : IQuestion
{
    public LaptopGame LaptopGame;
    public Dictionary<Vector2,MapUnit> mapUnits = new Dictionary<Vector2, MapUnit>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(var child in GetComponentsInChildren<MapUnit>())
        {
            mapUnits.Add(child.pos, child);
            child.level3 = this;
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
   
}
