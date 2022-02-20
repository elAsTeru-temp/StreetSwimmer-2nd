using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStates //ゲームの状態の列挙型
{
    befor,
    play,
    over,
    clear
}

public class GameManager : MonoBehaviour
{
    /// ----------------------------------------------------
    /// 全体関連
    /// ----------------------------------------------------
    [SerializeField]private bool debug = false;
    [Header("Game Settings")]
    [Tooltip("FPSの値を入れる")] [SerializeField] private int FPS = 30;
    public static int stageNumber;                   //何ステージ目かを計測する(引き継いでいく)クリアの時に加算していく
    [Tooltip("ステージの番号を入れる、デバッグ時のみ有効")] [SerializeField] private int specifyStageNumber;

    [HideInInspector] public GameStates gamestate;           //現在のゲームの状態
    private bool gamePlayStartFlag = false;               //ゲーム開始時に1度だけ処理
    private bool gameOverStartFlag = false;               //ゲームオーバー時に一度だけ処理をするために使用
    private bool gameClearStartFlag = false;              //ゲームクリア時に一度だけ処理をするために使用
    private bool resultFlag = false;                    //クリア時にリザルトを表示していいか

    private GameObject alignLineMgr = null;    //整列の開始と終了が入ったオブジェクト

    /// ----------------------------------------------------
    /// プレイヤー関連
    /// ----------------------------------------------------
    [Tooltip("プレイヤーのスクリプトを持ったオブジェクトをアタッチ")] public GameObject playerObj;
    [Tooltip("プレイヤーの前方の移動速度")] public float playerFrontSpeed = 0.05f;
    [Tooltip("プレイヤーの左右の移動速度")] public float playerSlideSpeed = 4.0f;
    [Tooltip("プレイヤーの左側の移動範囲制限")] public float playerLeftSideLimit = -1.8f;
    [Tooltip("プレイヤーの右側の移動範囲制限")] public float playerRightSideLimit = 1.8f;
    /// ----------------------------------------------------
    /// UI関連
    /// ----------------------------------------------------
    ////UIの状態関連
    [Tooltip("ゲーム開始前のUIまとめオブジェクトをアタッチ")] [SerializeField] private GameObject beforeUI;
    [Tooltip("クリア、オーバー、途中停止の時に割り込みで入るUIまとめオブジェクトをアタッチ")] [SerializeField] private GameObject interruptPanel;
    [Tooltip("プレイ中のUIまとめオブジェクトをアタッチ")] [SerializeField] private GameObject playUI;
    [Tooltip("クリア時のタップのUIまとめオブジェクトをアタッチ")] [SerializeField] private GameObject tapUI;
    [Tooltip("オーバーUIまとめオブジェクトをアタッチ")] [SerializeField] private GameObject overUI;
    [Tooltip("クリアUIまとめオブジェクトをアタッチ")] [SerializeField] private GameObject clearUI;
    ////開始前の操作を伝えるための指のUI関連
    [Tooltip("操作を伝える文字")] [SerializeField] public GameObject explanationUI;
    [Tooltip("ゲーム開始前に写す指の画像")] [SerializeField] public GameObject fingerImg;
    [Tooltip("左右の振れ幅の値")] [SerializeField] public float rangeFinger = 0.5f;
    [Tooltip("左右の振れ速度(円運動を利用してるので、360を割れる値が良い)")] [SerializeField] public float rangeFingerSpeed = 3;
    ////クリアのタップの操作を伝えるための指のUI関連
    [Tooltip("ゲームクリアに写すタップの画像")] [SerializeField] public GameObject tapImg;
    [Tooltip("タップ操作の拡大の最大倍率")] [SerializeField] public float tapImgExpandMax;
    [Tooltip("タップ操作の縮小の最大倍率")] [SerializeField] public float tapImgShrinkMax;
    [Tooltip("タップ操作の拡縮スピード(0~1)")] [SerializeField] public float tapSpeed;
    ////ゴールまでの距離関連
    [Tooltip("ステージ名を入れるテキストオブジェクトをアタッチ")] public Text StageName;
    private string street = "Street";       //ゴールまでの距離ゲージの上にステージ番号みたいに、Street10のように表示のために使う
    /// ----------------------------------------------------
    /// 各マネージャーとカメラ
    /// ----------------------------------------------------
    private GameObject humansMgr;
    private GameObject playerMgr;
    private GameObject frontCarMgr;
    private GameObject backCarMgr;
    private GameObject bridgeMgr;
    private GameObject alineMgr;
    private GameObject mainCam;
    private GameObject gateMgr;
    private GameObject doubleGateMgr;


