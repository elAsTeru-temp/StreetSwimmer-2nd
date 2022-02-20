using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Quaternion  fixRot; //�J�����̌Œ�p�x������(fixation...�Œ�)
    private Vector3     fixPos; //�J�����̌Œ�ʒu������
    private Vector3     nowPos; //���݂̃J�����̈ʒu������
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// �J�����̏��
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public enum State
    {
        Normal,
        Clear
    }
    public State state;
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// �J�����̈ʒu�ƌ���
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Tooltip("�v���C���[�̃I�u�W�F�N�g�F��{�A�^�b�`���Ȃ�")] [SerializeField] private GameObject pObj;
    [Tooltip("�ʏ�̃J�����ʒu")] [SerializeField]   private Vector3 cameraPosNormal = new Vector3(0.0f, 7.7f, -2.6f);
    [Tooltip("�ʏ�̃J��������")] [SerializeField]   private Vector3 cameraRotNormal = new Vector3(49.0f, 0.0f, 0.0f);

    [Tooltip("�N���A�̃J�����ʒu")] [SerializeField] private Vector3 cameraPosClear  = new Vector3(0.0f, 1.6f, -1.6f);
    [Tooltip("�N���A�̃J��������")] [SerializeField] private Vector3 cameraRotClear  = new Vector3(31.0f, 0.0f, 0.0f);

    private float leapNow;  //0~1
    [Tooltip("�N���A���ɂǂꂭ�炢�̊����ŃJ�������ړ������邩")] [SerializeField] private float addLeap = 0.1f;
    private Vector3 leapPos;    //���[�v�֐��ł̍��̈ʒu
    private Vector3 leapRot;    //���[�v�֐��ł̍��̌���

    Vector3 newPos; //�ړ���̈ʒu������
    Vector3 newRot; //��]��̌���������

    [Tooltip("�N���A�̃J�����ʒu")] [SerializeField] private float moveXDivision = 40;

    //�J�����ƃv���C���[�̋���
    float distY = 0.0f;
    float distZ = 0.0f;
    float rotX = 0.0f;

    private void Start()
    {
        //�J�����̏�Ԃ�ʏ�ɂ���
        state = State.Normal;
        //�v���C���[�̏����擾
        pObj = GameObject.Find("PlayerObj");
        //�J�����̈ʒu��������
        this.transform.position = cameraPosNormal;
        //�J�����̊p�x��������
        this.transform.rotation = Quaternion.Euler(cameraRotNormal);
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //�J�����̈ړ�
    }

    private void Move()
    {
        //��Ԃ��ʏ�Ȃ�
        if(state == State.Normal)
        {
            distY = cameraPosNormal.y;
            distZ = cameraPosNormal.z;
            rotX = cameraRotNormal.x;
        }
        else if(state == State.Clear && leapNow < 1.0f)     //��Ԃ��N���A�ŁA���[�v��1�ɂȂ��ĂȂ����
        {
            //���[�v�̊�����i�߂�
            leapNow += addLeap;
            //���[�v�ł̌��݂̃v���C���[�ƃJ�����̋������Ƃ�
            leapPos = Vector3.Lerp(cameraPosNormal, cameraPosClear, leapNow);
            leapRot = Vector3.Lerp(cameraRotNormal, cameraRotClear, leapNow);

            distY = leapPos.y;
            distZ = leapPos.z;
            rotX = leapRot.x;
        }

        newPos = new Vector3
            (
                pObj.transform.position.x / moveXDivision,          //���̈ړ��͏���������
                pObj.transform.position.y + distY,                  //���݂̃Q�[���̏�Ԃŕς��
                pObj.transform.position.z + distZ                   //���݂̃Q�[���̏�Ԃŕς��
            );
        newRot = new Vector3
            (
                rotX,
                this.transform.rotation.y,
                this.transform.rotation.z
            );

        //�V�����ʒu��K��
        this.transform.position = newPos;
        //�V����������K��
        this.transform.rotation = Quaternion.Euler(newRot);
    }
}
