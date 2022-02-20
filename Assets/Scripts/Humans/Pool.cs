using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private GameObject ObjectPool;
    private GameObject playerObj;
    private GameObject delEffect;
    private float distFromPlayer;
    private Vector3 targetPos;  //移動で目指す位置
    private Vector3 addPosX;

    private void Start()
    {
        if (!ObjectPool) { ObjectPool = GameObject.Find("ObjectPool"); }
        addPosX.x = GetComponentInParent<HumansMgr>().GetSpeed();
        playerObj = GameObject.Find("PlayerObj");
        distFromPlayer = GetComponentInParent<HumansMgr>().GetDistFromPlayer();
        delEffect = GetComponentInParent<HumansMgr>().GetDelEffect();

    }

    public void StandardMove()
    {
        //旧移動：プレイヤーと反対の位置になる+++++++++++++++++++++++++++
        //this.transform.position = new Vector3
        //    (
        //    -playerObj.transform.position.x,
        //    this.transform.position.y,
        //    playerObj.transform.position.z + distFromPlayer
        //    );
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //// 前進移動処理
        this.transform.position = new Vector3
            (
                this.transform.position.x,                          //左右はそのまま
                this.transform.position.y,                          //高さはそのまま
                playerObj.transform.position.z + distFromPlayer     //プレイヤーに間隔の距離を足したもの
            );
        //// 左右移動処理
        //まず目指す位置を取得(プレイヤーとの反対の位置)
        targetPos = new Vector3
            (
                -playerObj.transform.position.x,                    //プレイヤーの座標を反転
                this.transform.position.y,                          //高さはそのまま
                this.transform.position.z                           //間隔はそのまま
            );
        //目的地までの距離を測る
        float dist = targetPos.x - this.transform.position.x;
        if(dist < 0)    //距離が－なら計算のために+にする
        {
            dist *= -1;
        }
        if (dist == 0)  //移動距離が0なら終了する
        {
            return;
        }
        if(dist < addPosX.x)    //距離が移動量より小さいなら固定で目的地に移動させて終了する
        {
            this.transform.position = targetPos;
            return;

        }
        //目的座標がプールの右にあったら
        if(targetPos.x > this.transform.position.x)
        {
            this.transform.position += addPosX; //右に移動させる
        }
        else
        {
            this.transform.position -= addPosX; //左に移動
        }

    }

    /// <summary>
    /// 人の移動をプレイヤーからの距離じゃなくてゆっくりとした移動にする
    /// </summary>
    /// <detail>中央に移動させた後に使う</detail>
    public void GoalMove()
    {
        this.transform.position = new Vector3
            (
            this.transform.position.x,
            this.transform.position.y,
            this.transform.position.z + 0.005f
            );
    }

    public void HumanFluct(string _ope, int _val)
    {
        GameObject humanObj = GetComponentInParent<HumansMgr>().GetHumanObj();
        float range = GetComponentInParent<HumansMgr>().GetRange();
        Vector3 insAddPos = new Vector3(0, 0, 0.1f); //生成位置に足す値を入れる変数

        //_opeに入っている値によって計算を分ける
        if (_ope != "")
        {
            switch (_ope)
            {
                case "＋": //+
                    for (int i = 0; i < _val; i++)
                    {
                        //x座用に足す値を乱数で生成する
                        insAddPos.x = Random.Range(-range, range);  //0~2で生成して-1して-1~1にする
                        insAddPos.z = Random.Range(-range, range);
                        //人を生成orアクティブ化
                        ObjectPool.GetComponent<ObjectPool>().SetActive(this.gameObject, this.transform.position + insAddPos);
                    }
                    break;
                case "－": //-
                    for (int i = 0; i < _val; i++)
                    {
                        //人を非アクティブ化
                        ObjectPool.GetComponent<ObjectPool>().SetDeactive(this.gameObject, null);
                    }
                    break;
                case "×": //×
                    int nowAffObjNum = GetComponentInParent<HumansMgr>().GetActiveNum();
                    for (int i = 0; i < _val * nowAffObjNum - nowAffObjNum; i++)
                    {
                        //x座用に足す値を乱数で生成する
                        insAddPos.x = Random.Range(-range, range);
                        insAddPos.z = Random.Range(-range, range);
                        //人を生成orアクティブ化
                        ObjectPool.GetComponent<ObjectPool>().SetActive(this.gameObject, this.transform.position + insAddPos);
                    }
                    break;
                case "÷": //÷
                    for (int i = 0; i < _val; i++)
                    {
                        //人を非アクティブ化
                        ObjectPool.GetComponent<ObjectPool>().SetDeactive(this.gameObject, null);
                    }
                    break;
            }
        }
        else
        {
            //演算子が決められてないからダメ
            return;
        }
    }
    //エフェクトを生成
    public void insEff (Vector3 _insPos)
    {
        _insPos = new Vector3
            (
                _insPos.x,
                _insPos.y + 0.5f,
                _insPos.z
            );
        Instantiate(delEffect, _insPos, Quaternion.identity, this.transform);
        Debug.Log("エフェクト生成");
    }

    /// <summary>
    /// ゴール時に人が整列するように目指す位置を渡す関数(1度しか使わない)
    /// </summary>
    public void SetAlignTargetPos()
    {
        int foundCount = 0;
        //アクティブなオブジェクトをプール中から探索する
        foreach(Transform t in this.transform)
        {
            if(t.gameObject.activeSelf)
            {
                //アクティブなオブジェクトがいたら発見数をカウントする
                foundCount++;

                //見つけたオブジェクト内の位置(現在の位置)を代入する
                t.GetComponent<Human>().alignStartPos = t.position;

                //見つけたオブジェクト内の目的座標のvector3型変数に目指すべき座標を代入する
                t.GetComponent<Human>().alignTargetPos = new Vector3
                    (
                        this.transform.position.x,
                        t.position.y,
                        this.transform.position.z + foundCount * 0.2f
                    );
            }
        }
    }

    /// <summary>
    /// プール内のオブジェクトを整列する関数
    /// </summary>
    /// <param name="_parcent">どのくらいの割合まで進んだか</param>
    public void Align(float _parcent)
    {
        int foundCount = 0;

        //アクティブオブジェクトをプールの中から探索
        foreach (Transform t in this.transform)
        {
            if (t.gameObject.activeSelf)
            {
                foundCount++;
                t.GetComponent<Human>().MoveTargetPos(_parcent);
            }
        }
    }

    public void SetIsKinematic(bool _flag)
    {
        foreach (Transform t in this.transform)
        {
            //有効状態なら
            if (t.gameObject.activeSelf)
            {
                t.GetComponent<Rigidbody>().isKinematic = _flag;
            }
        }
    }

    //人を中央に向かって動かす関数を呼び出すためのもの
    public void RunStandardMove()
    {
        foreach (Transform t in this.transform)
        {
            //有効状態なら
            if (t.gameObject.activeSelf)
            {
                t.GetComponent<Human>().StandardMove();
            }
        }
    }

    //一番前にいる人の座標を取得するための関数
    public float GetHead()
    {
        float maxZ = 0;  //一番前の座標が入る

        //アクティブなオブジェクトをプール中から探索する
        foreach (Transform t in this.transform)
        {
            if (t.gameObject.activeSelf)
            {
                if (t.gameObject.transform.position.z > maxZ)
                {
                    maxZ = t.gameObject.transform.position.z;
                }
            }
        }
        return maxZ;
    }
}