    void Start()
    {
        if (debug) { Debug.LogWarning("ゲームマネージャーがデバックonですゲームマネージャーがデバックonです。"); }
        Application.targetFrameRate = FPS;  //fpsを設定
        gamestate = GameStates.befor;       //ゲームの状態を開始前にする
        if (stageNumber == 0 || stageNumber >= 6) { stageNumber = 1; }  //ステージの番号が0なら1にする
        beforeUI.SetActive(true);
        interruptPanel.SetActive(false);
        playUI.SetActive(false);
        overUI.SetActive(false);
        clearUI.SetActive(false);
        tapUI.SetActive(false);
        tapUI.SetActive(false);
        explanationUI.SetActive(false); //説明文字非表示
        if (debug && specifyStageNumber != 0) { stageNumber = specifyStageNumber; }        //デバッグでステージの指定があればそのステージにする
        if(stageNumber == 1) { explanationUI.SetActive(true); } //ステージ1なら説明文字を表示する
        //マネージャー、カメラがアタッチされてなかったらfindする
        if (!humansMgr) { humansMgr = GameObject.Find("HumansMgr"); }
        if (!playerMgr) { playerMgr = GameObject.Find("PlayerMgr"); }
        if (!frontCarMgr) { frontCarMgr = GameObject.Find("FrontCarMgr"); }
        if (!backCarMgr) { backCarMgr = GameObject.Find("BackCarMgr"); }
        if (!bridgeMgr) { bridgeMgr = GameObject.Find("BridgeMgr"); }
        if (!alignLineMgr) { alignLineMgr = GameObject.Find("AlignLine"); }
        if (!mainCam) { mainCam = GameObject.Find("Main Camera"); }
        if (!gateMgr) { gateMgr = GameObject.Find("GateMgr"); }
        if (!doubleGateMgr) { doubleGateMgr = GameObject.Find("DoubleGateMgr"); }

        //ギミックを生成
        gateMgr.GetComponent<GateMgr>().OrderInst(stageNumber);
        doubleGateMgr.GetComponent<DoubleGateMgr>().OrderInst(stageNumber);
        bridgeMgr.GetComponent<BridgeMgr>().OrderInst(stageNumber);
        frontCarMgr.GetComponent<FrontCarMgr>().OrderInst(stageNumber);
        backCarMgr.GetComponent<BackCarMgr>().OrderInst(stageNumber);
    }

    // Update is called once per frame
    void Update()
    {
        //マウスカーソルの表示を変える
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetCursorVisible();
        }
        /// ----------------------------------------------------
        /// ゲーム開始前
        /// ----------------------------------------------------
        if (gamestate == GameStates.befor)    //もしゲーム状態が開始前なら
        {
            fingerImg.GetComponent<UIFunc>().MoveFingerImg();
            //その他処理はボタンの処理に変更してGameStartにした
        }
        /// ----------------------------------------------------
        /// ゲーム中
        /// ----------------------------------------------------
        if (gamestate == GameStates.play)
        {
            //一度だけ処理する
            if (!gamePlayStartFlag)
            {
                gamePlayStartFlag = true;
                beforeUI.SetActive(false);
                playUI.SetActive(true);
                //ステージ名を更新する
                StageName.text = street + ' ' + stageNumber;
            }
            //人の移動
            humansMgr.GetComponentInChildren<Pool>().StandardMove();
            //人の内部での処理、中央に向かって移動する
            humansMgr.GetComponentInChildren<Pool>().RunStandardMove();
            //人の数が0以下になっていたらゲームオーバーに遷移する
            if(humansMgr.GetComponent<HumansMgr>().GetActiveNum() <= 0)
            {
                gamestate = GameStates.over;
            }
            else if (alignLineMgr.GetComponentInChildren<AlignMgr>().GetAlignStartFlag())
            {
                gamestate = GameStates.clear;
            }
            playerObj.GetComponent<Player>().Move();  //プレイヤーの移動
        }

