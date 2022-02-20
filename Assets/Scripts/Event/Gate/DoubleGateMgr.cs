using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGateMgr : MonoBehaviour
{
    [SerializeField] GameObject doubleGatePrefab;
    private GameObject clone;
    private GameObject space;

    public void OrderInst(int _stageNumber)
    {
        //ƒIƒuƒWƒFƒNƒg‚ğŠi”[‚·‚é‹óŠÔ‚ğì¬
        space = new GameObject("Obj Space");
        //¶¬‚µ‚½‹óŠÔ‚ğq‚ÌˆÊ’u‚ÉˆÚ“®
        space.transform.parent = this.transform;

        //ƒXƒe[ƒW‚P‚Å‚Íg‚í‚È‚¢
        if (_stageNumber == 2)
        {
            //‚P‚Â–Ú
            clone = Instantiate(doubleGatePrefab, new Vector3(0, 0.5f, 18.5f), Quaternion.identity, space.transform);
            clone.GetComponent<DoubleGate>().Set("|", 10, "{", 8);
            //‚Q‚Â–Ú
            clone = Instantiate(doubleGatePrefab, new Vector3(0, 0.5f, 37.0f), Quaternion.identity, space.transform);
            clone.GetComponent<DoubleGate>().Set("{", 3, "~", 2);
        }
        else if(_stageNumber == 3)
        {
            //‚P‚Â–Ú
            clone = Instantiate(doubleGatePrefab, new Vector3(0, 0.5f, 16.0f), Quaternion.identity, space.transform);
            clone.GetComponent<DoubleGate>().Set("~", 3, "{", 7);
            //‚Q‚Â–Ú
            clone = Instantiate(doubleGatePrefab, new Vector3(0, 0.5f, 27.0f), Quaternion.identity, space.transform);
            clone.GetComponent<DoubleGate>().Set("{", 3, "|", 5);
        }
        else if (_stageNumber == 4)
        {
            //‚P‚Â–Ú
            clone = Instantiate(doubleGatePrefab, new Vector3(0, 0.5f, 13.0f), Quaternion.identity, space.transform);
            clone.GetComponent<DoubleGate>().Set("~", 2, "|", 5);
        }
        else if (_stageNumber == 5)
        {
            //‚P‚Â–Ú
            clone = Instantiate(doubleGatePrefab, new Vector3(0, 0.5f, 13.0f), Quaternion.identity, space.transform);
            clone.GetComponent<DoubleGate>().Set("{", 3, "~", 3);
            //‚P‚Â–Ú
            clone = Instantiate(doubleGatePrefab, new Vector3(0, 0.5f, 37.0f), Quaternion.identity, space.transform);
            clone.GetComponent<DoubleGate>().Set("|", 10, "{", 3);
        }
    }
}
