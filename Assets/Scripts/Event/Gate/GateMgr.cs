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
        //ƒIƒuƒWƒFƒNƒg‚ğŠi”[‚·‚é‹óŠÔ‚ğì¬
        space = new GameObject("Obj Space");
        //¶¬‚µ‚½‹óŠÔ‚ğq‚ÌˆÊ’u‚ÉˆÚ“®
        space.transform.parent = this.transform;

        if (_stageNumber == 1)
        {
            //‚P‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 4.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 5);
            //‚Q‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(1, 0.6f, 11), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 3);
            //‚R‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 19), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("|", 8);
            //‚S‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(1, 0.6f, 27), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 5);
            //‚T‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(1, 0.6f, 31), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("|", 15);
            //‚U‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(-1, 0.6f, 41), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("|", 10);
            //‚V‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(-1, 0.6f, 45), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 5);
        }
        else if (_stageNumber == 2)
        {
            //‚P‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 4.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 5);
        }
        else if(_stageNumber == 3)
        {
            //‚P‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 4.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 1);
            //‚Q‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 13.0f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 1);
            //‚R‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(1, 0.6f, 37.3f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 6);
        }
        else if (_stageNumber == 4)
        {
            //‚P‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 4.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 1);
            //‚Q‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 20.0f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 5);
            //‚R‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 37.0f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("|", 5);
        }
        else if (_stageNumber == 5)
        {
            //‚P‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 10.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("{", 2);
            //‚Q‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(-1, 0.6f, 20.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("~", 2);
            //‚R‚Â–Ú
            clone = Instantiate(gatePrefab, new Vector3(0, 0.6f, 30.5f), Quaternion.identity, space.transform);
            clone.GetComponent<Fluctuation>().Set("|", 5);
        }
    }
}
