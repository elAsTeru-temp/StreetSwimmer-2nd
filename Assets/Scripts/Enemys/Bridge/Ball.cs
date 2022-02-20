using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool releaseBallFlag;   //球を落したか管理するフラグ

    private void Update()
    {
        //ボールが離されてなかったら
        releaseBallFlag = GetComponentInParent<BridgeHuman>().GetReleaseBallFlag();
        if(!releaseBallFlag)
        {
            Chase();
        }
    }

    /// <summary>
    /// 対象に合わせてボールを移動させる
    /// </summary>
    public void Chase()
    {
        this.transform.position = new Vector3
            (
            this.GetComponentInParent<BridgeHuman>().gameObject.transform.position.x,
            this.transform.position.y,
            this.transform.position.z
            );
    }

    public void MoveDropPoint(Vector3 _firDropPosDist)
    {
        this.transform.position += _firDropPosDist;
    }
}
