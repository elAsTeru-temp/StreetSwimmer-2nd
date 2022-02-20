using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://qiita.com/tsucchi13/items/ef2cec53cdfb8ed9a855

public class Player : MonoBehaviour
{
    private Vector3 addPos;         //�ړ��ʂ��x�N�^�[�ɂ��邽�߂̕ϐ�
    private Vector3 preMousePos;    //���O�̃}�E�X�ʒu

    private Vector2 speed;  //�v���C���[�̍��E�A�O���̈ړ����x
    private float sideLimit; //���E�̈ړ�����
    private float moveCenterSpeed;

    private int validMoveNumOneTap;    //�P��̃^�b�v�œ������
    private int validMoveNum;

    private Vector3 angleSharkAfterGoal;
    private Vector3 firstAngle;
    private int angleChangeMaxNum = 10;
    private int nowTapNum = 0;

    private void Start()
    {
        speed = GetComponentInParent<PlayerMgr>().GetPlayerSpeed();
        sideLimit = GetComponentInParent<PlayerMgr>().GetSideLimit();
        validMoveNumOneTap = GetComponentInParent<PlayerMgr>().GetValidMoveNumOneTap();
        moveCenterSpeed = GetComponentInParent<PlayerMgr>().GetMoveCenterSpeed();
        angleSharkAfterGoal = GetComponentInParent<PlayerMgr>().GetAngleSharkAfterGoal();
        firstAngle = gameObject.transform.rotation.eulerAngles;
        addPos = new Vector3(0, 0, speed.y);      //�x�N�^�[�ɕϊ�
    }

    public void Move()
    {
        this.transform.position += addPos;  //�O���ړ�
        /// ----------------------------------------------------
        /// �v�Z����:�}�E�X�̈ړ��ʂ���v���C���[�����E�Ɉړ�����
        /// ----------------------------------------------------
        if (Input.GetMouseButtonDown(0))
        {
            preMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            //���O�̃}�E�X�̈ʒu�ƃC���v�b�g���Ĉړ������ʂ𑪂�
            Vector3 mousePosDiff = Input.mousePosition - preMousePos;
            //���݂̃}�E�X�̈ʒu�����O�̃|�W�V�����Ƃ��ċL�^����
            preMousePos = Input.mousePosition;
            //���݂̃v���C���[�̈ʒu�Ɉړ��ʂ𑫂����߂̕ϐ����쐬
            Vector3 newPos = this.transform.position + new Vector3(mousePosDiff.x / Screen.width, 0, 0) * speed.x;

            //�X�e�[�W�̒[�ɂ�肷���Ȃ��悤�ɂ���
            if (newPos.x < -sideLimit)
            {
                newPos.x = -sideLimit;
            }
            if (newPos.x > sideLimit)
            {
                newPos.x = sideLimit;
            }

            //�ړ���̈ʒu�Ɉړ�������
            this.transform.position = newPos;
        }
    }

    /// <summary>
    /// �v���C���[�𒆉��ֈړ�������֐�
    /// </summary>
    /// <returns>�ړ�������:true�A����:false</returns>
    /// <detail>true���A���Ă���܂ő��s���邱�ƂŁA�����Ɉړ��ł���</detail>
    public bool MoveCenter()
    {
        //�����ɂ�����true��Ԃ��ďI��
        if (this.transform.position.x == 0)
        {
            return true;
        }
        //���̈ړ��ʂŒ������z���Ă��܂������Ȃ�A�����̒l��������
        else if (-0.05 <= this.transform.position.x && this.transform.position.x <= 0.05)
        {
            this.transform.position = new Vector3(0, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            //���S��荶���ɂ���Ȃ�A�E�Ɉړ�(else:�t)
            if (this.transform.position.x < 0)
            {
                this.transform.position += new Vector3(moveCenterSpeed, 0, 0);
            }
            else
            {
                this.transform.position += new Vector3(-moveCenterSpeed, 0, 0);
            }
        }
        //�܂������ւ̈ړ����I�����Ă��Ȃ��̂ŁAfalse��Ԃ��ďI��
        return false;
    }
    /// <summary>
    /// ���񊮗��ʒu(�v���C���[�̑��삪�\�ɂȂ�ʒu)�܂ł̈ړ�
    /// </summary>
    public void MoveToAlignEndPos()
    {
        this.transform.position += addPos;  //�O���ړ�
    }
    //�^�b�v�Ői�ޑ���
    public void MoveAfterGoal()
    {
        if (Input.GetMouseButtonDown(0))
        {
            validMoveNum += validMoveNumOneTap;
            OutSharkHead();
        }
        if(validMoveNum > 0)
        {
            validMoveNum--;
            this.transform.position += new Vector3(0, 0, 0.05f) ;  //�O���ړ�
        }
    }

    public void OutSharkHead()
    {
        if (nowTapNum < angleChangeMaxNum)
        {
            nowTapNum++;
            this.transform.rotation = Quaternion.Euler(Vector3.Lerp(firstAngle, angleSharkAfterGoal, (float)nowTapNum / angleChangeMaxNum));
        }
    }
}
