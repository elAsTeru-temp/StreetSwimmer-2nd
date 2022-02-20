using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour
{
    [Header("Information")]
    [Tooltip("���݂̃X�e�[�W��")] [SerializeField] private int MaxStageNum;
    private int nowSelectStageNumber;
    [Tooltip("�X�e�[�W���̃I�u�W�F�N�g")] [SerializeField] private TextMeshProUGUI stageNameObj;
    [Tooltip("�_�ł��镶���̃I�u�W�F�N�g")] [SerializeField] private Text blinkText;
    private float time; //�_�ł̂��߂̎��Ԍv���p�ϐ�
    private float speed = 0.6f;    

    // Start is called before the first frame update
    void Start()
    {
        nowSelectStageNumber = GameManager.stageNumber;
    }

    // Update is called once per frame
    void Update()
    {
        stageNameObj.text = "Street "+ nowSelectStageNumber;
        blinkText.color = GetAlphaColor(blinkText.color);
    }

    private Color GetAlphaColor(Color _color)
    {
        time += Time.deltaTime * 5.0f * speed;
        _color.a = Mathf.Sin(time) * 0.5f;

        return _color;
    }

    public void RightButton()
    {
        nowSelectStageNumber++;
        //�X�e�[�W�I���ōő�X�e�[�W�����z������X�e�[�W��1�ɂ���
        if(nowSelectStageNumber > MaxStageNum)
        {
            nowSelectStageNumber = 1;
        }
    }
    public void LeftButton()
    {
        nowSelectStageNumber--;
        //�X�e�[�W�I����0�ȉ��ɂȂ�����Ō�̃X�e�[�W�̑I���Ɉړ�����
        if(nowSelectStageNumber < 1)
        {
            nowSelectStageNumber = MaxStageNum;
        }
    }
    public void SelectStage()
    {
        GameManager.stageNumber = nowSelectStageNumber;
        SceneManager.LoadScene("Stage");
    }
}
