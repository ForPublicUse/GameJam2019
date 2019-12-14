using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class IQuestion:MonoBehaviour
{
    public virtual void Win()
    {
        isClear = true;
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
}