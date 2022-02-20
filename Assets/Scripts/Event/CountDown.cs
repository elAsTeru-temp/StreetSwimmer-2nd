//<copyright file = "NameOfFile.cs"company = "CompanyName">
//Copyright (c) Sprocket Enterprises.All rights reserved.
//</copyright>
//<author>Ichika Terui</author>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           //UI�ɃA�N�Z�X����̂ɕK�v

public class CountDown : MonoBehaviour
{
    public float totalTime;             //�J�E���g���Ԓ�(�S�̂ŃA�N�Z�X�ł���悤��static�����Ă���)
    public static int g_totalTime;      //���X�N���v�g����A�N�Z�X�ł���悤�ɂ���
    static GameObject timerText;        //�A�N�Z�X����Q�[���I�u�W�F�N�g���i�[����p�̕ϐ�(���O�͈���Ă����v)
    

    void Start()
    {
        timerText = GameObject.Find("timerText");   //�A�N�Z�X����Q�[���I�u�W�F�N�g���i�[����
                                                    //��""�̒��̖��ƃA�N�Z�X����I�u�W�F�N�g������v������K�v������B
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0)
        {
            //timer�X�V
            totalTime -= Time.deltaTime;
            //�f�[�^��int�^�ɂ��đ��X�N���v�g����A�N�Z�X�ł���ϐ��Ɋi�[
            g_totalTime = (int)totalTime;
        }
        else
        {
            totalTime = 0;
        }
        //�e�L�X�g�̕������X�V����(��������)�B
        timerText.GetComponent<Text>().text = ((int)totalTime).ToString();
    }

    //�J�E���g�_�E���̌��݂̎��Ԃ��擾���邽�߂̊֐�
    public static int GetTotalTime()
    {
        return g_totalTime;
    }
}
