using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public GameObject WaterEffct;//水しぶきのEffect
    public bool inRiver;//川に入ったかの判定
    private float Time;//Effectを出すための間隔を計る時間
    public float IntervalTime;//Effectを出す間隔
    SoundManager soundManager;


    public void Start()
    {
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();//GameControlのSoundManagerを探してくる
        inRiver = false;//川に入ったかの判定の初期化
        IntervalTime = 0.4f;//Effectを出す間隔の初期化
    }

    public void Update()
    {
        Time += UnityEngine.Time.deltaTime;

        if (Time >= IntervalTime)//Effectを出す時間の判定
        {
            if (inRiver){
                Instantiate(WaterEffct, this.transform.position, Quaternion.Euler(90.0f,0f,0f));
                soundManager.PlaySeByName("hito_ge_aru_mizu02short");
            }//パーティクル用ゲームオブジェクト生成
            //soundManager.StopSe();
            Time = 0.0f;
        }
    }

    //他のオブジェクトに衝突したかを調べるメソッド
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "River"){inRiver = true; }//Riverタグの付いたゲームオブジェクトに入ったか判別
    }

    //他のオブジェクトを出たかをを調べるメソッド
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "River") { inRiver = false; }//Riverタグの付いたゲームオブジェクトを出たか判別
    }
}