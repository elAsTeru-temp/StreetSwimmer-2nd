using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// データも持ってくるもの
    /// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private GameObject gameMgr;

    [Tooltip("プレイヤーの左右、前方の移動速度")] [SerializeField] private Vector2 speed = new Vector2(4.0f, 0.05f);
    [Tooltip("プレイヤーの左右の移動範囲制限")] private float sideLimit = 1.8f;

    [Tooltip("ゴール後に後何回タップせずに動けるか")] [SerializeField] private int validMoveNumOneTap = 5;

    [Tooltip("ゴール時に中央に寄る速度とすすむ速度")] [SerializeField] private float moveCenterSpeed = 0.05f;

    [Tooltip("ゴール自のサメの角度(頭が出るようにする)")] [SerializeField] private Vector3 angleSharkAfterGoal = new Vector3 (0, 90, -18);

    void Start()
    {
        gameMgr = GameObject.Find("GameMgr");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Vector3 GetAngleSharkAfterGoal() { return angleSharkAfterGoal; }
    public Vector2 GetPlayerSpeed() { return speed; }
    public float GetSideLimit() { return sideLimit; }
    public int GetValidMoveNumOneTap() { return validMoveNumOneTap; }
    public float GetMoveCenterSpeed() { return moveCenterSpeed; }
}
