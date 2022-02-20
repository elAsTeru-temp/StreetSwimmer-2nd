using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCarTrigger : MonoBehaviour
{
    [Tooltip("�Ԃ��A�N�e�B�u�ɂ���Ƃ��̈ʒu")] [SerializeField] private Vector3 activePos = new Vector3(-1.1f, 0.1f, -5.0f);
    private GameObject thisCarObj;  //�q�̃g���K�[�̎q�̈ʒu�ɂ���Ԃ̃I�u�W�F�N�g

    void Start()
    {
        //�q�̈ʒu�ɂ���Ԃ̃I�u�W�F�N�g���擾
        thisCarObj = transform.GetChild(0).gameObject;
        //�Ԃ̈ʒu���g���K�[�̈ʒu�ɃA�N�e�B�u�ɂ��鎞�̈ʒu�𑫂����ꏊ�ɐݒ肷��
        thisCarObj.transform.position = activePos + this.transform.position;
        //�q�̃I�u�W�F�N�g�̎Ԃ��A�N�e�B�u�ɂ���
        thisCarObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�������������̂��v���C���[�Ȃ�
        if (other.tag == "Player")
        {
            //��A�N�e�B�u�ɂȂ��Ă���q�I�u�W�F�N�g�̎Ԃ��A�N�e�B�u�ɂ���
            thisCarObj.SetActive(true);
        }
    }
}
