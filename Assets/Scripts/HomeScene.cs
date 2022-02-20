using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour
{
    [Header("Information")]
    [Tooltip("現在のステージ数")] [SerializeField] private int MaxStageNum;
    private int nowSelectStageNumber;
    [Tooltip("ステージ名のオブジェクト")] [SerializeField] private TextMeshProUGUI stageNameObj;
    [Tooltip("点滅する文字のオブジェクト")] [SerializeField] private Text blinkText;
    private float time; //点滅のための時間計測用変数
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
        //ステージ選択で最大ステージ数を越えたらステージを1にする
        if(nowSelectStageNumber > MaxStageNum)
        {
            nowSelectStageNumber = 1;
        }
    }
    public void LeftButton()
    {
        nowSelectStageNumber--;
        //ステージ選択で0以下になったら最後のステージの選択に移動する
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
