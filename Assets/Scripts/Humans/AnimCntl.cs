using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCntl : MonoBehaviour
{
    private GameObject gameMgr;    //生成して使うのでゲームマネージャーを探索してアタッチする
    public Animator animator;

    private Vector3 prePos;
    private Vector3 nowPos;

    private void Start()
    {
        gameMgr = GameObject.Find("GameMgr");
        prePos = transform.position;
        nowPos = transform.position;
    }

    void Update()
    {
        nowPos = transform.position;    //現在位置を更新

        //前回の位置から進んでいれば走りモーションにする
        if (prePos.z < nowPos.z)
        {
            animator.SetBool("Run", true);
        }
        //そうでなければ停止する
        else
        {
            animator.SetBool("Run", false);
        }
        ////前回の位置より右にいれば右走りモーションにする
        //if (prePos.x + 0.1f < nowPos.x)
        //{
        //    animator.SetBool("Right", true);
        //}
        //else
        //{
        //    animator.SetBool("Right", false);
        //}
        ////前回の位置より左にいれば左走りモーションにする
        //if (prePos.x - 0.1f > nowPos.x)
        //{
        //    animator.SetBool("Left", true);
        //}
        //else
        //{
        //    animator.SetBool("Left", false);
        //}
        //現在の位置を過去の位置として記録する
        prePos = nowPos;
    }
}
