using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject LobbyUI;//���r�[��UI
    [SerializeField]
    private GameObject enterMatchWaitRoomUI;//�ҋ@������UI

    [SerializeField]
    private TextMeshProUGUI RoomNum;

    [SerializeField]
    private TextMeshProUGUI PlayerName;

    [SerializeField]
    private TextMeshProUGUI joinedPlayer;

    [SerializeField]
    GameObject avatarName;
    AvatarNameDisplay avatarNameDisplay;

    public bool enterMatchWaitRoomJudge;
    private void Start()
    {
        // PhotonServerSettings�ɐݒ肵�����e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
        avatarNameDisplay = avatarName.GetComponent<AvatarNameDisplay>();
        PhotonNetwork.LocalPlayer.NickName = "Player"+avatarNameDisplay.nameLabel;//Avatar�v���n�u�i�l�b�g���[�N�I�u�W�F�N�g�j�ō��ꂽ�v���C���[�̖��O���󂯎��AInstantiate�����ۂɂ͕ύX��ǂݎ��
        
        Debug.Log("����̓j�b�N�l�[��"+PhotonNetwork.NickName);//�v���C���[���͕ۑ�����Ă���

    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ�������������A���r�[�ɎQ������
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;
        
    }

    public void Update()
    {
        RoomNum.text = PhotonNetwork.CountOfPlayersInRooms + "/" + PhotonNetwork.CountOfPlayers;
        // Debug.Log(PhotonNetwork.CountOfRooms);
        UpdateMemberList();
    }




    public override void OnJoinedLobby()//���ؗp
    {
        Debug.Log("���r�[�ɎQ��");
        LobbyUI.SetActive(true);
        enterMatchWaitRoomUI.SetActive(false);
    }
    public override void OnJoinedRoom()//���[�J���v���C���[�݂̂ɔ���
    {
        Debug.Log("�ҋ@���[���ɎQ��");
        LobbyUI.SetActive(false);
        enterMatchWaitRoomUI.SetActive(true);
       // PhotonNetwork.Instantiate("Avatar", new Vector3(0, 0, 0), Quaternion.identity);//���̃l�b�g���[�N�I�u�W�F�N�g���_���������̂ŉ�������Ă��邱��Ŋm�F�������ʖڂ�����
        Debug.Log("����̓j�b�N�l�[��" + PhotonNetwork.NickName);
        //Debug.Log("���[���ɓ����ĂȂ��l"+PhotonNetwork.CountOfPlayersOnMaster);
        //Debug.Log("���[���ɓ����Ă���l" + PhotonNetwork.CountOfPlayersInRooms);
    }

    public void OnPhotonPlayerConnected()
    {
       // Debug.Log(player.name + " is joined.");
        UpdateMemberList();
    }
    public void UpdateMemberList()
    {
        joinedPlayer.text = "";
        foreach (var p in PhotonNetwork.PlayerList)
        {
            joinedPlayer.text += p.NickName + "\n";
            //PhotonNetwork.Instantiate("PlayerName", new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    public override void OnLeftRoom()
    {
        Debug.Log("�ҋ@���[������ޏo");
        LobbyUI.SetActive(true);
        enterMatchWaitRoomUI.SetActive(false);
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
