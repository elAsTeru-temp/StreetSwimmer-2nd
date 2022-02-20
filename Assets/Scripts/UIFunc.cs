using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunc : MonoBehaviour
{
    [SerializeField] private GameObject gameMgr;    //�Q�[���}�l�[�W���[���A�^�b�`
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //�Q�[�����n�܂�O�̎w��UI�𓮂����̂Ɏg�p����
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private GameObject fingerImg;
    private Vector3 fingerFirstPos;          //�ŏ��̈ʒu
    private float rangeFinger;               //���E�̐U�ꕝ
    private float rangeFingerSpeed;          //���E�̐U��̊��荇��
    private float angleValue;                //�p�x
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //�N���A��̎w��UI���^�b�v������̂Ɏg�p����
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private GameObject tapImg;
    private float expandMax;    //�g��ő�{��
    private float shrinkMax;    //�k���ő�{��
    private float expandLeapNow;    //���݂̊g��{���̊���(0~1)
    private float tapSpeed; //(0~1)
    private bool leapDir;

    // Start is called before the first frame update
    void Start()
    {
        fingerImg = gameMgr.GetComponent<GameManager>().fingerImg;          //�w�摜�̃I�u�W�F�N�g���擾
        fingerFirstPos = fingerImg.transform.position;                      //�w�̍��W���擾
        rangeFinger = gameMgr.GetComponent<GameManager>().rangeFinger;      //�w�̉摜�̐U�ꕝ
        rangeFingerSpeed = gameMgr.GetComponent<GameManager>().rangeFingerSpeed;

        tapImg = gameMgr.GetComponent<GameManager>().tapImg;
        expandMax = gameMgr.GetComponent<GameManager>().tapImgExpandMax;
        shrinkMax = gameMgr.GetComponent<GameManager>().tapImgShrinkMax;
        expandLeapNow = 0.5f;   //���Ԃ̃T�C�Y
        tapSpeed = gameMgr.GetComponent<GameManager>().tapSpeed;
    }   

    /// <summary>
    /// �~�^����x�ړ��̂ݗ��p���Ďw�����E�ɓ�����
    /// </summary>
    public void MoveFingerImg()
    {
        angleValue += rangeFingerSpeed;                   //�p�x�����Z����
        if(angleValue > 359) { angleValue = 0; }          //360�𒴂�����0�ɂ���
        float rad = angleValue * 3.14f / 180.0f;          //�x���@���ʓx�@�ɕϊ�
        float addX = Mathf.Cos(rad) * rangeFinger;        //�O�p�֐��ɂ��A�~����̍��W���擾
        //�摜�̈ʒu���ړ�������
        fingerImg.transform.position = new Vector3(fingerFirstPos.x + addX, fingerFirstPos.y, fingerFirstPos.z);
    }
    public void TapFingerImg()
    {
        if (leapDir)
        {
            expandLeapNow += tapSpeed;
            if(expandLeapNow > 1)
            {
                leapDir = !leapDir;
                expandLeapNow = 1;
            }
        }
        else
        {
            expandLeapNow -= tapSpeed;
            if (expandLeapNow < 0)
            {
                leapDir = !leapDir;
                expandLeapNow = 0;
            }
        }

        Vector3 newScale = Vector3.Lerp
             (
                new Vector3(expandMax, expandMax, 1),
                new Vector3(shrinkMax, shrinkMax, 1),
                expandLeapNow
            );

        this.transform.localScale = newScale;
    }
}