using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://qiita.com/tsucchi13/items/ef2cec53cdfb8ed9a855

public class Player : MonoBehaviour
{
    private Vector3 addPos;         //移動量をベクターにするための変数
    private Vector3 preMousePos;    //事前のマウス位置

    private Vector2 speed;  //プレイヤーの左右、前方の移動速度
    private float sideLimit; //左右の移動制限
    private float moveCenterSpeed;

    private int validMoveNumOneTap;    //１回のタップで動ける回数
    private int validMoveNum;

    private Vector3 angleSharkAfterGoal;
    private Vector3 firstAngle;
    private int angleChangeMaxNum = 10;
    private int nowTapNum = 0;

    private void Start()
    {
        speed = GetComponentInParent<PlayerMgr>().GetPlayerSpeed();
        sideLimit = GetComponentInParent<PlayerMgr>().GetSideLimit();
        validMoveNumOneTap = GetComponentInParent<PlayerMgr>().GetValidMoveNumOneTap();
        moveCenterSpeed = GetComponentInParent<PlayerMgr>().GetMoveCenterSpeed();
        angleSharkAfterGoal = GetComponentInParent<PlayerMgr>().GetAngleSharkAfterGoal();
        firstAngle = gameObject.transform.rotation.eulerAngles;
        addPos = new Vector3(0, 0, speed.y);      //ベクターに変換
    }

    public void Move()
    {
        this.transform.position += addPos;  //前方移動
        /// ----------------------------------------------------
        /// 計算部分:マウスの移動量からプレイヤーを左右に移動する
        /// ----------------------------------------------------
        if (Input.GetMouseButtonDown(0))
        {
            preMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            //事前のマウスの位置とインプットして移動した量を測る
            Vector3 mousePosDiff = Input.mousePosition - preMousePos;
            //現在のマウスの位置を事前のポジションとして記録する
            preMousePos = Input.mousePosition;
            //現在のプレイヤーの位置に移動量を足すための変数を作成
            Vector3 newPos = this.transform.position + new Vector3(mousePosDiff.x / Screen.width, 0, 0) * speed.x;

            //ステージの端によりすぎないようにする
            if (newPos.x < -sideLimit)
            {
                newPos.x = -sideLimit;
            }
            if (newPos.x > sideLimit)
            {
                newPos.x = sideLimit;
            }

            //移動後の位置に移動させる
            this.transform.position = newPos;
        }
    }

    /// <summary>
    /// プレイヤーを中央へ移動させる関数
    /// </summary>
    /// <returns>移動が完了:true、未完:false</returns>
    /// <detail>trueが帰ってくるまで続行することで、中央に移動できる</detail>
    public bool MoveCenter()
    {
        //中央にいたらtrueを返して終了
        if (this.transform.position.x == 0)
        {
            return true;
        }
        //次の移動量で中央を越してしまいそうなら、中央の値を代入する
        else if (-0.05 <= this.transform.position.x && this.transform.position.x <= 0.05)
        {
            this.transform.position = new Vector3(0, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            //中心より左側にいるなら、右に移動(else:逆)
            if (this.transform.position.x < 0)
            {
                this.transform.position += new Vector3(moveCenterSpeed, 0, 0);
            }
            else
            {
                this.transform.position += new Vector3(-moveCenterSpeed, 0, 0);
            }
        }
        //まだ中央への移動が終了していないので、falseを返して終了
        return false;
    }
    /// <summary>
    /// 整列完了位置(プレイヤーの操作が可能になる位置)までの移動
    /// </summary>
    public void MoveToAlignEndPos()
    {
        this.transform.position += addPos;  //前方移動
    }
    //タップで進む操作
    public void MoveAfterGoal()
    {
        if (Input.GetMouseButtonDown(0))
        {
            validMoveNum += validMoveNumOneTap;
            OutSharkHead();
        }
        if(validMoveNum > 0)
        {
            validMoveNum--;
            this.transform.position += new Vector3(0, 0, 0.05f) ;  //前方移動
        }
    }

    public void OutSharkHead()
    {
        if (nowTapNum < angleChangeMaxNum)
        {
            nowTapNum++;
            this.transform.rotation = Quaternion.Euler(Vector3.Lerp(firstAngle, angleSharkAfterGoal, (float)nowTapNum / angleChangeMaxNum));
        }
    }
}
