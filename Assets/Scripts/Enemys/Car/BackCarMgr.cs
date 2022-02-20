using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCarMgr : MonoBehaviour
{
    [Header("Mgr Setting")]
    [Tooltip("�g���K�[�ƎԂ��Z�b�g�ɂȂ����v���n�u���A�^�b�`")] [SerializeField] private GameObject triggerObj;
    [Header("Car Setting")]
    [Tooltip("�Ԃ̑���")] [SerializeField] private float speed = 0.09f;
    [Tooltip("�Ԃ�������l�̐�")] [SerializeField] private int killNum = 10;

    private GameObject space;   //��������I�u�W�F�N�g���i�[������
    private GameObject clone;   //�������ꂽ�I�u�W�F�N�g�̒���G�鎞�Ɏg�p����

    public void OrderInst(int _stageNumber)
    {
        //�I�u�W�F�N�g���i�[�����Ԃ��쐬
        space = new GameObject("Obj Space");
        //����������Ԃ��q�̈ʒu�Ɉړ�
        space.transform.parent = this.transform;

        if (_stageNumber == 3)
        {
            clone = Instantiate(triggerObj, new Vector3(0, 0, 16.0f), Quaternion.identity, space.transform);
        }
        else if (_stageNumber == 4)
        {
            clone = Instantiate(triggerObj, new Vector3(0, 0, 29.0f), Quaternion.identity, space.transform);
        }
        else if (_stageNumber == 5)
        {
            clone = Instantiate(triggerObj, new Vector3(0, 0, 9.0f), Quaternion.identity, space.transform);
        }
    }

    public void DestroyCar(GameObject _gObj, GameObject _eff)
    {
        //�I���ʒu���擾
        Vector3 destroyPos = _gObj.transform.position;
        //�G�t�F�N�g���Đ�����̂ł����
        if (_eff)
        {
            //�ʒu���X�V����
            _eff.transform.position = destroyPos;
            //���j�G�t�F�N�g���Đ�
            _eff.SetActive(true);
        }
        //�Ԃ��A�N�e�B�u��
        _gObj.SetActive(false);
    }

    public float GetSpeed() { return speed; }
    public int GetKillNum() { return killNum; }
}
