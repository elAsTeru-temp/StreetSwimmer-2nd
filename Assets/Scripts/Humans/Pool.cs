using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private GameObject ObjectPool;
    private GameObject playerObj;
    private GameObject delEffect;
    private float distFromPlayer;
    private Vector3 targetPos;  //�ړ��Ŗڎw���ʒu
    private Vector3 addPosX;

    private void Start()
    {
        if (!ObjectPool) { ObjectPool = GameObject.Find("ObjectPool"); }
        addPosX.x = GetComponentInParent<HumansMgr>().GetSpeed();
        playerObj = GameObject.Find("PlayerObj");
        distFromPlayer = GetComponentInParent<HumansMgr>().GetDistFromPlayer();
        delEffect = GetComponentInParent<HumansMgr>().GetDelEffect();

    }

    public void StandardMove()
    {
        //���ړ��F�v���C���[�Ɣ��΂̈ʒu�ɂȂ�+++++++++++++++++++++++++++
        //this.transform.position = new Vector3
        //    (
        //    -playerObj.transform.position.x,
        //    this.transform.position.y,
        //    playerObj.transform.position.z + distFromPlayer
        //    );
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //// �O�i�ړ�����
        this.transform.position = new Vector3
            (
                this.transform.position.x,                          //���E�͂��̂܂�
                this.transform.position.y,                          //�����͂��̂܂�
                playerObj.transform.position.z + distFromPlayer     //�v���C���[�ɊԊu�̋����𑫂�������
            );
        //// ���E�ړ�����
        //�܂��ڎw���ʒu���擾(�v���C���[�Ƃ̔��΂̈ʒu)
        targetPos = new Vector3
            (
                -playerObj.transform.position.x,                    //�v���C���[�̍��W�𔽓]
                this.transform.position.y,                          //�����͂��̂܂�
                this.transform.position.z                           //�Ԋu�͂��̂܂�
            );
        //�ړI�n�܂ł̋����𑪂�
        float dist = targetPos.x - this.transform.position.x;
        if(dist < 0)    //�������|�Ȃ�v�Z�̂��߂�+�ɂ���
        {
            dist *= -1;
        }
        if (dist == 0)  //�ړ�������0�Ȃ�I������
        {
            return;
        }
        if(dist < addPosX.x)    //�������ړ��ʂ�菬�����Ȃ�Œ�ŖړI�n�Ɉړ������ďI������
        {
            this.transform.position = targetPos;
            return;

        }
        //�ړI���W���v�[���̉E�ɂ�������
        if(targetPos.x > this.transform.position.x)
        {
            this.transform.position += addPosX; //�E�Ɉړ�������
        }
        else
        {
            this.transform.position -= addPosX; //���Ɉړ�
        }

    }

    /// <summary>
    /// �l�̈ړ����v���C���[����̋�������Ȃ��Ă������Ƃ����ړ��ɂ���
    /// </summary>
    /// <detail>�����Ɉړ���������Ɏg��</detail>
    public void GoalMove()
    {
        this.transform.position = new Vector3
            (
            this.transform.position.x,
            this.transform.position.y,
            this.transform.position.z + 0.005f
            );
    }

    public void HumanFluct(string _ope, int _val)
    {
        GameObject humanObj = GetComponentInParent<HumansMgr>().GetHumanObj();
        float range = GetComponentInParent<HumansMgr>().GetRange();
        Vector3 insAddPos = new Vector3(0, 0, 0.1f); //�����ʒu�ɑ����l������ϐ�

        //_ope�ɓ����Ă���l�ɂ���Čv�Z�𕪂���
        if (_ope != "")
        {
            switch (_ope)
            {
                case "�{": //+
                    for (int i = 0; i < _val; i++)
                    {
                        //x���p�ɑ����l�𗐐��Ő�������
                        insAddPos.x = Random.Range(-range, range);  //0~2�Ő�������-1����-1~1�ɂ���
                        insAddPos.z = Random.Range(-range, range);
                        //�l�𐶐�or�A�N�e�B�u��
                        ObjectPool.GetComponent<ObjectPool>().SetActive(this.gameObject, this.transform.position + insAddPos);
                    }
                    break;
                case "�|": //-
                    for (int i = 0; i < _val; i++)
                    {
                        //�l���A�N�e�B�u��
                        ObjectPool.GetComponent<ObjectPool>().SetDeactive(this.gameObject, null);
                    }
                    break;
                case "�~": //�~
                    int nowAffObjNum = GetComponentInParent<HumansMgr>().GetActiveNum();
                    for (int i = 0; i < _val * nowAffObjNum - nowAffObjNum; i++)
                    {
                        //x���p�ɑ����l�𗐐��Ő�������
                        insAddPos.x = Random.Range(-range, range);
                        insAddPos.z = Random.Range(-range, range);
                        //�l�𐶐�or�A�N�e�B�u��
                        ObjectPool.GetComponent<ObjectPool>().SetActive(this.gameObject, this.transform.position + insAddPos);
                    }
                    break;
                case "��": //��
                    for (int i = 0; i < _val; i++)
                    {
                        //�l���A�N�e�B�u��
                        ObjectPool.GetComponent<ObjectPool>().SetDeactive(this.gameObject, null);
                    }
                    break;
            }
        }
        else
        {
            //���Z�q�����߂��ĂȂ�����_��
            return;
        }
    }
    //�G�t�F�N�g�𐶐�
    public void insEff (Vector3 _insPos)
    {
        _insPos = new Vector3
            (
                _insPos.x,
                _insPos.y + 0.5f,
                _insPos.z
            );
        Instantiate(delEffect, _insPos, Quaternion.identity, this.transform);
        Debug.Log("�G�t�F�N�g����");
    }

    /// <summary>
    /// �S�[�����ɐl�����񂷂�悤�ɖڎw���ʒu��n���֐�(1�x�����g��Ȃ�)
    /// </summary>
    public void SetAlignTargetPos()
    {
        int foundCount = 0;
        //�A�N�e�B�u�ȃI�u�W�F�N�g���v�[��������T������
        foreach(Transform t in this.transform)
        {
            if(t.gameObject.activeSelf)
            {
                //�A�N�e�B�u�ȃI�u�W�F�N�g�������甭�������J�E���g����
                foundCount++;

                //�������I�u�W�F�N�g���̈ʒu(���݂̈ʒu)��������
                t.GetComponent<Human>().alignStartPos = t.position;

                //�������I�u�W�F�N�g���̖ړI���W��vector3�^�ϐ��ɖڎw���ׂ����W��������
                t.GetComponent<Human>().alignTargetPos = new Vector3
                    (
                        this.transform.position.x,
                        t.position.y,
                        this.transform.position.z + foundCount * 0.2f
                    );
            }
        }
    }

    /// <summary>
    /// �v�[�����̃I�u�W�F�N�g�𐮗񂷂�֐�
    /// </summary>
    /// <param name="_parcent">�ǂ̂��炢�̊����܂Ői�񂾂�</param>
    public void Align(float _parcent)
    {
        int foundCount = 0;

        //�A�N�e�B�u�I�u�W�F�N�g���v�[���̒�����T��
        foreach (Transform t in this.transform)
        {
            if (t.gameObject.activeSelf)
            {
                foundCount++;
                t.GetComponent<Human>().MoveTargetPos(_parcent);
            }
        }
    }

    public void SetIsKinematic(bool _flag)
    {
        foreach (Transform t in this.transform)
        {
            //�L����ԂȂ�
            if (t.gameObject.activeSelf)
            {
                t.GetComponent<Rigidbody>().isKinematic = _flag;
            }
        }
    }

    //�l�𒆉��Ɍ������ē������֐����Ăяo�����߂̂���
    public void RunStandardMove()
    {
        foreach (Transform t in this.transform)
        {
            //�L����ԂȂ�
            if (t.gameObject.activeSelf)
            {
                t.GetComponent<Human>().StandardMove();
            }
        }
    }

    //��ԑO�ɂ���l�̍��W���擾���邽�߂̊֐�
    public float GetHead()
    {
        float maxZ = 0;  //��ԑO�̍��W������

        //�A�N�e�B�u�ȃI�u�W�F�N�g���v�[��������T������
        foreach (Transform t in this.transform)
        {
            if (t.gameObject.activeSelf)
            {
                if (t.gameObject.transform.position.z > maxZ)
                {
                    maxZ = t.gameObject.transform.position.z;
                }
            }
        }
        return maxZ;
    }
}
