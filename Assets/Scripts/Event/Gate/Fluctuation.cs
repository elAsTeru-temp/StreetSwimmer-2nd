using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fluctuation : MonoBehaviour
{
    /// ----------------------------------------------------
    /// �֐��Ăяo���֘A
    /// ----------------------------------------------------
    private GameObject humanPool = null;  //�l�̃X�N���v�g���������I�u�W�F�N�g���A�^�b�`
    [HideInInspector] public bool ranFunc = false;   //�����̊֐������s���ꂽ���Ǘ�����t���O

    public int value;
    public string opeStr;      //�v�Z�̒l��\�����邽�߂̕���������ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //�֐��̓������I�u�W�F�N�g�̖��O���猟�����ϐ��ɕۑ�����
        humanPool = GameObject.Find("HumanPool");
    }

    public void Set(string _opeStr, int _value)
    {
        value = _value;
        opeStr = _opeStr;
        DataUpdate();
    }
    public void DataUpdate()
    {
        //3D�e�L�X�g�ɕ\������
        GetComponentInChildren<PrintFluc>().UpdateText(opeStr, value);
        //�Q�[�g�̐F��ύX����
        GetComponent<SetGateColor>().SetColor(opeStr);
    }

    void OnTriggerEnter(Collider _col)
    {
        //���������l�̍��W���L�^
        Vector3 humanPos = _col.gameObject.transform.position;
        //�܂�1�x���Ăяo����Ă��Ȃ�������
        if (ranFunc == false)
        {
            ranFunc = true;
            //�ʂ����I�u�W�F�N�g�̃^�O��Human�Ȃ�
            if (_col.tag == "HumanCollider")
            {
                //Human���̊֐����Ă�
                humanPool.GetComponent<Pool>().HumanFluct(opeStr, value);
            }
        }
    }


}
