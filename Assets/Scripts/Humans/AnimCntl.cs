using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCntl : MonoBehaviour
{
    private GameObject gameMgr;    //�������Ďg���̂ŃQ�[���}�l�[�W���[��T�����ăA�^�b�`����
    public Animator animator;

    private Vector3 prePos;
    private Vector3 nowPos;

    private void Start()
    {
        gameMgr = GameObject.Find("GameMgr");
        prePos = transform.position;
        nowPos = transform.position;
    }

    void Update()
    {
        nowPos = transform.position;    //���݈ʒu���X�V

        //�O��̈ʒu����i��ł���Α��胂�[�V�����ɂ���
        if (prePos.z < nowPos.z)
        {
            animator.SetBool("Run", true);
        }
        //�����łȂ���Β�~����
        else
        {
            animator.SetBool("Run", false);
        }
        ////�O��̈ʒu���E�ɂ���ΉE���胂�[�V�����ɂ���
        //if (prePos.x + 0.1f < nowPos.x)
        //{
        //    animator.SetBool("Right", true);
        //}
        //else
        //{
        //    animator.SetBool("Right", false);
        //}
        ////�O��̈ʒu��荶�ɂ���΍����胂�[�V�����ɂ���
        //if (prePos.x - 0.1f > nowPos.x)
        //{
        //    animator.SetBool("Left", true);
        //}
        //else
        //{
        //    animator.SetBool("Left", false);
        //}
        //���݂̈ʒu���ߋ��̈ʒu�Ƃ��ċL�^����
        prePos = nowPos;
    }
}
