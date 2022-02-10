using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSceneManager : MonoBehaviourPunCallbacks
{
    private MatchwaitingRoomManager matchwaitingRoomManager;//���[���ɎQ�������Ƃ��Ƀ��[���̖��O�����[�����ŕ\�������邽�߁A���̕ϐ�����󂯎��
    private RoomListView roomListView;//RoomListView�Ŏ󂯎�������[�������A��̕ϐ��Ɏ󂯓n�����߂̕ϐ�

    [SerializeField]
    private Button BackLobbyButton = default;
    [SerializeField]
    private TextMeshProUGUI Player = default;

    [SerializeField]
    private GameObject LobbyUI;//���r�[��UI
    [SerializeField]
    private GameObject enterMatchWaitRoomUI;//�ҋ@������UI

    //[SerializeField]private GameObject EnterMatchWaitroomObj;//�V�[���J�ڌ�Ƀ��[���ɓ������L�^���c���Ă����p�@//��������v
    //private EnterMatchWaitRoom enterMatchWaitRoom;
    public bool enterMatchWaitRoomJudge;
    private void Start()
    {
        // PhotonServerSettings�ɐݒ肵�����e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
        var localPlayer = PhotonNetwork.LocalPlayer;
        Debug.Log(localPlayer);//�v���C���[���͕ۑ�����Ă���
        PhotonNetwork.NickName = "Player";
        var nameLabel = GetComponent<TextMeshPro>();
        //SceneManager.sceneLoaded += SceneLoaded;// �C�x���g�ɃC�x���g�n���h���[��ǉ�

    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ�������������A���r�[�ɎQ������
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;
        
    }

    //private void Update()
    //{
    //    if (enterMatchWaitRoomJudge == true)
    //    {
    //        PhotonNetwork.Instantiate("Avatar", new Vector3(0, 0, 0), Quaternion.identity);//�{�������E�j��͖]�܂����Ȃ��Ǝv���̂ŁA���Ԃ���������\���E��\���ݒ�ɂ��Ă�������
    //        enterMatchWaitRoomJudge = false;
    //    }
    //}

    //void SceneLoaded(Scene nextScene, LoadSceneMode mode)//�V�[���̐؂�ւ������m������enterMatchWaitRoomJudge = true�ɂ��A�v���C���[�����o��悤�ɂ���
    //{
    //    Debug.Log(nextScene.name);
    //    enterMatchWaitRoomJudge = true;
    //    Debug.Log(mode);
    //}

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
        PhotonNetwork.Instantiate("Avatar", new Vector3(0, 0, 0), Quaternion.identity);//�{�������E�j��͖]�܂����Ȃ��Ǝv���̂ŁA���Ԃ���������\���E��\���ݒ�ɂ��Ă�������
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
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

    public override void OnLeftRoom()
    {
        Debug.Log("���[������ޏo���܂���");
    }

    ////���̃v���C���[���Q���������ɌĂ΂��R�[���o�b�N
    //public override void OnPlayerEnteredRoom(Player player)
    //{
    //    Debug.Log(player.NickName + "���Q�����܂���");
    //}

    ////���̃v���C���[���ޏo�����Ƃ��ɌĂ΂��R�[���o�b�N
    //public override void OnPlayerLeftRoom(Player player)
    //{
    //    Debug.Log(player.NickName + "���ޏo���܂���");
    //}

}
