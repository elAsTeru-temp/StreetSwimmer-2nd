using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Tooltip("マップのオブジェクト：プレハブをアタッチ")] [SerializeField] private GameObject mapObj;
    private GameObject mapForEditObj;

    void Start()
    {
        //編集用マップがなければ
        if(!GameObject.Find("MapForEdit"))
        {
            //マップを生成する
            Instantiate(mapObj, Vector3.zero, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("編集用のマップを使ってます。終わったら非アクティブにしてください");
        }
    }
}
