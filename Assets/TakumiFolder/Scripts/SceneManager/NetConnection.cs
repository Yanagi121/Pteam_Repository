using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using System.Collections.Generic;

public class NetConnection : MonoBehaviourPunCallbacks
{
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
}
