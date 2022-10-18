using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhotoGraphy_MovingCamera01 : MonoBehaviour
{
    float CameraSpeed_X,CameraSpeed_Y,CameraSpeed_Z, InitialPosX, InitialPosY,
        InitialPosZ, ElapsedTime;
    float FiveCount;
    int SaveCountTime=0;
    bool isOne;
    Vector3 CameraPos,CameraRot,CameraSpeed;
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
   
    }

    // Update is called once per frame
    void Update()
    {
        TimeMeasurenment();
        MovingCamera();
        Debug.Log(" Pattern:"+Pattern+" Count:"+ SaveCountTime+"  time:"+ ElapsedTime);
        
    }

    void TimeMeasurenment()//���Ԃ̌o�ߋy�ьo�߂ɂ��ActionPatterns����
    {
        
        ElapsedTime = (int)Time.time;//�m�F�p
        FiveCount += Time.deltaTime;//���p
        if (FiveCount >= 5 )//5�b�o�߂�Pattern�����֐i�ށA�T�b�𒴂�����FiveCount�͂O�ɂȂ�
        {
            if(SaveCountTime<5)
            SaveCountTime += 1;//Pattern�̃J�E���g�𑝉�
            Pattern = (ActionPatterns)Enum.ToObject(typeof(ActionPatterns), SaveCountTime);//��������K�p
            FiveCount = 0;//�J�E���g��0��
            isOne = true;
        }
    }
    void MovingCamera()
    {
        switch ((int)Pattern)
        {
            case 0:
                CameraPos = new Vector3(-111.62f, 141.1f, 183.3f);
                CameraRot = new Vector3(20.62f, 90f, 0f);
                CameraSpeed = new Vector3(0.1f, 0, 0);
                break;
        }
        if (isOne)
        {
            this.transform.position = CameraPos;
            this.transform.eulerAngles = CameraRot;
            isOne = false;
        }
        this.transform.position += CameraSpeed;//�J�����ړ�


    }
}
