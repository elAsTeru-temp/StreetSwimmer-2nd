using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMgr : MonoBehaviour
{
    [SerializeField] GameObject gatePrefab;
    private GameObject clone;
    private GameObject space;

    public void OrderInst(int _stageNumber)
    {
        //�I�u�W�F�N�g���i�[�����Ԃ��쐬
        space = new GameObject("Obj Space");
        //����������Ԃ��q�̈ʒu�Ɉړ�
        space.transform.parent = this.transform;

        if (_stageNumber == 1)
        {
            //�P��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 4.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 5);
            //�Q��
            clone = Instantiate(gatePrefab, new Vector3(1, 0.6f, 11), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 3);
            //�R��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 19), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�|", 8);
            //�S��
            clone = Instantiate(gatePrefab, new Vector3(1, 0.6f, 27), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 5);
            //�T��
            clone = Instantiate(gatePrefab, new Vector3(1, 0.6f, 31), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�|", 15);
            //�U��
            clone = Instantiate(gatePrefab, new Vector3(-1, 0.6f, 41), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�|", 10);
            //�V��
            clone = Instantiate(gatePrefab, new Vector3(-1, 0.6f, 45), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 5);
        }
        else if (_stageNumber == 2)
        {
            //�P��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 4.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 5);
        }
        else if(_stageNumber == 3)
        {
            //�P��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 4.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 1);
            //�Q��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 13.0f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 1);
            //�R��
            clone = Instantiate(gatePrefab, new Vector3(1, 0.6f, 37.3f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 6);
        }
        else if (_stageNumber == 4)
        {
            //�P��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 4.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 1);
            //�Q��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 20.0f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 5);
            //�R��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 37.0f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�|", 5);
        }
        else if (_stageNumber == 5)
        {
            //�P��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 10.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�{", 2);
            //�Q��
            clone = Instantiate(gatePrefab, new Vector3(-1, 0.6f, 20.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�~", 2);
            //�R��
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 30.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("�|", 5);
        }
    }
}
