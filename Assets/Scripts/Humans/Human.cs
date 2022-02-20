using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Vector3 alignStartPos;          //���񂪊J�n���ꂽ�ʒu
    public Vector3 alignTargetPos;         //���񎞂ɖڎw���ʒu������
    private GameObject gMgr;       //�Q�[���}�l�[�W���[
    private Rigidbody rigid;
    private bool hit;

    void Start()
    {
        gMgr = GameObject.Find("GameMgr");
        rigid = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// �ړI�̍��W�Ɉړ����邽�߂̊֐�
    /// </summary>
    /// <param name="_par">���ǂ̂��炢�ړI�n�܂ł����񂾂��̊��荇��</param>
    public void MoveTargetPos(float _par)
    {
        //��Ԉړ�  //�ړ��J�n�ʒu�@�ړ��I���ʒu�@�ǂ̂��炢�܂Ői�񂾂�
        this.transform.position = Vector3.Lerp(alignStartPos, alignTargetPos, _par);
    }

    public void StandardMove()
    {
        //�͂��[���ɂ��ĊO�ɔ�΂Ȃ��悤�ɂ���
        this.rigid.velocity = Vector3.zero;
        //���S�ɂ�点��
        this.transform.position = Vector3.MoveTowards(transform.position, transform.parent.transform.position, 0.01f);
    }
}