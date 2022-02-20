using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintActiveNum : MonoBehaviour
{
    private GameObject targetObj;
    private GameObject poolObj;
    private bool debug = false;
    private float HeadPosZ;     //先頭の人の座標が入る
    private void Start()
    {
        if (debug) { Debug.LogWarning("人のUIのデバッグがonです"); }
        targetObj = GameObject.Find("HumanPool");
        poolObj = GameObject.Find("HumanPool");
    }

    //public void MovePrintActiveNum()
    //{
    //    //移動
    //    this.transform.position = new Vector3
    //    (
    //        targetObj.transform.position.x,
    //        0.9f,
    //        targetObj.transform.position.z + 0.5f
    //    );
    //}
    public void UpdatePrintActiveNum(int _nowNum)
    {
        //現在の人数をテキストに表示する
        this.GetComponent<TextMesh>().text = (_nowNum).ToString();
    }

    //先頭に移動させる関数
    public void MoveHead()
    {
        float maxZ = 0;
        maxZ = poolObj.GetComponent<Pool>().GetHead();  // 先頭のz座標を取得

        //移動
        this.transform.position = new Vector3(targetObj.transform.position.x, 0.9f, maxZ + 0.5f);
    }
}