using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCarMgr : MonoBehaviour
{
    [Header("Mgr Setting")]
    [Tooltip("トリガーと車がセットになったプレハブをアタッチ")] [SerializeField] private GameObject triggerObj;
    [Header("Car Setting")]
    [Tooltip("車の速さ")] [SerializeField] private float speed = 0.09f;
    [Tooltip("車が消せる人の数")] [SerializeField] private int killNum = 10;

    private GameObject space;   //生成するオブジェクトを格納する空間
    private GameObject clone;   //複製されたオブジェクトの中を触る時に使用する

    public void OrderInst(int _stageNumber)
    {
        //オブジェクトを格納する空間を作成
        space = new GameObject("Obj Space");
        //生成した空間を子の位置に移動
        space.transform.parent = this.transform;

        if (_stageNumber == 3)
        {
            clone = Instantiate(triggerObj, new Vector3(0, 0, 16.0f), Quaternion.identity, space.transform);
        }
        else if (_stageNumber == 4)
        {
            clone = Instantiate(triggerObj, new Vector3(0, 0, 29.0f), Quaternion.identity, space.transform);
        }
        else if (_stageNumber == 5)
        {
            clone = Instantiate(triggerObj, new Vector3(0, 0, 9.0f), Quaternion.identity, space.transform);
        }
    }

    public void DestroyCar(GameObject _gObj, GameObject _eff)
    {
        //終了位置を取得
        Vector3 destroyPos = _gObj.transform.position;
        //エフェクトを再生するのであれば
        if (_eff)
        {
            //位置を更新して
            _eff.transform.position = destroyPos;
            //爆破エフェクトを再生
            _eff.SetActive(true);
        }
        //車を非アクティブに
        _gObj.SetActive(false);
    }

    public float GetSpeed() { return speed; }
    public int GetKillNum() { return killNum; }
}
