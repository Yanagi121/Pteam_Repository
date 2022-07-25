using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchwaitingRoomManager : MonoBehaviourPunCallbacks
{
    private RoomSceneManager roomSceneManager;
    [SerializeField]
    private Button BackLobbyButton = default;
    [SerializeField]
    private TextMeshProUGUI Player = default;

    //private bool Judge = roomSceneManager.enterMatchWaitRoomJudge;

    private void Start()
    {
        var localPlayer = PhotonNetwork.LocalPlayer;
        Debug.Log(localPlayer);//プレイヤー名は保存されている

        PhotonNetwork.NickName = "Player";
        var nameLabel = GetComponent<TextMeshPro>();
        // プレイヤー名とプレイヤーIDを表示する
       // nameLabel.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }

    private void Update()
    {
    }
       


    //public void OnPhotonPlayerConnected(PhotonPlayer player)
    //{
    //    Debug.Log(player.name + " is joined.");
    //}



    //[PunRPC]
    //private void RpcSendMessage(string message,PhotonMessageInfo info) 
    //{
    //    //メッセージを送信したプレイヤー名も表示する
    //    Debug.Log($"{info.Sender.NickName}:{message}");
    //}

    private void BackLobbyButtonClick()
    {
        //SceneManager.LoadScene("LobbyScene");
        Debug.Log("ロビーに戻る");
    }



}
