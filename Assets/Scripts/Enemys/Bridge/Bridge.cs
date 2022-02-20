using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private GameObject pObj;

    void Start()
    {
        if(!pObj) { pObj = GameObject.Find("PlayerObj"); }
    }

    void Update()
    {
        if(this.transform.position.z + 5 < pObj.transform.position.z)
        {
            this.gameObject.SetActive(false);
        }
    }
}
