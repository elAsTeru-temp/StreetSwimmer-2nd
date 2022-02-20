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
                //どっちかのゲートが実行されていたら
                if(t.GetComponent<Fluctuation>().ranFunc == true)
                {
                    //両方のゲートを使用できなくする為にフラグを立てる
                    run = true;
                }
            }
        }
        if(run) //フラグがたったらそのまま1回だけ実行できるようにelseじゃなくて別の処理をしている
        {
            foreach (Transform t in this.transform)
            {
                //どっちかのゲートが実行されていたら
                if (t.GetComponent<Fluctuation>().ranFunc == true)
                {
                    //ゲートの増減が実行されないように子の実行済みフラグを立てる
                    GetComponentInChildren<Fluctuation>().ranFunc = true;
                }
            }
        }
    }
    
    public void Set(string _opeStr1, int _value1, string _opeStr2, int _value2)
    {
        GameObject child;
        //1つ目のゲート
        child = transform.GetChild(0).gameObject;
        child.GetComponent<Fluctuation>().Set(_opeStr1, _value1);
        //2つ目のゲート
        child = transform.GetChild(1).gameObject;
        child.GetComponent<Fluctuation>().Set(_opeStr2, _value2);
    }
}
