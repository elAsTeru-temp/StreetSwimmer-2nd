using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWall : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //当たったオブジェクトが人なら
        if (other.tag == "HumanCollider" )
        {
            //人を非アクティブにする
            other.gameObject.transform.parent.parent.gameObject.SetActive(false);
        }
    }
}
