using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    private string sceneName;  //現在のシーンの名前を格納する変数

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name; //現在のシーンの名前を取得
    }
    private void ButtonToRetry()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonToNextStage()
    {
        SceneManager.LoadScene("advertisement");
    }
    public void ButtonToHome()
    {
        SceneManager.LoadScene("Home");
    }
}
