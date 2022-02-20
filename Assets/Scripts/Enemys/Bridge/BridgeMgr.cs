using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMgr : MonoBehaviour
{
    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // �����֘A
    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Tooltip("������̐l���ǂ�������ΏہF��{�A�^�b�`���Ȃ�")] [SerializeField] private GameObject targetObj;
    [Tooltip("�������̍��������K�������")] [SerializeField] private Vector3 InstPos = new Vector3(0,0,0);
    [Tooltip("�v���C���[�̃I�u�W�F�N�g�F��{�A�^�b�`���Ȃ�")] [SerializeField] private GameObject pObj;
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //�l�֘A
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Tooltip("�������̐l�̈ړ����x")] [SerializeField] private float moveSpeed = 0.1f;
    [Tooltip("�ǂ̂��炢�ΏۂƋ߂Â����狅�𗎂���")] [SerializeField] private float dropDist = 2.0f;
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //���֘A
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Tooltip("�e�������n�߂�l����̋���")] [SerializeField] private Vector3 firstDropPosDist = new Vector3(0, 0, -0.8f);


    //新規生成方法
    [Tooltip("歩道橋のプレハブをアタッチ")] [SerializeField] private GameObject bridgeObj;
    private GameObject clone;
    private GameObject space;

    void Start()
    {
        if (!targetObj) { targetObj = GameObject.Find("HumanPool"); }
        if (!pObj) { pObj = GameObject.Find("PlayerObj"); }
    }
    public float GetSpeed() { return moveSpeed; }  //�������鋴�̃I�u�W�F�N�g��Ԃ�
    public float GetDropDist() { return dropDist; } //�{�[��������[�X����Ƃ��̐l�Ƌ���̐l�̋���
    public Vector3 GetFirstDropPosDist() { return firstDropPosDist; }   //�|�[���𗎂Ƃ��Ƃ��̐l����̋���
    public GameObject GetTargetObj() { return targetObj; }


    public void OrderInst(int _stageNum)
    {
        //オブジェクトを格納する空間を作成
        space = new GameObject("Obj Space");
        //生成した空間を子の位置に移動
        space.transform.parent = this.transform;
        if (_stageNum == 4)
        {
            //１つ目
            clone = Instantiate(bridgeObj, new Vector3(0, 0, 28.5f), Quaternion.identity, space.transform);
        }
        if (_stageNum == 5)
        {
            //１つ目
            clone = Instantiate(bridgeObj, new Vector3(0, 0, 21.5f), Quaternion.identity, space.transform);
        }
    }
}
