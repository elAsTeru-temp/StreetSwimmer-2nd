using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTest : MonoBehaviour
{
    [Tooltip("��]�̒l�����or�K������I�u�W�F�N�g")]�@[SerializeField] private GameObject rotObj;
    private Quaternion rotQua;       //�X�N���v�g���p�x(�N�I�[�^�j�I���p)
    private Vector3    rotEul;       //�C���X�y�N�^�[���p�x(�I�C���[�p)

    private Vector3 rotChange = new Vector3(90, 0, 0); //x�p��90���ɉ�]��������(�I�C���[�p)

    void Update()
    {
        //�����Ə��������Ƃ݂ɂ����̂�
        //A�L�[�������ꂽ����s����
        if (Input.GetKeyDown(KeyCode.A))
        {
            /*
            �p�x�̎擾
            */
            //�X�e�[�W�̊p����ɓ����ƃN�I�[�^�j�I���p�ɂȂ��Ă��܂��̂�
            rotQua = rotObj.transform.rotation;
            //�N�I�[�^�j�I���p���I�C���[�p�ϊ�
            rotEul = rotQua.eulerAngles;
            //�I�C���[�p�œ���o���Ă��邩�m�F(�I�C���[�p�ŕ\���ł���͂�)
            Debug.Log(rotEul);


            //�I�u�W�F�N�g���I�C���[�p�ŉ�]������
            rotObj.transform.rotation = Quaternion.Euler(rotChange);
        }
    }
}