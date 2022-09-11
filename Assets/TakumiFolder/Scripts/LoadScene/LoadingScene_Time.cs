using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LoadingScene_Time : MonoBehaviourPunCallbacks
{
    float count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        VoidRoom();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 4)
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }

    public void VoidRoom()
    {
        Destroy(GameObject.Find("Cam2"));
        PhotonNetwork.Disconnect();
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.LeaveRoom();
        
    }
}
