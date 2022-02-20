using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Vector3 alignStartPos;          //整列が開始された位置
    public Vector3 alignTargetPos;         //整列時に目指す位置が入る
    private GameObject gMgr;       //ゲームマネージャー
    private Rigidbody rigid;
    private bool hit;

    void Start()
    {
        gMgr = GameObject.Find("GameMgr");
        rigid = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 目的の座標に移動するための関数
    /// </summary>
    /// <param name="_par">今どのくらい目的地まですすんだかの割り合い</param>
    public void MoveTargetPos(float _par)
    {
        //補間移動  //移動開始位置　移動終了位置　どのくらいまで進んだか
        this.transform.position = Vector3.Lerp(alignStartPos, alignTargetPos, _par);
    }

    public void StandardMove()
    {
        //力をゼロにして外に飛ばないようにして
        this.rigid.velocity = Vector3.zero;
        //中心によらせる
        this.transform.position = Vector3.MoveTowards(transform.position, transform.parent.transform.position, 0.01f);
    }
}