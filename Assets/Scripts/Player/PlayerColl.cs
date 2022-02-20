using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColl : MonoBehaviour
{
    private GameObject ObjectPool;
    GameObject humanPoolObj;
    GameObject humanEffPoolObj;
    
    private void Start()
    {
        if (!ObjectPool) { ObjectPool = GameObject.Find("ObjectPool"); }
        if (!humanEffPoolObj) { humanEffPoolObj = GameObject.Find("HumanEffectPool"); }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "HumanCollider")
        {
            //人が消えるときのエフェクトアクティブ化
            ObjectPool.GetComponent<ObjectPool>().SetActive(humanEffPoolObj,col.transform.position);
            //対象を非アクティブ化
            ObjectPool.GetComponent<ObjectPool>().SetDeactive(null, col.gameObject.transform.parent.parent.gameObject);
        }
    }
}
