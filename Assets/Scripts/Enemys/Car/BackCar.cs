using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCar : MonoBehaviour
{
    private GameObject mgr; //���̃I�u�W�F�N�g�̃}�l�[�W���[
    private float speed;    //���x
    private int leftKillNum;  //�c��̏�����l��
    private GameObject textMesh;    //������l����\�����邽�߂̃e�L�X�g���b�V��
    private GameObject eff; //�����K�w�ɂ���G�t�F�N�g���i�[����


    // Start is called before the first frame update
    void Start()
    {
        //�}�l�[�W���[��T��
        mgr = GameObject.Find("BackCarMgr");
        //�G�t�F�N�g���擾(�����K�w)
        eff = transform.parent.Find("Explosion").gameObject;
        //�e�L�X�g���b�V����T��
        textMesh = transform.GetChild(0).gameObject;
        //�������擾
        speed = mgr.GetComponent<BackCarMgr>().GetSpeed();
        //�����鐔���擾
        leftKillNum = mgr.GetComponent<BackCarMgr>().GetKillNum();
        //�e�L�X�g���b�V�����X�V
        UpdateTextMesh();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.position += new Vector3(0, 0, speed);
    }
    private void OnTriggerStay(Collider other)
    {
        //���������I�u�W�F�N�g���l���A������l���̎c�肪0�o�Ȃ����
        if (other.tag == "HumanCollider" && leftKillNum > 0)
        {
            //�c��̏�����l�������炷
            leftKillNum--;
            //�e�L�X�g���b�V�����X�V
            UpdateTextMesh();
            //�l���A�N�e�B�u�ɂ���
            other.gameObject.transform.parent.parent.gameObject.SetActive(false);
        }
        //����������l��0�ɂȂ��Ă�����
        if (leftKillNum <= 0)
        {
            mgr.GetComponent<BackCarMgr>().DestroyCar(this.gameObject, eff);
        }
    }
    private void UpdateTextMesh()
    {
        textMesh.GetComponent<TextMesh>().text = (-leftKillNum).ToString();
    }
}
