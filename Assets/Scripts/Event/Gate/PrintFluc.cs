using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintFluc : MonoBehaviour
{
    /// <summary>
    /// �Q�[�g�ő�������ʂ̒l��\�����邽�߂̃e�L�X�g
    /// </summary>
    /// <param name="_operator">���Z�q</param>
    /// <param name="_num">�l</param>
    public void UpdateText(string _operator, int _num)
    {
        this.GetComponent<TextMesh>().text = (_operator + _num).ToString();
    }
}
