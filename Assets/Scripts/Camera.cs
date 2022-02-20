using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Quaternion  fixRot; //カメラの固定角度を入れる(fixation...固定)
    private Vector3     fixPos; //カメラの固定位置を入れる
    private Vector3     nowPos; //現在のカメラの位置を入れる
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// カメラの状態
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public enum State
    {
        Normal,
        Clear
    }
    public State state;
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// カメラの位置と向き
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Tooltip("プレイヤーのオブジェクト：基本アタッチしない")] [SerializeField] private GameObject pObj;
    [Tooltip("通常のカメラ位置")] [SerializeField]   private Vector3 cameraPosNormal = new Vector3(0.0f, 7.7f, -2.6f);
    [Tooltip("通常のカメラ向き")] [SerializeField]   private Vector3 cameraRotNormal = new Vector3(49.0f, 0.0f, 0.0f);

    [Tooltip("クリアのカメラ位置")] [SerializeField] private Vector3 cameraPosClear  = new Vector3(0.0f, 1.6f, -1.6f);
    [Tooltip("クリアのカメラ向き")] [SerializeField] private Vector3 cameraRotClear  = new Vector3(31.0f, 0.0f, 0.0f);

    private float leapNow;  //0~1
    [Tooltip("クリア時にどれくらいの割合でカメラを移動させるか")] [SerializeField] private float addLeap = 0.1f;
    private Vector3 leapPos;    //リープ関数での今の位置
    private Vector3 leapRot;    //リープ関数での今の向き

    Vector3 newPos; //移動後の位置が入る
    Vector3 newRot; //回転後の向きが入る

    [Tooltip("クリアのカメラ位置")] [SerializeField] private float moveXDivision = 40;

    //カメラとプレイヤーの距離
    float distY = 0.0f;
    float distZ = 0.0f;
    float rotX = 0.0f;

    private void Start()
    {
        //カメラの状態を通常にする
        state = State.Normal;
        //プレイヤーの情報を取得
        pObj = GameObject.Find("PlayerObj");
        //カメラの位置を初期化
        this.transform.position = cameraPosNormal;
        //カメラの角度を初期化
        this.transform.rotation = Quaternion.Euler(cameraRotNormal);
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //カメラの移動
    }

    private void Move()
    {
        //状態が通常なら
        if(state == State.Normal)
        {
            distY = cameraPosNormal.y;
            distZ = cameraPosNormal.z;
            rotX = cameraRotNormal.x;
        }
        else if(state == State.Clear && leapNow < 1.0f)     //状態がクリアで、リープが1になってなければ
        {
            //リープの割合を進める
            leapNow += addLeap;
            //リープでの現在のプレイヤーとカメラの距離をとる
            leapPos = Vector3.Lerp(cameraPosNormal, cameraPosClear, leapNow);
            leapRot = Vector3.Lerp(cameraRotNormal, cameraRotClear, leapNow);

            distY = leapPos.y;
            distZ = leapPos.z;
            rotX = leapRot.x;
        }

        newPos = new Vector3
            (
                pObj.transform.position.x / moveXDivision,          //横の移動は小さくする
                pObj.transform.position.y + distY,                  //現在のゲームの状態で変わる
                pObj.transform.position.z + distZ                   //現在のゲームの状態で変わる
            );
        newRot = new Vector3
            (
                rotX,
                this.transform.rotation.y,
                this.transform.rotation.z
            );

        //新しい位置を適応
        this.transform.position = newPos;
        //新しい向きを適応
        this.transform.rotation = Quaternion.Euler(newRot);
    }
}
