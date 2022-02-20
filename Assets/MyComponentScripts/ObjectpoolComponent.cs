using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectpoolComponent : MonoBehaviour
{
    [Header("Objectpool Settings")]
    [Tooltip("Attach Poolingobject")] [SerializeField] private GameObject poolingObject;
    [Tooltip("Set Size Of Objectpool")] [SerializeField] private int size;
    // +++ Hide Variables +++
    private bool debug = false;
    private GameObject poolSpace;   //�v�[���̋��

    void Start()
    {
        if (debug) { Debug.Log("�I�u�W�F�N�g�v�[���̃f�o�b�O���L���ł��B�I�������false��"); }

        InstanceObjectPool();
    }

    private void Update()   //update�͊m�F�p�Ɏg��
    {
        if (debug)
        {
            //����or�A�N�e�B�u��
            if (Input.GetKeyDown(KeyCode.I))
            {
                SetActive(Vector3.zero);
            }
            //����or�A�N�e�B�u��
            if (Input.GetKeyDown(KeyCode.C))
            {
                CountPoolingObjectNum();
            }
            //��A�N�e�B�u��
            if (Input.GetKeyDown(KeyCode.D))
            {
                SetDeactive(null);
            }
            //�w�肵�Ĕ�A�N�e�B�u��
            if (Input.GetKeyDown(KeyCode.A))
            {
                GameObject g = GameObject.Find("Human(Clone)");
                SetDeactive(g);
            }
        }
    }


    // �v�[���̋�Ԃ𐶐�����֐�
    private void InstanceSpaceOfPool()
    {
        //�v�[����Ԃ��쐬(���O�̓v�[�����O�����I�u�W�F�N�g�̖��O��Pool���������̂ɂȂ�)
        poolSpace = new GameObject(poolingObject.name + "Pool");
        //�쐬�����v�[����Ԃ̏ꏊ�����̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�̎q�̈ʒu�Ɉړ�����
        poolSpace.transform.parent = this.transform;
    }


    // �v�[���𐶐�����֐�
    private void InstanceObjectPool()
    {
        //�I�u�W�F�N�g�v�[���̋�Ԃ��q�Ƃ��č쐬
        InstanceSpaceOfPool();

        //�ݒ肳�ꂽ�T�C�Y�̃I�u�W�F�N�g�v�[�����쐬����
        for (int i = 0; i < size; i++)
        {
            Instantiate(poolingObject, Vector3.zero, poolingObject.transform.rotation, poolSpace.transform);
        }

        //�����������������f�o�b�O�œ`����
        Debug.Log(poolingObject.name + "��" + CountPoolingObjectNum() + "�̃v�[�����쐬");

        //�A�N�e�B�u�ȃI�u�W�F�N�g��T�����Ė���������
        //foreach...�v�f�̐��������[�v���s����
        foreach (Transform t in poolSpace.transform)
        {
            if (t.gameObject.activeSelf)
            {
                t.gameObject.SetActive(false);
            }
        }
    }


    // �v�[�����̃I�u�W�F�N�g�̐��𐔂��ĕԂ��֐�
    public int CountPoolingObjectNum()
    {
        int count = 0;
        //�v�[��������A�N�e�B�u�ȃI�u�W�F�N�g��T������
        foreach (Transform t in poolSpace.transform)
        {
            if (t.gameObject.activeSelf)
            {
                count++;
            }
        }
        //���������邩�f�o�b�O�œ`����
        Debug.Log(poolingObject.name + "������" + count + "����܂��B");
        return count;
    }


    /// <summary>
    /// �v�[�����O����Ă���I�u�W�F�N�g��1�L��������
    /// </summary>
    /// <param name="_pos">�����ʒu</param>
    public GameObject SetActive(Vector3 _pos)
    {
        //��A�N�e�B�u�I�u�W�F�N�g���v�[���̒�����T��
        foreach (Transform t in poolSpace.transform)
        {
            if (!t.gameObject.activeSelf)
            {
                //�I�u�W�F�N�g�Ɉʒu�ƌ������Z�b�g
                t.SetPositionAndRotation(_pos, poolingObject.transform.rotation);
                //�A�N�e�B�u��
                t.gameObject.SetActive(true);
                //�A�N�e�B�u�ɂł����̂ŏI������
                return t.gameObject;
            }
        }
        //��A�N�e�B�u�ȃI�u�W�F�N�g���Ȃ�������V�K�ɐ���
        return Instantiate(poolingObject, _pos, poolingObject.transform.rotation, poolSpace.transform);
    }

    /// <summary>
    /// �v�[�����܂��͎w��I�u�W�F�N�g���A�N�e�B�u�ɂ���֐�
    /// </summary>
    /// <param name="_appoint">�w�肵�Ĕ�A�N�e�B�u���F�v�[�����ǂ�ł��悯��� null</param>
    public void SetDeactive(GameObject _appoint)
    {
        //�w�肳��Ă�����w�肳��Ă���I�u�W�F�N�g���A�N�e�B�u��
        if (_appoint)
        {
            _appoint.SetActive(false);
            return;
        }
        else
        {
            //�A�N�e�B�u�ȃI�u�W�F�N�g���v�[���̒�����T��
            foreach (Transform t in poolSpace.transform)
            {
                if (t.gameObject.activeSelf)
                {
                    //��A�N�e�B�u��
                    t.gameObject.SetActive(false);
                    //��A�N�e�B�u�ɂ�����I��
                    return;
                }
            }
        }
    }
}
