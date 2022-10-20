using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhotoGraphy_MovingCamera01 : MonoBehaviour
{
    float  ElapsedTime;
    [SerializeField] float CountTime,SettingTime=5f;
    [SerializeField] GameObject Chair;
    int SaveCountTime=0;
    bool isOne=true;
    Vector3 CameraPos,CameraRot,CameraSpeed,LocalCameraSpeed;
    float[,,] ArrayCameraTransform;
    float[] a =new float[] { 1,1,1};
    // Start is called before the first frame update
    public enum ActionPatterns//状態を管理
    {
        FirstElapsed,
        SecondElapsed,
        ThirdElapsed,
        FourthElapsed,
        FifthElapsed,

    }
    private ActionPatterns Pattern;
    void Start()
    {
        ArrayCameraTransform = new float[,,] { 
            {{-111.62f , 141.1f , 183.3f }, {20.62f, 90f , 0f }, {0.1f , 0 , 0 } ,{0,0,0 } },
            {{178.5f, 26.13f,372.41f },{-24.6f,0f,0f },{0.1f,0,0 },{0,0,0 } } ,
            {{279.78f,26.66f,119.56f },{-7.3f,201.5f,0f },{0,0,0 },{0.025f,0,0} },
            {{263.05f,29.35f,113.49f},{-0.981f,370.446f,-1.41f},{0,0,0},{0,0,0 } },
            {{191.2f,27f,223.7f},{-22.29f,464.3f,-1.405f },{0,0,0 },{0,0,0 } }
        };/*順に（ポジションX座標、Y座標、Z座標　、
        　　　　　ローテーションX座標、Y座標、Z座標　、
            　　　カメラの移動速度X座標、Y座標、Z座標　、
           　　　 カメラのローカル方向に対しての移動速度X座標、Y座標、Z座標）*/
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
        CountTime += Time.deltaTime;//実用
        if (CountTime >= SettingTime)//SettingTime(初期値は５秒)経過でPatternが次へ進む、SettingTime(初期値は５秒)を超えたらCountは０になる
        {
            if(SaveCountTime< Enum.GetNames(typeof(ActionPatterns)).Length-1)//ActionPatternsの要素数にCountTimeが追い付いたらカウントの増加を実行しない
                SaveCountTime++;//Patternのカウントを増加
            Pattern = (ActionPatterns)Enum.ToObject(typeof(ActionPatterns), SaveCountTime);//増加分を適用
            CountTime = 0;//カウントを0に
            isOne = true; //MovingCameraのカメラ位置をリセットする際に使用
        }
    }
    void MovingCamera()//カメラの移動処理
    {   
        if (isOne)//カメラの位置をリセット
        {
            SetCameraTransform((int)Pattern);//カメラの初期位置、角度、移動速度を設定
            this.transform.position = CameraPos;//ポジションをセット
            this.transform.eulerAngles = CameraRot;//ローテーションをセット
            SetActiveObject();//オブジェクトの表示非表示（椅子の背面が透明になっているため見た目上必要な処理）
            isOne = false;
        }
        this.transform.position += CameraSpeed;//カメラ移動
        this.gameObject.transform.Translate(LocalCameraSpeed);//ローカル座標のカメラ移動

    }
    void SetCameraTransform(int PatterNnum)//カメラの移動方向、位置などを記憶
    {
        CameraPos = new Vector3(ArrayCameraTransform[PatterNnum,0, 0], ArrayCameraTransform[PatterNnum,0, 1], ArrayCameraTransform[PatterNnum,0, 2]);
        CameraRot = new Vector3(ArrayCameraTransform[PatterNnum,1, 0], ArrayCameraTransform[PatterNnum,1, 1], ArrayCameraTransform[PatterNnum,1, 2]);
        CameraSpeed = new Vector3(ArrayCameraTransform[PatterNnum,2, 0], ArrayCameraTransform[PatterNnum,2, 1], ArrayCameraTransform[PatterNnum,2, 2]);
        LocalCameraSpeed = new Vector3(ArrayCameraTransform[PatterNnum,3, 0], ArrayCameraTransform[PatterNnum,3, 1],ArrayCameraTransform[PatterNnum,3, 2]);
    }
    void SetActiveObject()//オブジェクトの時間による表示処理
    {
        switch ((int)Pattern)
        {
            case (int)ActionPatterns.FourthElapsed:
                Chair.SetActive(true);
                break;
            default:
                Chair.SetActive(false);
                break;
        }
    }
}
