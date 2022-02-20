using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignMgr : MonoBehaviour
{
    private bool alignStartFlag;    //����J�n���Ǘ�����t���O
    private bool alignCompFlag;     //���񊮗����Ǘ�����t���O

    private void Start()
    {
        alignStartFlag = false;
        alignCompFlag = false;
    }

    /// <summary>
    /// �q�I�u�W�F�N�g�̓����蔻�肪���s���ꂽ��
    /// </summary>
    public void hitAlignColl()
    {
        if (!alignStartFlag)
        {
            alignStartFlag = true;
            return;
        }
        else if(!alignCompFlag)
        {
            alignCompFlag = true;
            return;
        }
    }
    /// <summary>
    /// ����J�n�̏�ԃt���O��Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool GetAlignStartFlag() { return alignStartFlag; }
    /// <summary>
    /// ���񊮗��̏�ԃt���O��Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool GetAlignCompFlag() { return alignCompFlag; }
}
