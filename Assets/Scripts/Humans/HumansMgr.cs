using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumansMgr : MonoBehaviour
{
    private GameObject gMgr;       //ゲームマネージャー
    private Vector3 firstHumanPos;
    /// +++++++++++++++++++++++++++++++++++++
    /// �v�[��
    /// +++++++++++++++++++++++++++++++++++++
    [Tooltip("�v���n�u�̐l�̃I�u�W�F�N�g��A�^�b�`")] [SerializeField] private GameObject poolingHumanObj;
    private int activeNum;
    private float insRange = 0.4f;
    /// +++++++++++++++++++++++++++++++++++++
    /// �V�@�v�[��
    /// +++++++++++++++++++++++++++++++++++++
    //�l
    [Tooltip("�I�u�W�F�N�g�v�[���F��{�A�^�b�`���Ȃ��Ă���")] [SerializeField] private GameObject ObjectPool;
    [Tooltip("�ŏ��ɍ��l�̃I�u�W�F�N�g�v�[���̑傫��")] [SerializeField] private int humanPoolSize = 200;
    //�G�t�F�N�g
    [Tooltip("�ŏ��ɍ��G�t�F�N�g�̃I�u�W�F�N�g�v�[���̑傫��")] [SerializeField] private int effPoolSize = 10;
    private GameObject effPoolObj;



    /// +++++++++++++++++++++++++++++++++++++
    /// �ړ��֘A
    /// +++++++++++++++++++++++++++++++++++++
    [Tooltip("�l�ƃT���̋���")] [SerializeField] private float dist = 2;
    private GameObject playerObj;
    [Tooltip("�l�̈ړ����x")] [SerializeField] private float speed = 0.5f;
    [Tooltip("���񎞂̈ړ��̕�ԉ�")] [SerializeField] private int reapNumMax = 20;
    //// ++++++++++++++++++++++++++++++++++++
    [Tooltip("�l��������Ƃ��̃G�t�F�N�g��A�^�b�`")] [SerializeField] private GameObject delEffect;
    //// ++++++++++++++++++++++++++++++++++++
    private bool setAlignTarPosFlag = false;
    private int alignRunNum;

    [Header("UI")]
    [SerializeField] private TextMesh humanNumUI;

    private GameObject gm;
    private bool only = false;


    void Start()
    {
        ObjectPool = GameObject.Find("ObjectPool");
        gMgr = GameObject.Find("GameMgr");
        //// �l�̃v�[���f�[�^
        //���u�����Ă���I�u�W�F�N�g�̍��W��������W�Ƃ��ċL��
        firstHumanPos = GetComponentInChildren<Human>().gameObject.transform.position;
        //�������W�Ƀv�[����ړ�������
        GetComponentInChildren<Pool>().gameObject.transform.position = firstHumanPos;
        //���u�����Ă���I�u�W�F�N�g���A�N�e�B�u��
        GetComponentInChildren<Human>().gameObject.SetActive(false);
        //�v�[����쐬
        ObjectPool.GetComponent<ObjectPool>().InsPool(poolingHumanObj, humanPoolSize, GetComponentInChildren<Pool>().gameObject);
        //�v�[������1�l�ڂ�L���ɂ���
        ObjectPool.GetComponent<ObjectPool>().SetActive(GetComponentInChildren<Pool>().gameObject, firstHumanPos);
        //�v���C���[�̃f�[�^��擾
        playerObj = GameObject.Find("PlayerObj");
        ////�@�G�t�F�N�g�̃v�[���f�[�^
        effPoolObj = this.gameObject.transform.Find("HumanEffectPool").gameObject;
        //�v�[���쐬
        ObjectPool.GetComponent<ObjectPool>().InsPool(delEffect, effPoolSize, effPoolObj);

        gm = GameObject.Find("GameMgr");
    }

    // Update is called once per frame
    void Update()
    {
        if (!humanNumUI.gameObject.activeSelf && !only)
        {
            if (gm.GetComponent<GameManager>().gamestate == GameStates.play)
            {
                only = true;
                humanNumUI.gameObject.SetActive(true);
            }
        }
        else if(humanNumUI.gameObject.activeSelf)
        {
            //人数を表示しているUIを移動させる
            GetComponentInChildren<PrintActiveNum>().MoveHead();
            //子オブジェクトのスクリプトから表示されている人数を更新する
            GetComponentInChildren<PrintActiveNum>().UpdatePrintActiveNum(activeNum);
        }
        //現在の人数を取得する
        activeNum = ObjectPool.GetComponent<ObjectPool>().CountPoolingObj(GetComponentInChildren<Pool>().gameObject);
    }

    public GameObject GetHumanObj() { return poolingHumanObj; }
    public GameObject GetDelEffect() { return delEffect; }
    public float GetRange() { return insRange; }
    public int GetActiveNum() { return activeNum; }
    public float GetDistFromPlayer() {return dist; }
    public float GetSpeed() { return speed; }

    /// <summary>
    /// ���񂳂���Ƃ��Ɏ��s����֐�
    /// </summary>
    /// <returns>true:���񊮗� false:���񖢊�</returns>
    public bool Align()
    {
        //������s�񐔂���Ԃ�����񐔂�z�����琮�񂪏I��������Ƃ�`���I������
        if(alignRunNum >= reapNumMax)
        {
            return true;
        }

        //���s���ꂽ�񐔂�J�E���g
        alignRunNum++;

        // ����̖ړI���W���n����ĂȂ�������
        if(!setAlignTarPosFlag)
        {
            //�ړI�̍��W����ߐl���ꂼ��ɒl��n��
            GetComponentInChildren<Pool>().SetAlignTargetPos();
        }

        //��Ԃ̓������ړ�����s����
        GetComponentInChildren<Pool>().Align((float)alignRunNum / reapNumMax);

        return false;
    }
}
