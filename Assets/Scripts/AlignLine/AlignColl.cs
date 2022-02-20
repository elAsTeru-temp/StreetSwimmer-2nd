using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignColl : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //当たり判定が実行されたことを伝える
            GetComponentInParent<AlignMgr>().hitAlignColl();
        }
    }
}
