using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCar : MonoBehaviour
{
    private GameObject mgr; //このオブジェクトのマネージャー
    private float speed;    //速度
    private int leftKillNum;  //残りの消せる人数
    private GameObject textMesh;    //消せる人数を表示するためのテキストメッシュ
    private GameObject eff; //同じ階層にあるエフェクトを格納する


    // Start is called before the first frame update
    void Start()
    {
        //マネージャーを探索
        mgr = GameObject.Find("BackCarMgr");
        //エフェクトを取得(同じ階層)
        eff = transform.parent.Find("Explosion").gameObject;
        //テキストメッシュを探索
        textMesh = transform.GetChild(0).gameObject;
        //速さを取得
        speed = mgr.GetComponent<BackCarMgr>().GetSpeed();
        //消せる数を取得
        leftKillNum = mgr.GetComponent<BackCarMgr>().GetKillNum();
        //テキストメッシュを更新
        UpdateTextMesh();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.position += new Vector3(0, 0, speed);
    }
    private void OnTriggerStay(Collider other)
    {
        //当たったオブジェクトが人かつ、消せる人数の残りが0出なければ
        if (other.tag == "HumanCollider" && leftKillNum > 0)
        {
            //残りの消せる人数を減らす
            leftKillNum--;
            //テキストメッシュを更新
            UpdateTextMesh();
            //人を非アクティブにする
            other.gameObject.transform.parent.parent.gameObject.SetActive(false);
        }
        //もし消せる人が0になっていたら
        if (leftKillNum <= 0)
        {
            mgr.GetComponent<BackCarMgr>().DestroyCar(this.gameObject, eff);
        }
    }
    private void UpdateTextMesh()
    {
        textMesh.GetComponent<TextMesh>().text = (-leftKillNum).ToString();
    }
}
