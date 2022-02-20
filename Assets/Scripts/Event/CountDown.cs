//<copyright file = "NameOfFile.cs"company = "CompanyName">
//Copyright (c) Sprocket Enterprises.All rights reserved.
//</copyright>
//<author>Ichika Terui</author>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           //UIにアクセスするのに必要

public class CountDown : MonoBehaviour
{
    public float totalTime;             //カウント時間長(全体でアクセスできるようにstaticがついている)
    public static int g_totalTime;      //他スクリプトからアクセスできるようにする
    static GameObject timerText;        //アクセスするゲームオブジェクトを格納する用の変数(名前は違っても大丈夫)
    

    void Start()
    {
        timerText = GameObject.Find("timerText");   //アクセスするゲームオブジェクトを格納する
                                                    //※""の中の名とアクセスするオブジェクト名を一致させる必要がある。
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0)
        {
            //timer更新
            totalTime -= Time.deltaTime;
            //データをint型にして他スクリプトからアクセスできる変数に格納
            g_totalTime = (int)totalTime;
        }
        else
        {
            totalTime = 0;
        }
        //テキストの文字を更新する(書き直す)。
        timerText.GetComponent<Text>().text = ((int)totalTime).ToString();
    }

    //カウントダウンの現在の時間を取得するための関数
    public static int GetTotalTime()
    {
        return g_totalTime;
    }
}
