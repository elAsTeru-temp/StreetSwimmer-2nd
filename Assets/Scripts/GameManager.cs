using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStates //�Q�[���̏�Ԃ̗񋓌^
{
    befor,
    play,
    over,
    clear
}

public class GameManager : MonoBehaviour
{
    /// ----------------------------------------------------
    /// �S�̊֘A
    /// ----------------------------------------------------
    [SerializeField]private bool debug = false;
    [Header("Game Settings")]
    [Tooltip("FPS�̒l������")] [SerializeField] private int FPS = 30;
    public static int stageNumber;                   //���X�e�[�W�ڂ����v������(�����p���ł���)�N���A�̎��ɉ��Z���Ă���
    [Tooltip("�X�e�[�W�̔ԍ�������A�f�o�b�O���̂ݗL��")] [SerializeField] private int specifyStageNumber;

    [HideInInspector] public GameStates gamestate;           //���݂̃Q�[���̏��
    private bool gamePlayStartFlag = false;               //�Q�[���J�n����1�x��������
    private bool gameOverStartFlag = false;               //�Q�[���I�[�o�[���Ɉ�x�������������邽�߂Ɏg�p
    private bool gameClearStartFlag = false;              //�Q�[���N���A���Ɉ�x�������������邽�߂Ɏg�p
    private bool resultFlag = false;                    //�N���A���Ƀ��U���g��\�����Ă�����

    private GameObject alignLineMgr = null;    //����̊J�n�ƏI�����������I�u�W�F�N�g

