using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Room_Update : MonoBehaviourPunCallbacks
{
    public void OnClicked()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
    } 
}
