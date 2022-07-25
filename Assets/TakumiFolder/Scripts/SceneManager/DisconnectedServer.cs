using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DisconnectedServer : MonoBehaviour
{
    void Start()
    {
        PhotonNetwork.Disconnect();
    }

    void Update()
    {
        
    }
}
