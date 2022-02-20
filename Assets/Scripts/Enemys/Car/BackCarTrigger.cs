using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCarTrigger : MonoBehaviour
{
    [Tooltip("車をアクティブにするときの位置")] [SerializeField] private Vector3 activePos = new Vector3(-1.1f, 0.1f, -5.0f);
    private GameObject thisCarObj;  //子のトリガーの子の位置にある車のオブジェクト

    void Start()
    {
        //子の位置にある車のオブジェクトを取得
        thisCarObj = transform.GetChild(0).gameObject;
        //車の位置をトリガーの位置にアクティブにする時の位置を足した場所に設定する
        thisCarObj.transform.position = activePos + this.transform.position;
        //子のオブジェクトの車を非アクティブにする
        thisCarObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //もし当たったのがプレイヤーなら
        if (other.tag == "Player")
        {
            //非アクティブになっている子オブジェクトの車をアクティブにする
            thisCarObj.SetActive(true);
        }
    }
}
