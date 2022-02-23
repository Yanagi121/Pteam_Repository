
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Catch_Doctor : MonoBehaviourPunCallbacks
{
    public float SlowTime=1;
    public static bool CatchDr;
    public List<float> GetTime;
    public static bool BoolCatch_Doctor;
    // Start is called before the first frame update
    void Start()
    {
        BoolCatch_Doctor = false;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Dr") && Input.GetMouseButtonDown(0))
        {
            //photonView.RPC(nameof(ChangeGameOver), RpcTarget.All);
            /*CameraMove.TimeDelay=false;
            TimeOver.gameover = true;*/
            BoolCatch_Doctor = true;
            GetTime.Add(TimeOver.countdown);
        }
    }
   // [PunRPC]
    /*void ChangeGameOver()
    {
        CameraMove.TimeDelay = false;
        TimeOver.gameover = true;
    }*/
}