    /// ----------------------------------------------------
    /// �v���C���[�֘A
    /// ----------------------------------------------------
    [Tooltip("�v���C���[�̃X�N���v�g���������I�u�W�F�N�g���A�^�b�`")] public GameObject playerObj;
    [Tooltip("�v���C���[�̑O���̈ړ����x")] public float playerFrontSpeed = 0.05f;
    [Tooltip("�v���C���[�̍��E�̈ړ����x")] public float playerSlideSpeed = 4.0f;
    [Tooltip("�v���C���[�̍����̈ړ��͈͐���")] public float playerLeftSideLimit = -1.8f;
    [Tooltip("�v���C���[�̉E���̈ړ��͈͐���")] public float playerRightSideLimit = 1.8f;
    /// ----------------------------------------------------
    /// UI�֘A
    /// ----------------------------------------------------
    ////UI�̏�Ԋ֘A
    [Tooltip("�Q�[���J�n�O��UI�܂Ƃ߃I�u�W�F�N�g���A�^�b�`")] [SerializeField] private GameObject beforeUI;
    [Tooltip("�N���A�A�I�[�o�[�A�r����~�̎��Ɋ��荞�݂œ���UI�܂Ƃ߃I�u�W�F�N�g���A�^�b�`")] [SerializeField] private GameObject interruptPanel;
    [Tooltip("�v���C����UI�܂Ƃ߃I�u�W�F�N�g���A�^�b�`")] [SerializeField] private GameObject playUI;
    [Tooltip("�N���A���̃^�b�v��UI�܂Ƃ߃I�u�W�F�N�g���A�^�b�`")] [SerializeField] private GameObject tapUI;
    [Tooltip("�I�[�o�[UI�܂Ƃ߃I�u�W�F�N�g���A�^�b�`")] [SerializeField] private GameObject overUI;
    [Tooltip("�N���AUI�܂Ƃ߃I�u�W�F�N�g���A�^�b�`")] [SerializeField] private GameObject clearUI;
    ////�J�n�O�̑����`���邽�߂̎w��UI�֘A
    [Tooltip("�����`���镶��")] [SerializeField] public GameObject explanationUI;
    [Tooltip("�Q�[���J�n�O�Ɏʂ��w�̉摜")] [SerializeField] public GameObject fingerImg;
    [Tooltip("���E�̐U�ꕝ�̒l")] [SerializeField] public float rangeFinger = 0.5f;
    [Tooltip("���E�̐U�ꑬ�x(�~�^���𗘗p���Ă�̂ŁA360�������l���ǂ�)")] [SerializeField] public float rangeFingerSpeed = 3;
    ////�N���A�̃^�b�v�̑����`���邽�߂̎w��UI�֘A
    [Tooltip("�Q�[���N���A�Ɏʂ��^�b�v�̉摜")] [SerializeField] public GameObject tapImg;
    [Tooltip("�^�b�v����̊g��̍ő�{��")] [SerializeField] public float tapImgExpandMax;
    [Tooltip("�^�b�v����̏k���̍ő�{��")] [SerializeField] public float tapImgShrinkMax;
    [Tooltip("�^�b�v����̊g�k�X�s�[�h(0~1)")] [SerializeField] public float tapSpeed;
    ////�S�[���܂ł̋����֘A
    [Tooltip("�X�e�[�W��������e�L�X�g�I�u�W�F�N�g���A�^�b�`")] public Text StageName;
    private string street = "Street";       //�S�[���܂ł̋����Q�[�W�̏�ɃX�e�[�W�ԍ��݂����ɁAStreet10�̂悤�ɕ\���̂��߂Ɏg��
    /// ----------------------------------------------------
    /// �e�}�l�[�W���[�ƃJ����
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
        if (debug) { Debug.LogWarning("�Q�[���}�l�[�W���[���f�o�b�Non�ł��Q�[���}�l�[�W���[���f�o�b�Non�ł��B"); }
        Application.targetFrameRate = FPS;  //fps��ݒ�
        gamestate = GameStates.befor;       //�Q�[���̏�Ԃ��J�n�O�ɂ���
        if (stageNumber == 0 || stageNumber >= 6) { stageNumber = 1; }  //�X�e�[�W�̔ԍ���0�Ȃ�1�ɂ���
        beforeUI.SetActive(true);
        interruptPanel.SetActive(false);
        playUI.SetActive(false);
        overUI.SetActive(false);
        clearUI.SetActive(false);
        tapUI.SetActive(false);
        tapUI.SetActive(false);
        explanationUI.SetActive(false); //����������\��
        if (debug && specifyStageNumber != 0) { stageNumber = specifyStageNumber; }        //�f�o�b�O�ŃX�e�[�W�̎w�肪����΂��̃X�e�[�W�ɂ���
        if(stageNumber == 1) { explanationUI.SetActive(true); } //�X�e�[�W1�Ȃ����������\������
        //�}�l�[�W���[�A�J�������A�^�b�`����ĂȂ�������find����
        if (!humansMgr) { humansMgr = GameObject.Find("HumansMgr"); }
        if (!playerMgr) { playerMgr = GameObject.Find("PlayerMgr"); }
        if (!frontCarMgr) { frontCarMgr = GameObject.Find("FrontCarMgr"); }
        if (!backCarMgr) { backCarMgr = GameObject.Find("BackCarMgr"); }
        if (!bridgeMgr) { bridgeMgr = GameObject.Find("BridgeMgr"); }
        if (!alignLineMgr) { alignLineMgr = GameObject.Find("AlignLine"); }
        if (!mainCam) { mainCam = GameObject.Find("Main Camera"); }
        if (!gateMgr) { gateMgr = GameObject.Find("GateMgr"); }
        if (!doubleGateMgr) { doubleGateMgr = GameObject.Find("DoubleGateMgr"); }

