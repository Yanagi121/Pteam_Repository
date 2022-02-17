using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSceneManager2 : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    //private GameObject LobbyUI;//���r�[��UI
    //[SerializeField]
    //private GameObject enterMatchWaitRoomUI;//�ҋ@������UI

    //[SerializeField]
    //private TextMeshProUGUI RoomNum;//�����ɂ���l���̔c���@��������

    //[SerializeField]
    //private TextMeshProUGUI PlayerName;

    //[SerializeField]
    //private TextMeshProUGUI joinedPlayer;

    //[SerializeField]
    //GameObject avatarName;
    AvatarNameDisplay avatarNameDisplay;

    public bool enterMatchWaitRoomJudge;
    //  private string id;
    private void Start()
    {
       
       // avatarNameDisplay = avatarName.GetComponent<AvatarNameDisplay>();
       // PhotonNetwork.LocalPlayer.NickName = "Player" + avatarNameDisplay.nameLabel.text;//Avatar�v���n�u�i�l�b�g���[�N�I�u�W�F�N�g�j�ō��ꂽ�v���C���[�̖��O���󂯎��AInstantiate�����ۂɂ͕ύX��ǂݎ��
        PhotonNetwork.IsMessageQueueRunning = true;
        
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ�������������A���r�[�ɎQ������
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;

    }

    public void Update()
    {
      //  RoomNum.text = PhotonNetwork.CountOfPlayersInRooms + "/" + PhotonNetwork.CountOfPlayers;
        // Debug.Log(PhotonNetwork.CountOfRooms);
        //UpdateMemberList();
    }




    public override void OnJoinedLobby()//���ؗp
    {
        Debug.Log("���r�[�ɎQ��");
      //  LobbyUI.SetActive(true);
      //  enterMatchWaitRoomUI.SetActive(false);
    }
    public override void OnJoinedRoom()//���[�J���v���C���[�݂̂ɔ���
    {
        Debug.Log("�ҋ@���[���ɎQ��");
        //  LobbyUI.SetActive(false);
        //  enterMatchWaitRoomUI.SetActive(true);
        //GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(176, 30, 262), Quaternion.identity) as GameObject;
        ///////////////////////////////////////////////////////////��ΏC��
        //if (PhotonNetwork.IsMasterClient)
        //{
        //    Debug.Log("���g���}�X�^�[�N���C�A���g�ł�");
        //    player.name = "Player" + 1;
        //}
        //else
        //{
        //    Debug.Log("���g�����[�J���v���C���[�ł�");
        //    player.name = "Player" + 2;
        //}
        /////////////////////////////////////////////////////////////
        // PhotonNetwork.Instantiate("Avatar", new Vector3(0, 0, 0), Quaternion.identity);//���̃l�b�g���[�N�I�u�W�F�N�g���_���������̂ŉ�������Ă��邱��Ŋm�F�������ʖڂ�����
        //Debug.Log("���[���ɓ����ĂȂ��l"+PhotonNetwork.CountOfPlayersOnMaster);�@������
        //Debug.Log("���[���ɓ����Ă���l" + PhotonNetwork.CountOfPlayersInRooms); ������
    }



    public void OnPhotonPlayerConnected()
    {
        // Debug.Log(player.name + " is joined.");
        //UpdateMemberList();
    }
    //public void UpdateMemberList()
    //{
    //    joinedPlayer.text = "";
    //    foreach (var p in PhotonNetwork.PlayerList)
    //    {
    //        joinedPlayer.text += p.NickName + "\n";
    //        //PhotonNetwork.Instantiate("PlayerName", new Vector3(0, 0, 0), Quaternion.identity);
    //    }
    //}
    public override void OnLeftRoom()
    {
        Debug.Log("�ҋ@���[������ޏo");
       // LobbyUI.SetActive(true);
       // enterMatchWaitRoomUI.SetActive(false);
    }

    // ���[���̍쐬�������������ɌĂ΂��R�[���o�b�N
    public override void OnCreatedRoom()
    {
        Debug.Log("���[���쐬�ɐ������܂���");
    }

    // ���[���̍쐬�����s�������ɌĂ΂��R�[���o�b�N
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"���[���쐬�Ɏ��s���܂���: {message}");
    }
}



