using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDownToLobby : MonoBehaviour
{
    int totalTime;
    private void Update()
    {
        //���݂̃J�E���g�_�E�����Ԃ��擾
        totalTime = CountDown.GetTotalTime();
        if(totalTime <= 0)
        {
          SceneManager.LoadScene("lobby");
        }
    }
}
