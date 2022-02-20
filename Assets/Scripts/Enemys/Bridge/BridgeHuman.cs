using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeHuman : MonoBehaviour
{
    private bool releaseBallFlag;   //���𗎂������Ǘ�����t���O
    private Vector3 firstPos;
    private float speed;
    private GameObject targetObj;
    private float dropDist;
    private Vector3 firstDropPosDist;

    private void Start()
    {
        firstPos = this.transform.position;
        speed = GetComponentInParent<BridgeMgr>().GetSpeed();
        dropDist = GetComponentInParent<BridgeMgr>().GetDropDist();
        firstDropPosDist = GetComponentInParent<BridgeMgr>().GetFirstDropPosDist();
        targetObj = GetComponentInParent<BridgeMgr>().GetTargetObj();
    }

    private void Update()
    {
        //����̐l���{�[���𗎂Ƃ��ĂȂ������珈������
        if(!releaseBallFlag)
        {
            //�l��ǂ�������悤�Ɉړ�������
            Chase();
            //�����ΏۂƂ�Z�̋��������߂Ă����l�ȉ��ɂȂ����狅�𗎉�������֐����Ă�
            if (this.transform.position.z - targetObj.transform.position.z <= dropDist)
            {
                //�{�[���𗎂Ƃ������Ƃ�`����
                releaseBallFlag = true;
                //���̈ʒu�𗎉��J�n�̈ʒu�Ɉړ�������
                this.GetComponentInChildren<Ball>().MoveDropPoint(firstDropPosDist);
                this.GetComponentInChildren<Rigidbody>().isKinematic = false;       //���𗎉�������
            }
        }
    }

    public bool GetReleaseBallFlag() { return releaseBallFlag; }

    /// <summary>
    /// ��������̐l���ړ�������֐�
    /// </summary>
    public void Chase()
    {
        Vector3 addPosX = new Vector3(speed, 0, 0);  //�ړ����Z�ʂ��x�N�^�[�ɂ���

        //�ړ��ʂ��A_speed��菬�����ꍇ�l��X���W�Ɠ����ɂ���
        float dist = targetObj.transform.position.x - this.transform.position.x;
        if( -speed <= dist && dist <= speed)
        {
            //�l��X���W�Ɠ����ɂ���
            this.transform.position = new Vector3(targetObj.transform.position.x, firstPos.y, firstPos.z);
            return; //�֐����o��
        }

        //�ǂ�������Ώۂ̈ʒu���A���݂̈ʒu���E���Ȃ�
        if (targetObj.transform.position.x > this.transform.position.x)
        {
            this.transform.position += addPosX; //�E�Ɉړ�����
        }
        else
        {
            this.transform.position -= addPosX; //���Ɉړ�����
        }
    }
}