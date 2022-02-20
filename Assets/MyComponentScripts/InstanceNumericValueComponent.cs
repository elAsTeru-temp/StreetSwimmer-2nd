using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�t���O�����Ēl��ݒ肵�Ă����Ƃ��납�炪����
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
    [SerializeField] private int value;             //�����̏ꍇ�ł����������l���i�[����
    [Header("+Operator Setting+")]
    [SerializeField] private bool randomOperator;
    [Header("+++++ or +++++")]
    [SerializeField] private bool rangeRandomOperator;
    [SerializeField] private bool addOperator;
    [SerializeField] private bool subOperator;
    [SerializeField] private bool mulOperator;
    [SerializeField] private bool divOperator;
    [Header("+++++ or +++++")]
    [SerializeField] private bool appointOperator;�@//�����_���̏ꍇ�ł������������Z�q���i�[����
    [SerializeField] private KindOperator kindOperator; //�W���̂��̂Ɣ��̂ōŌ��r��1�������Ă�

    // +++ Hide Variables +++
    private bool debug = false;
    private int countSettingFlag;     //�ǂ̕����Ő��l��ݒ肷�邩�̃t���O�̐��𐔂���
    private string stringOperator;    //�����ł̉��Z�q



    void Start()
    {
        if (debug) { Debug.Log("���l�����̃f�o�b�O���L���ł��B�I�������false��"); }

        // �l�̃t���O�m�F++++++++++++++++++++++++++++++++++++++++++++++++++++
        //�l�ݒ�̃t���O���𐔂���
        if (rangeRandomValue) { countSettingFlag++; }
        if (appointValue) { countSettingFlag++; }
        //�t���O����2�ȏ゠������I������
        if (countSettingFlag > 1)
        {
            Debug.LogError("Value Settings Not Correct");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        //���Z�q�ݒ�̃t���O�̐��𐔂��邽�߂ɏ���������
        countSettingFlag = 0;
        // ���Z�q�̃t���O�m�F++++++++++++++++++++++++++++++++++++++++++++++++++++
        //���Z�q�̃t���O�̐��𐔂���
        if (randomOperator) { countSettingFlag++; }
        if (rangeRandomOperator) { countSettingFlag++; }
        if (appointOperator) { countSettingFlag++; }
        //�t���O����2�ȏ゠������I������
        if (countSettingFlag > 1)
        {
            Debug.LogError("Value Settings Not Correct");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    private void Update()   //update�͊m�F�p�Ɏg��
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
        //�l���w�肳��Ă�����I������
        if(appointValue)
        {
            return; 
        }
        //�w��͈͂Ń����_���ɒl��ݒ肷��
        else if(rangeRandomValue)
        {
            value = Random.Range(minValue, maxValue);
        }
    }

    private void InstanceOperator()
    {
        //���Z�q���ݒ肳��Ă�����I������
        if(appointOperator)
        {
            if (kindOperator == KindOperator.Addition) { stringOperator = "�{"; }
            if (kindOperator == KindOperator.Substraction) { stringOperator = "�|"; }
            if (kindOperator == KindOperator.multiplication) { stringOperator = "�~"; }
            if (kindOperator == KindOperator.Division) { stringOperator = "��"; }
            return;
        }
        //���S�Ƀ����_���ŉ��Z�q��ݒ肷��
        else if(randomOperator)
        {
            //���Z�q�̒l( 1:�{ | 2:�| | 3:�~ | 4:�� )���Ƃ�
            switch (Random.Range(1, 4))
            {
                case 1:
                    stringOperator = "�{";
                    break;
                case 2:
                    stringOperator = "�|";
                    break;
                case 3:
                    stringOperator = "�~";
                    break;
                case 4:
                    stringOperator = "��";
                    break;
            }
        }
        else if(rangeRandomOperator)
        {
            int countFlag = 0;
            int randomNumber = 0;
            //�t���O�̐��𐔂���
            if (addOperator) { countFlag++; }
            if (subOperator) { countFlag++; }
            if (mulOperator) { countFlag++; }
            if (divOperator) { countFlag++; }
            //�P����t���O�̐��͈̔͂Ń����_���Ȓl�����
            randomNumber = Random.Range(1, countFlag + 1);
            //�L���ȉ��Z�q�������邽�߂ɂ�����x�����邽�߂ɏ���������
            countFlag = 0;
            if (addOperator) 
            {
                countFlag++; 
                if(randomNumber == countFlag)
                {
                    stringOperator = "�{";
                }
            }
            if (subOperator)
            {
                countFlag++;
                if (randomNumber == countFlag)
                {
                    stringOperator = "�|";
                }
            }
            if (mulOperator) 
            {
                countFlag++;
                if (randomNumber == countFlag)
                {
                    stringOperator = "�~";
                }
            }
            if (divOperator) 
            { 
                countFlag++;
                if (randomNumber == countFlag)
                {
                    stringOperator = "��";
                }
            }

        }
    }

    public void InstanceNumericValue()
    {
        //�l��ݒ�
        InstanceValue();
        //���Z�q��ݒ�
        InstanceOperator();

        Debug.Log(stringOperator + value);
    }
}
