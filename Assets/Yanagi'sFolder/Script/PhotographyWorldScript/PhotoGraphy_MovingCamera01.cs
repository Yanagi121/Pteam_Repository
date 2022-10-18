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

    void TimeMeasurenment()//時間の経過及び経過によるActionPatterns処理
    {
        
        ElapsedTime = (int)Time.time;//確認用
        FiveCount += Time.deltaTime;//実用
        if (FiveCount >= 5 )//5秒経過でPatternが次へ進む、５秒を超えたらFiveCountは０になる
        {
            if(SaveCountTime<5)
            SaveCountTime += 1;//Patternのカウントを増加
            Pattern = (ActionPatterns)Enum.ToObject(typeof(ActionPatterns), SaveCountTime);//増加分を適用
            FiveCount = 0;//カウントを0に
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
        this.transform.position += CameraSpeed;//カメラ移動


    }
}
