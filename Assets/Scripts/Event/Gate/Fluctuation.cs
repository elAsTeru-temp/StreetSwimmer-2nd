using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fluctuation : MonoBehaviour
{
    /// ----------------------------------------------------
    /// 関数呼び出し関連
    /// ----------------------------------------------------
    private GameObject humanPool = null;  //人のスクリプトが入ったオブジェクトをアタッチ
    [HideInInspector] public bool ranFunc = false;   //増減の関数が実行されたか管理するフラグ

    public int value;
    public string opeStr;      //計算の値を表示するための文字を入れる変数

    // Start is called before the first frame update
    void Start()
    {
        //関数の入ったオブジェクトの名前から検索し変数に保存する
        humanPool = GameObject.Find("HumanPool");
    }

    public void Set(string _opeStr, int _value)
    {
        value = _value;
        opeStr = _opeStr;
        DataUpdate();
    }
    public void DataUpdate()
    {
        //3Dテキストに表示する
        GetComponentInChildren<PrintFluc>().UpdateText(opeStr, value);
        //ゲートの色を変更する
        GetComponent<SetGateColor>().SetColor(opeStr);
    }

    void OnTriggerEnter(Collider _col)
    {
        //当たった人の座標を記録
        Vector3 humanPos = _col.gameObject.transform.position;
        //まだ1度も呼び出されていなかったら
        if (ranFunc == false)
        {
            ranFunc = true;
            //通ったオブジェクトのタグがHumanなら
            if (_col.tag == "HumanCollider")
            {
                //Human内の関数を呼ぶ
                humanPool.GetComponent<Pool>().HumanFluct(opeStr, value);
            }
        }
    }


}
