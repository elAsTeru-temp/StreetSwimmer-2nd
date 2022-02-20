using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintActiveNum : MonoBehaviour
{
    private GameObject targetObj;
    private GameObject poolObj;
    private bool debug = false;
    private float HeadPosZ;     //�擪�̐l�̍��W������
    private void Start()
    {
        if (debug) { Debug.LogWarning("�l��UI�̃f�o�b�O��on�ł�"); }
        targetObj = GameObject.Find("HumanPool");
        poolObj = GameObject.Find("HumanPool");
    }

    //public void MovePrintActiveNum()
    //{
    //    //�ړ�
    //    this.transform.position = new Vector3
    //    (
    //        targetObj.transform.position.x,
    //        0.9f,
    //        targetObj.transform.position.z + 0.5f
    //    );
    //}
    public void UpdatePrintActiveNum(int _nowNum)
    {
        //���݂̐l�����e�L�X�g�ɕ\������
        this.GetComponent<TextMesh>().text = (_nowNum).ToString();
    }

    //�擪�Ɉړ�������֐�
    public void MoveHead()
    {
        float maxZ = 0;
        maxZ = poolObj.GetComponent<Pool>().GetHead();  // �擪��z���W���擾

        //�ړ�
        this.transform.position = new Vector3(targetObj.transform.position.x, 0.9f, maxZ + 0.5f);
    }
}