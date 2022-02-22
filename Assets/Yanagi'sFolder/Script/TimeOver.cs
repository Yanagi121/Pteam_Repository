using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TimeOver : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    //カウントダウン
    public float countdown = 300.0f;
    public static bool gameover;
    

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
    }


   /* [PunRPC]
    void ChangeGameOver()
    {
        gameover = true;
    }*/
}
