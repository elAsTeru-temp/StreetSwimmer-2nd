using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Tooltip("�}�b�v�̃I�u�W�F�N�g�F�v���n�u���A�^�b�`")] [SerializeField] private GameObject mapObj;
    private GameObject mapForEditObj;

    void Start()
    {
        //�ҏW�p�}�b�v���Ȃ����
        if(!GameObject.Find("MapForEdit"))
        {
            //�}�b�v�𐶐�����
            Instantiate(mapObj, Vector3.zero, Quaternion.identity, this.transform);
        }
        else
        {
            Debug.Log("�ҏW�p�̃}�b�v���g���Ă܂��B�I��������A�N�e�B�u�ɂ��Ă�������");
        }
    }
}
