using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignColl : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //“–‚½‚è”»’è‚ªÀs‚³‚ê‚½‚±‚Æ‚ğ“`‚¦‚é
            GetComponentInParent<AlignMgr>().hitAlignColl();
        }
    }
}
