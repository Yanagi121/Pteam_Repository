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
        Debug.Log(localPlayer);//�v���C���[���͕ۑ�����Ă���

        PhotonNetwork.NickName = "Player";
        var nameLabel = GetComponent<TextMeshPro>();
        // �v���C���[���ƃv���C���[ID��\������
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
    //    //���b�Z�[�W�𑗐M�����v���C���[�����\������
    //    Debug.Log($"{info.Sender.NickName}:{message}");
    //}

    private void BackLobbyButtonClick()
    {
        //SceneManager.LoadScene("LobbyScene");
        Debug.Log("���r�[�ɖ߂�");
    }



}
