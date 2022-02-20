using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigEvent : MonoBehaviour
{
    private GameObject ObjectPool;
    private GameObject pool;
    private void Start()
    {
        if (!ObjectPool) { ObjectPool = GameObject.Find("ObjectPool"); }
        pool = GameObject.Find("Pool");
    }
    private void OnTriggerEnter(Collider col)
    {
        //当たったオブジェクトが人なら
        if (col.tag == "HumanCollider")
        {
            ObjectPool.GetComponent<ObjectPool>().SetDeactive(null, col.gameObject.transform.parent.parent.gameObject);
            //当たった人を非アクティブにする
            //pool.GetComponent<Pool>().PoolObjSetDeactive(col.gameObject.transform.parent.parent.gameObject);
        }

        if (col.tag == "Ground")
        {
            this.transform.localScale = this.transform.localScale * 0.7f;
            if (this.transform.localScale.x < 0.4f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
