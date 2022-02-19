using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class RoomSceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject LobbyUI;//���r�[��UI
    [SerializeField]
    private GameObject enterMatchWaitRoomUI;//�ҋ@������UI

    [SerializeField]
    private TextMeshProUGUI RoomNum;//�����ɂ���l���̔c���@��������

    [SerializeField]
    private TextMeshProUGUI PlayerName;

    [SerializeField]
    private TextMeshProUGUI joinedPlayer;

    [SerializeField]
    GameObject avatarName;
   

    [SerializeField] 
    private GameObject GoButton;//�}�X�^�[�N���C�A���g�ȊO��GO�{�^���������Ȃ�

    [SerializeField]
    private int PlayerNum;

    public bool enterMatchWaitRoomJudge;

    [SerializeField]int num = 0;
    [SerializeField] int num2;

    [SerializeField] GameObject Camera1;
    //[SerializeField] GameObject Camera2;
    //[SerializeField] GameObject Camera3;
    //[SerializeField] GameObject Camera4;

    GameObject player;

    string p;

    [SerializeField] int p1;
    public static  int Porder;//�v���C���[�̏���

    [SerializeField] List<int> Pnum;
    [SerializeField] bool Pbool;
    [SerializeField] int[] PN = { 0, 0, 0, 0 };

    [SerializeField] int RoomNumber;

    public static bool OneTime=true;

    //[SerializeField]Photon

    //  private string id;
    private void Start()
    {
        // PhotonServerSettings�ɐݒ肵�����e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LocalPlayer.NickName = "Player"+ Random.Range(1, 1000);//Avatar�v���n�u�i�l�b�g���[�N�I�u�W�F�N�g�j�ō��ꂽ�v���C���[�̖��O���󂯎��AInstantiate�����ۂɂ͕ύX��ǂݎ��
        PhotonNetwork.IsMessageQueueRunning = true;
        CameraMove.transCamera = Camera.main.transform;
        Camera1.SetActive(false);
        //Camera2.SetActive(false);
        //Camera3.SetActive(false);
        //Camera4.SetActive(false);
        Pnum.AddRange(PN);        

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
        //num = photonView.OwnerActorNr % 4;
        // Pbool = Pnum.Contains(4);

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

        //PhotonNetwork.Instantiate("NewPlayer", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);
        //PhotonNetwork.Instantiate("MainCamera", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);
         player=PhotonNetwork.Instantiate("NewPlayer", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity) ;

        //player.name = "Player" + Porder;
        
   //// Camera.SetActive(true);
        //  Instantiate(Camera1, new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity) ;
        //�v���C���[�̃v���n�u�̃^�O���𓝈�H�@�K��������邩�v�m�F�@�K�����ꂽ�ꍇ�̓v���C���[�v���n�u�^�O�������I�u���Ƃ��瓦���鑀�����������
        Photon.Realtime.Player player2 = PhotonNetwork.LocalPlayer;
       // Debug.Log("PlayerNo" + player2.ActorNumber);
        p1 = player2.ActorNumber;

        //photonView.RPC(nameof(RoomID), RpcTarget.AllBuffered, Porder);
       // photonView.RPC(nameof(PlayerNameShare), RpcTarget.AllBuffered, player.name);


        //camera.name = PhotonNetwork.LocalPlayer.NickName+"Camera";

        ///////////////////////////////////////////////////////////��ΏC��
        if (PhotonNetwork.IsMasterClient)
        {
           // Debug.Log("���g���}�X�^�[�N���C�A���g�ł�");
            GoButton.SetActive(true);
           // player.name = "Player1";
           // camera.name = "Camera1";
        }
        else
        {
           // Debug.Log("���g�����[�J���v���C���[�ł�");
            GoButton.SetActive(false);
           // player.name = "Player2";
        }
        /////////////////////////////////////////////////////////////
        // PhotonNetwork.Instantiate("Avatar", new Vector3(0, 0, 0), Quaternion.identity);//���̃l�b�g���[�N�I�u�W�F�N�g���_���������̂ŉ�������Ă��邱��Ŋm�F�������ʖڂ�����
        //Debug.Log("���[���ɓ����ĂȂ��l"+PhotonNetwork.CountOfPlayersOnMaster);�@������
        //Debug.Log("���[���ɓ����Ă���l" + PhotonNetwork.CountOfPlayersInRooms); ������
    }

    

    public void OnPhotonPlayerConnected()
    {
       // Debug.Log(player.name + " is joined.");
        UpdateMemberList();
        RoomNumber = PhotonNetwork.CountOfPlayersInRooms;
    }
    public void UpdateMemberList()
    {
        num = 0;
        joinedPlayer.text = "";

            foreach (var p in PhotonNetwork.PlayerList)
            {
                joinedPlayer.text += p.NickName + "\n";
               // Pnum.Insert(num,p.ActorNumber);
                Pnum[num] = p.ActorNumber;
                num++;
                //PhotonNetwork.Instantiate("PlayerName", new Vector3(0, 0, 0), Quaternion.identity);
            }
            for(int i = 0; i < Pnum.Count; i++)
            {
                if (p1 == Pnum[i]) { Porder = i+1; }//
            }
        if (OneTime)
        {
            player.name = "Player" + Porder;
            OneTime = false;
            Debug.Log(player.name);
            Camera1.SetActive(true);
        }
        //Debug.Log("�v���C���["+Porder);
       // Debug.Log(num);
    }
    public override void OnLeftRoom()
    {
        OneTime = true;
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

    [PunRPC]
    private void RoomID(int num)//���������ϐ���p�����������s���H�@�����͂��̒��ł̂݁H
    {
        //switch (num)
        //{
        //    case 0: player.name = "Player1"; Camera1.SetActive(true); break;
        //    case 1: player.name = "Player2"; Camera2.SetActive(true); break;
        //    case 2: player.name = "Player3"; Camera3.SetActive(true); break;
        //    case 3: player.name = "Player4"; Camera4.SetActive(true); break;
        //    default: Debug.Log("�l�����߁E�G���["); break;
        //}
    }




    [PunRPC]
    private void PlayerNameShare(string p) 
    {
        switch (p)
        {
            case "Player1":break;
            case "Player2": break;
            case "Player3": break;
            case "Player4": break;
        }
    }

}



