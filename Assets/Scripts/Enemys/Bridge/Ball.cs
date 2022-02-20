using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool releaseBallFlag;   //���𗎂������Ǘ�����t���O

    private void Update()
    {
        //�{�[����������ĂȂ�������
        releaseBallFlag = GetComponentInParent<BridgeHuman>().GetReleaseBallFlag();
        if(!releaseBallFlag)
        {
            Chase();
        }
    }

    /// <summary>
    /// �Ώۂɍ��킹�ă{�[�����ړ�������
    /// </summary>
    public void Chase()
    {
        this.transform.position = new Vector3
            (
            this.GetComponentInParent<BridgeHuman>().gameObject.transform.position.x,
            this.transform.position.y,
            this.transform.position.z
            );
    }

    public void MoveDropPoint(Vector3 _firDropPosDist)
    {
        this.transform.position += _firDropPosDist;
    }
}
