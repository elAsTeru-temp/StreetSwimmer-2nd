using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeHuman : MonoBehaviour
{
    private bool releaseBallFlag;   //球を落したか管理するフラグ
    private Vector3 firstPos;
    private float speed;
    private GameObject targetObj;
    private float dropDist;
    private Vector3 firstDropPosDist;

    private void Start()
    {
        firstPos = this.transform.position;
        speed = GetComponentInParent<BridgeMgr>().GetSpeed();
        dropDist = GetComponentInParent<BridgeMgr>().GetDropDist();
        firstDropPosDist = GetComponentInParent<BridgeMgr>().GetFirstDropPosDist();
        targetObj = GetComponentInParent<BridgeMgr>().GetTargetObj();
    }

    private void Update()
    {
        //橋上の人がボールを落としてなかったら処理する
        if(!releaseBallFlag)
        {
            //人を追いかけるように移動させる
            Chase();
            //もし対象とのZの距離が決めていた値以下になったら球を落下させる関数を呼ぶ
            if (this.transform.position.z - targetObj.transform.position.z <= dropDist)
            {
                //ボールを落としたことを伝える
                releaseBallFlag = true;
                //球の位置を落下開始の位置に移動させる
                this.GetComponentInChildren<Ball>().MoveDropPoint(firstDropPosDist);
                this.GetComponentInChildren<Rigidbody>().isKinematic = false;       //球を落下させる
            }
        }
    }

    public bool GetReleaseBallFlag() { return releaseBallFlag; }

    /// <summary>
    /// 歩道橋上の人を移動させる関数
    /// </summary>
    public void Chase()
    {
        Vector3 addPosX = new Vector3(speed, 0, 0);  //移動加算量をベクターにする

        //移動量が、_speedより小さい場合人のX座標と同じにする
        float dist = targetObj.transform.position.x - this.transform.position.x;
        if( -speed <= dist && dist <= speed)
        {
            //人のX座標と同じにする
            this.transform.position = new Vector3(targetObj.transform.position.x, firstPos.y, firstPos.z);
            return; //関数を出る
        }

        //追いかける対象の位置が、現在の位置より右側なら
        if (targetObj.transform.position.x > this.transform.position.x)
        {
            this.transform.position += addPosX; //右に移動させ
        }
        else
        {
            this.transform.position -= addPosX; //左に移動させ
        }
    }
}