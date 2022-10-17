using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhotoGraphy_MovingCamera01 : MonoBehaviour
{
    float CameraSpeed, InitialPosX, InitialPosY,
        InitialPosZ, ElapsedTime;
    float FiveCount;
        int SaveCountTime=0;
    // Start is called before the first frame update
    public enum ActionPatterns
    {
        ZeroSecondsElapsed,
        FiveSecondsElapsed,
        TenSecondsElapsed,
        FifteenSecondsElapsed,
        TwentySecondsElapsed,

    }
    private ActionPatterns Pattern;
    void Start()
    {
        /*int num = 1;
        ActionPatterns sEnum = (ActionPatterns)Enum.ToObject(typeof(ActionPatterns), num);
        Debug.Log(sEnum);*/
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeMeasurenment();
        Debug.Log(" Pattern:"+Pattern+" Count:"+ SaveCountTime+"  time:"+ ElapsedTime);
        this.transform.position += new Vector3(0.1f,0,0);//�J���������ړ�
    }

    void TimeMeasurenment()//���Ԃ̌o�ߋy�ьo�߂ɂ��ActionPatterns����
    {
        
        ElapsedTime = (int)Time.time;//�m�F�p
        FiveCount += Time.deltaTime;//���p
        if (FiveCount >= 5 )//5�b�o�߂�Pattern�����֐i�ށA�T�b�𒴂�����FiveCount�͂O�ɂȂ�
        {
            SaveCountTime += 1;//Pattern�̃J�E���g�𑝉�
            Pattern = (ActionPatterns)Enum.ToObject(typeof(ActionPatterns), SaveCountTime);//��������K�p
            FiveCount = 0;//�J�E���g��0��
          
        }
    }
}
