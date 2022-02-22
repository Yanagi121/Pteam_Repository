using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class TimeOver : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    //カウントダウン
    public float countdown = 300.0f;
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
        TimeText.text= (countdown/60).ToString("0")+" : "+(countdown%60).ToString("00");
    }


   /* [PunRPC]
    void ChangeGameOver()
    {
        gameover = true;
    }*/
}
