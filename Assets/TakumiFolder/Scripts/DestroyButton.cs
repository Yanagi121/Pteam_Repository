using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviourPunCallbacks
{
    GameObject Cam1;
    public void OnClick()
    {
        PhotonNetwork.IsMessageQueueRunning = false;
        PhotonNetwork.LeaveRoom();
        if (GameObject.Find("Camera1"))
        {
            Cam1 = GameObject.Find("Camera1");
            Cam1.name = "Cam2";//ï ÉVÅ[ÉìÇ≈çÌèúÇ∑ÇÈ
        }
        
    }
}
