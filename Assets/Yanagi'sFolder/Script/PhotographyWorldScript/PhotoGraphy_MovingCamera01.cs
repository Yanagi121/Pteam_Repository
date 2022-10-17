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
        this.transform.position += new Vector3(0.1f,0,0);//カメラ初期移動
    }

    void TimeMeasurenment()//時間の経過及び経過によるActionPatterns処理
    {
        
        ElapsedTime = (int)Time.time;//確認用
        FiveCount += Time.deltaTime;//実用
        if (FiveCount >= 5 )//5秒経過でPatternが次へ進む、５秒を超えたらFiveCountは０になる
        {
            SaveCountTime += 1;//Patternのカウントを増加
            Pattern = (ActionPatterns)Enum.ToObject(typeof(ActionPatterns), SaveCountTime);//増加分を適用
            FiveCount = 0;//カウントを0に
          
        }
    }
}
