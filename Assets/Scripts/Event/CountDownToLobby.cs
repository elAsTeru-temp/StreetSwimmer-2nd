using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownToLobby : MonoBehaviour
{
    int totalTime;
    private void Update()
    {
        //現在のカウントダウン時間を取得
        totalTime = CountDown.GetTotalTime();
        if(totalTime <= 0)
        {
          SceneManager.LoadScene("lobby");
        }
    }
}
