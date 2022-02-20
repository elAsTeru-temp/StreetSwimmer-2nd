using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTest : MonoBehaviour
{
    [Tooltip("回転の値を入手or適応するオブジェクト")]　[SerializeField] private GameObject rotObj;
    private Quaternion rotQua;       //スクリプト内角度(クオータニオン角)
    private Vector3    rotEul;       //インスペクター内角度(オイラー角)

    private Vector3 rotChange = new Vector3(90, 0, 0); //x角を90°に回転させたい(オイラー角)

    void Update()
    {
        //ずっと処理されるとみにくいので
        //Aキーが押されたら実行する
        if (Input.GetKeyDown(KeyCode.A))
        {
            /*
            角度の取得
            */
            //ステージの角を手に入れるとクオータニオン角になってしまうので
            rotQua = rotObj.transform.rotation;
            //クオータニオン角をオイラー角変換
            rotEul = rotQua.eulerAngles;
            //オイラー角で入手出来ているか確認(オイラー角で表示できるはず)
            Debug.Log(rotEul);


            //オブジェクトをオイラー角で回転させる
            rotObj.transform.rotation = Quaternion.Euler(rotChange);
        }
    }
}