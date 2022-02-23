using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviourPunCallbacks
{
    GameObject Cam1;
    public void OnClick()
    {
        //PhotonNetwork.IsMessageQueueRunning = false;
        if (GameObject.Find("Camera1"))
        {
            Cam1 = GameObject.Find("Camera1");
            Destroy(Cam1);
        }
        PhotonNetwork.LeaveRoom();
    }
}
