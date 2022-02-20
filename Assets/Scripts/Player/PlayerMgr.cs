using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// �f�[�^�������Ă������
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private GameObject gameMgr;

    [Tooltip("�v���C���[�̍��E�A�O���̈ړ����x")] [SerializeField] private Vector2 speed = new Vector2(4.0f, 0.05f);
    [Tooltip("�v���C���[�̍��E�̈ړ��͈͐���")] private float sideLimit = 1.8f;

    [Tooltip("�S�[����Ɍ㉽��^�b�v�����ɓ����邩")] [SerializeField] private int validMoveNumOneTap = 5;

    [Tooltip("�S�[�����ɒ����Ɋ�鑬�x�Ƃ����ޑ��x")] [SerializeField] private float moveCenterSpeed = 0.05f;

    [Tooltip("�S�[�����̃T���̊p�x(�����o��悤�ɂ���)")] [SerializeField] private Vector3 angleSharkAfterGoal = new Vector3 (0, 90, -18);

    void Start()
    {
        gameMgr = GameObject.Find("GameMgr");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Vector3 GetAngleSharkAfterGoal() { return angleSharkAfterGoal; }
    public Vector2 GetPlayerSpeed() { return speed; }
    public float GetSideLimit() { return sideLimit; }
    public int GetValidMoveNumOneTap() { return validMoveNumOneTap; }
    public float GetMoveCenterSpeed() { return moveCenterSpeed; }
}
