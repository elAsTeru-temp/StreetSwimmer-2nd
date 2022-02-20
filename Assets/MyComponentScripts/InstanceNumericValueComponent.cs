using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//フラグを見て値を設定していくところからが続き
public enum KindOperator
{
    Addition,
    Substraction,
    multiplication,
    Division
}

public class InstanceNumericValueComponent : MonoBehaviour
{
    [Header("+Value Setting+")]
    [SerializeField] private bool rangeRandomValue;
    [SerializeField] private int maxValue;
    [SerializeField] private int minValue;
    [Header("+++++ or +++++")]
    [SerializeField] private bool appointValue;
    [SerializeField] private int value;             //乱数の場合でも生成した値を格納する
    [Header("+Operator Setting+")]
    [SerializeField] private bool randomOperator;
    [Header("+++++ or +++++")]
    [SerializeField] private bool rangeRandomOperator;
    [SerializeField] private bool addOperator;
    [SerializeField] private bool subOperator;
    [SerializeField] private bool mulOperator;
    [SerializeField] private bool divOperator;
    [Header("+++++ or +++++")]
    [SerializeField] private bool appointOperator;　//ランダムの場合でも生成した演算子を格納する
    [SerializeField] private KindOperator kindOperator; //標準のものと被るので最後にrが1つ多くついてる

    // +++ Hide Variables +++
    private bool debug = false;
    private int countSettingFlag;     //どの方式で数値を設定するかのフラグの数を数える
    private string stringOperator;    //文字での演算子



    void Start()
    {
        if (debug) { Debug.Log("数値生成のデバッグが有効です。終わったらfalseに"); }

        // 値のフラグ確認++++++++++++++++++++++++++++++++++++++++++++++++++++
        //値設定のフラグ数を数える
        if (rangeRandomValue) { countSettingFlag++; }
        if (appointValue) { countSettingFlag++; }
        //フラグ数が2つ以上あったら終了する
        if (countSettingFlag > 1)
        {
            Debug.LogError("Value Settings Not Correct");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        //演算子設定のフラグの数を数えるために初期化する
        countSettingFlag = 0;
        // 演算子のフラグ確認++++++++++++++++++++++++++++++++++++++++++++++++++++
        //演算子のフラグの数を数える
        if (randomOperator) { countSettingFlag++; }
        if (rangeRandomOperator) { countSettingFlag++; }
        if (appointOperator) { countSettingFlag++; }
        //フラグ数が2つ以上あったら終了する
        if (countSettingFlag > 1)
        {
            Debug.LogError("Value Settings Not Correct");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    private void Update()   //updateは確認用に使う
    {
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                InstanceNumericValue();
            }
        }
    }

    public int GetValue() { return value; }
    public string GetOperator() { return stringOperator; }

    private void InstanceValue()
    {   
        //値が指定されていたら終了する
        if(appointValue)
        {
            return; 
        }
        //指定範囲でランダムに値を設定する
        else if(rangeRandomValue)
        {
            value = Random.Range(minValue, maxValue);
        }
    }

    private void InstanceOperator()
    {
        //演算子が設定されていたら終了する
        if(appointOperator)
        {
            if (kindOperator == KindOperator.Addition) { stringOperator = "＋"; }
            if (kindOperator == KindOperator.Substraction) { stringOperator = "－"; }
            if (kindOperator == KindOperator.multiplication) { stringOperator = "×"; }
            if (kindOperator == KindOperator.Division) { stringOperator = "÷"; }
            return;
        }
        //完全にランダムで演算子を設定する
        else if(randomOperator)
        {
            //演算子の値( 1:＋ | 2:－ | 3:× | 4:÷ )をとる
            switch (Random.Range(1, 4))
            {
                case 1:
                    stringOperator = "＋";
                    break;
                case 2:
                    stringOperator = "－";
                    break;
                case 3:
                    stringOperator = "×";
                    break;
                case 4:
                    stringOperator = "÷";
                    break;
            }
        }
        else if(rangeRandomOperator)
        {
            int countFlag = 0;
            int randomNumber = 0;
            //フラグの数を数える
            if (addOperator) { countFlag++; }
            if (subOperator) { countFlag++; }
            if (mulOperator) { countFlag++; }
            if (divOperator) { countFlag++; }
            //１からフラグの数の範囲でランダムな値を取る
            randomNumber = Random.Range(1, countFlag + 1);
            //有効な演算子を見つけるためにもう一度数えるために初期化する
            countFlag = 0;
            if (addOperator) 
            {
                countFlag++; 
                if(randomNumber == countFlag)
                {
                    stringOperator = "＋";
                }
            }
            if (subOperator)
            {
                countFlag++;
                if (randomNumber == countFlag)
                {
                    stringOperator = "－";
                }
            }
            if (mulOperator) 
            {
                countFlag++;
                if (randomNumber == countFlag)
                {
                    stringOperator = "×";
                }
            }
            if (divOperator) 
            { 
                countFlag++;
                if (randomNumber == countFlag)
                {
                    stringOperator = "÷";
                }
            }

        }
    }

    public void InstanceNumericValue()
    {
        //値を設定
        InstanceValue();
        //演算子を設定
        InstanceOperator();

        Debug.Log(stringOperator + value);
    }
}
