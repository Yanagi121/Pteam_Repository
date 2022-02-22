using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class TimeOver : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    //カウントダウン
    public static float countdown = 300.0f;
    int IntNum;
    public static bool gameover;
    public TextMeshProUGUI TimeText;

    private void Start()
    {
       TimeText.text = "0";
    }
    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;
        else
        {
            countdown = 0;
            gameover = true;
            //photonView.RPC(nameof(ChangeGameOver), RpcTarget.All);
        }
        IntNum = (int)countdown;
        TimeText.text = (IntNum / 60).ToString("0") + " : " + (IntNum % 60).ToString("00");
        if (Input.GetKeyDown(KeyCode.Q)) photonView.RPC(nameof(ChangeGameOver), RpcTarget.All);//ifの中身を捕まえた時の条件の代わり

    }


    [PunRPC]
    void ChangeGameOver()
    {
        gameover = true;
    }
}
