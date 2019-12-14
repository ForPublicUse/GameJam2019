using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class MapGenerator 
{
    [MenuItem("Tools/MapGenerate #L")]
    static void MapGenerate()
    {
        int row = 5;
        int column = 5;

        string namePattern = "map";
        Transform startPrefab = Selection.activeGameObject.transform;
        Transform parent = startPrefab.parent;
        var rect = startPrefab.GetComponent<RectTransform>();
        float rowBound = rect.sizeDelta.x;
        float columnBound = rect.sizeDelta.y;

        int j = 0;
        for (int i = 0; i < column; i++)
        {
            j = 0;
            for (; j < row; j++)
            {
                Vector3 pos = startPrefab.position;
                Transform t = GameObject.Instantiate(startPrefab.gameObject, pos, startPrefab.rotation).transform;
                t.name = namePattern + "[" + i + "]" + "[" + j + "]";
                t.SetParent(parent);
                int index1 = column / 2 - i;
                int index2 = row / 2 - j;
                t.localPosition = startPrefab.localPosition + new Vector3(index1 * columnBound, index2 * rowBound);
                t.localScale = Vector3.one;
                var mapUnit = t.gameObject.GetComponent<MapUnit>();
                mapUnit.pos = new Vector2(i, j);
            }
        }

    }
}
