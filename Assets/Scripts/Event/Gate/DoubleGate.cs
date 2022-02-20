using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGate : MonoBehaviour
{
    bool run = false;
    private void OnTriggerStay(Collider other)
    {
        if(run)
        {
            return;
        }
        else
        {
            foreach(Transform t in this.transform)
            {
                //�ǂ������̃Q�[�g�����s����Ă�����
                if(t.GetComponent<Fluctuation>().ranFunc == true)
                {
                    //�����̃Q�[�g���g�p�ł��Ȃ�����ׂɃt���O�𗧂Ă�
                    run = true;
                }
            }
        }
        if(run) //�t���O���������炻�̂܂�1�񂾂����s�ł���悤��else����Ȃ��ĕʂ̏��������Ă���
        {
            foreach (Transform t in this.transform)
            {
                //�ǂ������̃Q�[�g�����s����Ă�����
                if (t.GetComponent<Fluctuation>().ranFunc == true)
                {
                    //�Q�[�g�̑��������s����Ȃ��悤�Ɏq�̎��s�ς݃t���O�𗧂Ă�
                    GetComponentInChildren<Fluctuation>().ranFunc = true;
                }
            }
        }
    }
    
    public void Set(string _opeStr1, int _value1, string _opeStr2, int _value2)
    {
        GameObject child;
        //1�ڂ̃Q�[�g
        child = transform.GetChild(0).gameObject;
        child.GetComponent<Fluctuation>().Set(_opeStr1, _value1);
        //2�ڂ̃Q�[�g
        child = transform.GetChild(1).gameObject;
        child.GetComponent<Fluctuation>().Set(_opeStr2, _value2);
    }
}
