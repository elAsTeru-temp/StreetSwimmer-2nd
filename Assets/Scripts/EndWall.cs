using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWall : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //���������I�u�W�F�N�g���l�Ȃ�
        if (other.tag == "HumanCollider" )
        {
            //�l���A�N�e�B�u�ɂ���
            other.gameObject.transform.parent.parent.gameObject.SetActive(false);
        }
    }
}
