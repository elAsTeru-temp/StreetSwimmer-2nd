using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectpoolComponent : MonoBehaviour
{
    [Header("Objectpool Settings")]
    [Tooltip("Attach Poolingobject")] [SerializeField] private GameObject poolingObject;
    [Tooltip("Set Size Of Objectpool")] [SerializeField] private int size;
    // +++ Hide Variables +++
    private bool debug = false;
    private GameObject poolSpace;   //プールの空間

    void Start()
    {
        if (debug) { Debug.Log("オブジェクトプールのデバッグが有効です。終わったらfalseに"); }

        InstanceObjectPool();
    }

    private void Update()   //updateは確認用に使う
    {
        if (debug)
        {
            //生成orアクティブ化
            if (Input.GetKeyDown(KeyCode.I))
            {
                SetActive(Vector3.zero);
            }
            //生成orアクティブ化
            if (Input.GetKeyDown(KeyCode.C))
            {
                CountPoolingObjectNum();
            }
            //非アクティブ化
            if (Input.GetKeyDown(KeyCode.D))
            {
                SetDeactive(null);
            }
            //指定して非アクティブ化
            if (Input.GetKeyDown(KeyCode.A))
            {
                GameObject g = GameObject.Find("Human(Clone)");
                SetDeactive(g);
            }
        }
    }


    // プールの空間を生成する関数
    private void InstanceSpaceOfPool()
    {
        //プール空間を作成(名前はプーリングされるオブジェクトの名前にPoolをつけたものになる)
        poolSpace = new GameObject(poolingObject.name + "Pool");
        //作成したプール空間の場所をこのスクリプトがアタッチされたオブジェクトの子の位置に移動する
        poolSpace.transform.parent = this.transform;
    }


    // プールを生成する関数
    private void InstanceObjectPool()
    {
        //オブジェクトプールの空間を子として作成
        InstanceSpaceOfPool();

        //設定されたサイズのオブジェクトプールを作成する
        for (int i = 0; i < size; i++)
        {
            Instantiate(poolingObject, Vector3.zero, poolingObject.transform.rotation, poolSpace.transform);
        }

        //何を何個生成したかデバッグで伝える
        Debug.Log(poolingObject.name + "で" + CountPoolingObjectNum() + "個のプールを作成");

        //アクティブなオブジェクトを探索して無効化する
        //foreach...要素の数だけループが行われる
        foreach (Transform t in poolSpace.transform)
        {
            if (t.gameObject.activeSelf)
            {
                t.gameObject.SetActive(false);
            }
        }
    }


    // プール内のオブジェクトの数を数えて返す関数
    public int CountPoolingObjectNum()
    {
        int count = 0;
        //プール内からアクティブなオブジェクトを探索する
        foreach (Transform t in poolSpace.transform)
        {
            if (t.gameObject.activeSelf)
            {
                count++;
            }
        }
        //何が何個あるかデバッグで伝える
        Debug.Log(poolingObject.name + "が現在" + count + "個あります。");
        return count;
    }


    /// <summary>
    /// プーリングされているオブジェクトを1つ有効化する
    /// </summary>
    /// <param name="_pos">生成位置</param>
    public GameObject SetActive(Vector3 _pos)
    {
        //非アクティブオブジェクトをプールの中から探索
        foreach (Transform t in poolSpace.transform)
        {
            if (!t.gameObject.activeSelf)
            {
                //オブジェクトに位置と向きをセット
                t.SetPositionAndRotation(_pos, poolingObject.transform.rotation);
                //アクティブ化
                t.gameObject.SetActive(true);
                //アクティブにできたので終了する
                return t.gameObject;
            }
        }
        //非アクティブなオブジェクトがなかったら新規に生成
        return Instantiate(poolingObject, _pos, poolingObject.transform.rotation, poolSpace.transform);
    }

    /// <summary>
    /// プール内または指定オブジェクトを非アクティブにする関数
    /// </summary>
    /// <param name="_appoint">指定して非アクティブ化：プール内どれでもよければ null</param>
    public void SetDeactive(GameObject _appoint)
    {
        //指定されていたら指定されているオブジェクトを非アクティブ化
        if (_appoint)
        {
            _appoint.SetActive(false);
            return;
        }
        else
        {
            //アクティブなオブジェクトをプールの中から探索
            foreach (Transform t in poolSpace.transform)
            {
                if (t.gameObject.activeSelf)
                {
                    //非アクティブ化
                    t.gameObject.SetActive(false);
                    //非アクティブにしたら終了
                    return;
                }
            }
        }
    }
}