        //�M�~�b�N�𐶐�
        gateMgr.GetComponent<GateMgr>().OrderInst(stageNumber);
        doubleGateMgr.GetComponent<DoubleGateMgr>().OrderInst(stageNumber);
        bridgeMgr.GetComponent<BridgeMgr>().OrderInst(stageNumber);
        frontCarMgr.GetComponent<FrontCarMgr>().OrderInst(stageNumber);
        backCarMgr.GetComponent<BackCarMgr>().OrderInst(stageNumber);
    }

    // Update is called once per frame
    void Update()
    {
        //�}�E�X�J�[�\���̕\����ς���
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetCursorVisible();
        }
        /// ----------------------------------------------------
        /// �Q�[���J�n�O
        /// ----------------------------------------------------
        if (gamestate == GameStates.befor)    //�����Q�[����Ԃ��J�n�O�Ȃ�
        {
            fingerImg.GetComponent<UIFunc>().MoveFingerImg();
            //���̑������̓{�^���̏����ɕύX����GameStart�ɂ���
        }
        /// ----------------------------------------------------
        /// �Q�[����
        /// ----------------------------------------------------
        if (gamestate == GameStates.play)
        {
            //��x������������
            if (!gamePlayStartFlag)
            {
                gamePlayStartFlag = true;
                beforeUI.SetActive(false);
                playUI.SetActive(true);
                //�X�e�[�W�����X�V����
                StageName.text = street + ' ' + stageNumber;
            }
            //�l�̈ړ�
            humansMgr.GetComponentInChildren<Pool>().StandardMove();
            //�l�̓����ł̏����A�����Ɍ������Ĉړ�����
            humansMgr.GetComponentInChildren<Pool>().RunStandardMove();
            //�l�̐���0�ȉ��ɂȂ��Ă�����Q�[���I�[�o�[�ɑJ�ڂ���
            if(humansMgr.GetComponent<HumansMgr>().GetActiveNum() <= 0)
            {
                gamestate = GameStates.over;
            }
            else if (alignLineMgr.GetComponentInChildren<AlignMgr>().GetAlignStartFlag())
            {
                gamestate = GameStates.clear;
            }
            playerObj.GetComponent<Player>().Move();  //�v���C���[�̈ړ�
        }

        //�����Q�[���I�[�o�[�Ȃ�
        if (gamestate == GameStates.over)
        {
            if (!gameOverStartFlag) //�Q�[���I�[�o�[���Ɉ�x������������
            {
                playUI.SetActive(false);
                gameOverStartFlag = true;
                interruptPanel.SetActive(true);     //���荞�ݗp�̃p�l����\������
                overUI.SetActive(true);             //�I�[�o�[����UI��\������
            }
        }

        //�����Q�[���N���A�Ȃ�
        if (gamestate == GameStates.clear)
        {
            //��x�������s
            if(!gameClearStartFlag)
            {
                gameClearStartFlag = true;
                stageNumber++;   //�N���A�X�e�[�W���𑝂₷
                playUI.SetActive(false);    //�Q�[������ui�𖳌�������
                //�l�̃L�l�}�e�B�b�N��on�ɂ���
                humansMgr.GetComponentInChildren<Pool>().SetIsKinematic(true);
            }

            //�v���C���[�𒆉��Ɉړ�������true(�ړ�����)���A���Ă�����
            if(playerObj.GetComponent<Player>().MoveCenter())
            {
                //�v���C���[�̑���ɓ���Q�{�ڂ̐��񊮗����C�����z������
                if(alignLineMgr.GetComponent<AlignMgr>().GetAlignCompFlag())
                {
                    //�J�������ړ������邽�߂ɏ�Ԃ�ύX����
                    mainCam.GetComponent<Camera>().state = Camera.State.Clear;
                    if (!resultFlag)
                    {
                        //�v���C���[����ʂ��^�b�v���邱�Ƃœ����悤�ɂ���B
                        playerObj.GetComponent<Player>().MoveAfterGoal();
                    }
                        //�^�b�v����UI��L���ɂ���
                        tapUI.SetActive(true);
                    if (tapUI.activeSelf)
                    {
                        tapImg.GetComponent<UIFunc>().TapFingerImg();
                        //�^�b�v���ꂽ��^�b�v��UI������\���ɂ���
                        if (Input.GetMouseButtonDown(0))
                        {
                            tapImg.SetActive(false);
                        }
                    }
                    //�l���������ɂ���
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
            //�v�[��(�l�̒��S�ʒu)�������ւ̈ړ�������������
            if (humansMgr.GetComponentInChildren<Pool>().transform.position.x == 0)
            {
                //�l�𐮗񂳂���֐�
                humansMgr.GetComponentInChildren<HumansMgr>().Align();
            }


            //�l�̐l����0�ɂȂ����烊�U���g�ɑJ�ڂ���
            if (humansMgr.GetComponent<HumansMgr>().GetActiveNum() <= 0)
            {
                resultFlag = true;
            }

            //�N���A���U���g�ɐi��ł悩������
            if (resultFlag)
            {
                interruptPanel.SetActive(true);         //���荞�ݗp�̃p�l����\������
                clearUI.SetActive(true);                //�N���A����UI��\������
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
            Cursor.visible = false; //�}�E�X�J�[�\�����\��
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
        gamestate = GameStates.play;    //�Q�[���̏�Ԃ��Q�[�����ɕύX����
    }
}