        //もしゲームオーバーなら
        if (gamestate == GameStates.over)
        {
            if (!gameOverStartFlag) //ゲームオーバー時に一度だけ処理する
            {
                playUI.SetActive(false);
                gameOverStartFlag = true;
                interruptPanel.SetActive(true);     //割り込み用のパネルを表示する
                overUI.SetActive(true);             //オーバー時のUIを表示する
            }
        }

        //もしゲームクリアなら
        if (gamestate == GameStates.clear)
        {
            //一度だけ実行
            if(!gameClearStartFlag)
            {
                gameClearStartFlag = true;
                stageNumber++;   //クリアステージ数を増やす
                playUI.SetActive(false);    //ゲーム中のuiを無効化する
                //人のキネマティックをonにする
                humansMgr.GetComponentInChildren<Pool>().SetIsKinematic(true);
            }

            //プレイヤーを中央に移動させつつtrue(移動完了)が帰ってきたら
            if(playerObj.GetComponent<Player>().MoveCenter())
            {
                //プレイヤーの操作に入る２本目の整列完了ラインを越えたら
                if(alignLineMgr.GetComponent<AlignMgr>().GetAlignCompFlag())
                {
                    //カメラを移動させるために状態を変更する
                    mainCam.GetComponent<Camera>().state = Camera.State.Clear;
                    if (!resultFlag)
                    {
                        //プレイヤーを画面をタップすることで動くようにする。
                        playerObj.GetComponent<Player>().MoveAfterGoal();
                    }
                        //タップ時のUIを有効にする
                        tapUI.SetActive(true);
                    if (tapUI.activeSelf)
                    {
                        tapImg.GetComponent<UIFunc>().TapFingerImg();
                        //タップされたらタップのUIだけ非表示にする
                        if (Input.GetMouseButtonDown(0))
                        {
                            tapImg.SetActive(false);
                        }
                    }
                    //人をゆっくりにする
                    humansMgr.GetComponentInChildren<Pool>().GoalMove();
                }
                else
                {
                    playerObj.GetComponentInChildren<Player>().MoveToAlignEndPos();
                    humansMgr.GetComponentInChildren<Pool>().StandardMove();
                }
            }
            else
            {
                playerObj.GetComponent<Player>().MoveToAlignEndPos();
                humansMgr.GetComponentInChildren<Pool>().StandardMove();
            }
            //プール(人の中心位置)が中央への移動が完了したら
            if (humansMgr.GetComponentInChildren<Pool>().transform.position.x == 0)
            {
                //人を整列させる関数
                humansMgr.GetComponentInChildren<HumansMgr>().Align();
            }


            //人の人数が0になったらリザルトに遷移する
            if (humansMgr.GetComponent<HumansMgr>().GetActiveNum() <= 0)
            {
                resultFlag = true;
            }

            //クリアリザルトに進んでよかったら
            if (resultFlag)
            {
                interruptPanel.SetActive(true);         //割り込み用のパネルを表示する
                clearUI.SetActive(true);                //クリア時のUIを表示する
            }
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void SetCursorVisible()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false; //マウスカーソルを非表示
        }
        else
        {
            Cursor.visible = true;
        }
    }

    public int GetStageNumber() { return stageNumber; }

    public void GameStart()
    {
        if (explanationUI.activeSelf) { explanationUI.gameObject.SetActive(false); }
        gamestate = GameStates.play;    //ゲームの状態をゲーム中に変更する
    }
}
