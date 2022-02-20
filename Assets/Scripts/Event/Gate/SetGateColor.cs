using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGateColor : MonoBehaviour
{
    private Color32 green = new Color32(20,255,0,60);
    private Color32 orange = new Color32(255, 100, 0, 60);
    private Color32 blue = new Color32(0, 120, 255, 60);
    private Color32 purple = new Color32(255, 0, 255, 60);

    public void SetColor(string _ope)
    {
        if (_ope == "Å{") { GetComponent<Renderer>().material.color = green; }
        if (_ope == "Å|") { GetComponent<Renderer>().material.color = blue; }
        if (_ope == "Å~") { GetComponent<Renderer>().material.color = orange; }
        if (_ope == "ÅÄ") { GetComponent<Renderer>().material.color = purple; }
    }
}