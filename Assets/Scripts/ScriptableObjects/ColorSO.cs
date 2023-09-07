using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSO", menuName = "Create ColorSO")]

public class ColorSO : ScriptableObject
{
    public LabelledColor[] LabelledColors;

    public Color getColor(string id)
    {
        foreach(LabelledColor labelledColor in LabelledColors)
        {
            if (labelledColor.id == id) return labelledColor.color;
        }
        Debug.LogError("COLOR NOT FOUND FOR ID : " + id);
        return Color.magenta;
    }
}

[System.Serializable]
public class LabelledColor
{
    public string id;
    public Color color;
}
