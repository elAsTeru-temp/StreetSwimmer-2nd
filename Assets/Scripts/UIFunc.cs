using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunc : MonoBehaviour
{
    [SerializeField] private GameObject gameMgr;    //ゲームマネージャーをアタッチ
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //ゲームが始まる前の指のUIを動かすのに使用する
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private GameObject fingerImg;
    private Vector3 fingerFirstPos;          //最初の位置
    private float rangeFinger;               //左右の振れ幅
    private float rangeFingerSpeed;          //左右の振れの割り合い
    private float angleValue;                //角度
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //クリア後の指のUIをタップさせるのに使用する
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private GameObject tapImg;
    private float expandMax;    //拡大最大倍率
    private float shrinkMax;    //縮小最大倍率
    private float expandLeapNow;    //現在の拡大倍率の割合(0~1)
    private float tapSpeed; //(0~1)
    private bool leapDir;

    // Start is called before the first frame update
    void Start()
    {
        fingerImg = gameMgr.GetComponent<GameManager>().fingerImg;          //指画像のオブジェクトを取得
        fingerFirstPos = fingerImg.transform.position;                      //指の座標を取得
        rangeFinger = gameMgr.GetComponent<GameManager>().rangeFinger;      //指の画像の振れ幅
        rangeFingerSpeed = gameMgr.GetComponent<GameManager>().rangeFingerSpeed;

        tapImg = gameMgr.GetComponent<GameManager>().tapImg;
        expandMax = gameMgr.GetComponent<GameManager>().tapImgExpandMax;
        shrinkMax = gameMgr.GetComponent<GameManager>().tapImgShrinkMax;
        expandLeapNow = 0.5f;   //中間のサイズ
        tapSpeed = gameMgr.GetComponent<GameManager>().tapSpeed;
    }   

    /// <summary>
    /// 円運動のx移動のみ利用して指を左右に動かす
    /// </summary>
    public void MoveFingerImg()
    {
        angleValue += rangeFingerSpeed;                   //角度を加算する
        if(angleValue > 359) { angleValue = 0; }          //360を超えたら0にする
        float rad = angleValue * 3.14f / 180.0f;          //度数法を弧度法に変換
        float addX = Mathf.Cos(rad) * rangeFinger;        //三角関数により、円周上の座標を取得
        //画像の位置を移動させる
        fingerImg.transform.position = new Vector3(fingerFirstPos.x + addX, fingerFirstPos.y, fingerFirstPos.z);
    }
    public void TapFingerImg()
    {
        if (leapDir)
        {
            expandLeapNow += tapSpeed;
            if(expandLeapNow > 1)
            {
                leapDir = !leapDir;
                expandLeapNow = 1;
            }
        }
        else
        {
            expandLeapNow -= tapSpeed;
            if (expandLeapNow < 0)
            {
                leapDir = !leapDir;
                expandLeapNow = 0;
            }
        }

        Vector3 newScale = Vector3.Lerp
             (
                new Vector3(expandMax, expandMax, 1),
                new Vector3(shrinkMax, shrinkMax, 1),
                expandLeapNow
            );

        this.transform.localScale = newScale;
    }
}