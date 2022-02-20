using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignMgr : MonoBehaviour
{
    private bool alignStartFlag;    //整列開始を管理するフラグ
    private bool alignCompFlag;     //整列完了を管理するフラグ

    private void Start()
    {
        alignStartFlag = false;
        alignCompFlag = false;
    }

    /// <summary>
    /// 子オブジェクトの当たり判定が実行されたか
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
    /// 整列開始の状態フラグを返す
    /// </summary>
    /// <returns></returns>
    public bool GetAlignStartFlag() { return alignStartFlag; }
    /// <summary>
    /// 整列完了の状態フラグを返す
    /// </summary>
    /// <returns></returns>
    public bool GetAlignCompFlag() { return alignCompFlag; }
}
