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
            //�l��������Ƃ��̃G�t�F�N�g�A�N�e�B�u��
            ObjectPool.GetComponent<ObjectPool>().SetActive(humanEffPoolObj,col.transform.position);
            //�Ώۂ��A�N�e�B�u��
            ObjectPool.GetComponent<ObjectPool>().SetDeactive(null, col.gameObject.transform.parent.parent.gameObject);
        }
    }
}
