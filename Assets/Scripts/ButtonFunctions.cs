using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    private string sceneName;  //���݂̃V�[���̖��O���i�[����ϐ�

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name; //���݂̃V�[���̖��O���擾
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
