using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignColl : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //�����蔻�肪���s���ꂽ���Ƃ�`����
            GetComponentInParent<AlignMgr>().hitAlignColl();
        }
    }
}
