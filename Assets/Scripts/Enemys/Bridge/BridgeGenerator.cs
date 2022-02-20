//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BridgeGenerator : MonoBehaviour
//{
//    private GameObject bridgeObj;   //�������������̃I�u�W�F�N�g
//    private Vector3 instPos;
//    private Vector3 instRot;
//    private GameObject ObjectPool;
//    private GameObject bridgePoolObj;   //�v�[���I�u�W�F�N�g

//    void Start()
//    {
//        if (!ObjectPool) { ObjectPool = GameObject.Find("ObjectPool"); }
//        bridgeObj = GetComponentInParent<BridgeMgr>().GetBridgeObj();   //�������鋴�̃I�u�W�F�N�g���炤
//        bridgePoolObj = this.transform.Find("BridgePool").gameObject;
//    }

//    public void InstBridge()
//    {
//        instPos = GetComponentInParent<BridgeMgr>().GetInstPos();
//        //�����ʒu���S�[�����C����z���ĂȂ�������
//        if (instPos.z < GetComponentInParent<BridgeMgr>().GetGoalPosZ() - 10.0f)
//        {
//            ObjectPool.GetComponent<ObjectPool>().SetActive(bridgePoolObj, instPos);
//        }
//        else
//        {
//            Debug.Log("�S�[�����C����z���Ă�̂ŋ��𐶐����܂���B");
//        }
//    }
//}
