using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintFluc : MonoBehaviour
{
    /// <summary>
    /// ゲートで増減する量の値を表示するためのテキスト
    /// </summary>
    /// <param name="_operator">演算子</param>
    /// <param name="_num">値</param>
    public void UpdateText(string _operator, int _num)
    {
        this.GetComponent<TextMesh>().text = (_operator + _num).ToString();
    }
}
