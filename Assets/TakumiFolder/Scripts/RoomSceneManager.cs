using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomSceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject LobbyUI;//���r�[��UI

    [SerializeField]
    private GameObject enterMatchWaitRoomUI;//�ҋ@������UI

    [SerializeField]
    private TextMeshProUGUI RoomNum;//�����ɂ���l���̔c���@��������

    [SerializeField]
    private TextMeshProUGUI joinedPlayer;

    [SerializeField]
    GameObject avatarName;

    [SerializeField]
    private GameObject PlayButton;//�}�X�^�[�N���C�A���g�̂�GO�{�^����������

    [SerializeField]
    private GameObject Readybutton;//�}�X�^�[�N���C�A���g�ȊO��Ready�{�^����������

    [SerializeField]
    private GameObject CompletionButton;//�����{�^���������ꂽ�ۂɐ؂�ւ��

    [SerializeField]
    public bool enterMatchWaitRoomJudge;

    [SerializeField] int num = 0;

    [SerializeField] GameObject Camera1;

    [SerializeField] GameObject PlayerClone;//�C���X�y�N�^�[�ɕ\������鐶�����ꂽ�v���n�u�̖��O

    [SerializeField] int p1;

    public static int Porder;//�v���C���[�̏���

    [SerializeField] List<int> Pnum;

    [SerializeField] int[] PN = { 0, 0, 0, 0 };

    public static bool OneTime;

    [SerializeField] bool JoinRoom;
    [SerializeField] Text PlayerNAME;

    // private bool EnterRoomOneTime = false;//��u�ŏ��ɕ����ɓ��邱�ƂŃ��X�g�̍X�V���s���āA�V�[���J�ڌ��RoomList�̍X�V���s����悤�ɂ���

    private void Start()
    {
        // PhotonServerSettings�ɐݒ肵�����e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LocalPlayer.NickName = "Player" + Random.Range(1, 1000);//Avatar�v���n�u�i�l�b�g���[�N�I�u�W�F�N�g�j�ō��ꂽ�v���C���[�̖��O���󂯎��AInstantiate�����ۂɂ͕ύX��ǂݎ��
        PhotonNetwork.IsMessageQueueRunning = true;
        CameraMove.transCamera = Camera.main.transform;
        Camera1.SetActive(false);
        Pnum.AddRange(PN);
        JoinRoom = false;
        Destroy(GameObject.Find("Cam2"));
        OneTime = true;
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ�������������A���r�[�ɎQ������
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;
        Debug.Log("�����I");
    }

    public void Update()
    {
        RoomNum.text = PhotonNetwork.CountOfPlayersInRooms + "/" + PhotonNetwork.CountOfPlayers;
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
        JoinRoom = true;//�����o�[���X�g�̍X�V�������[���ɓ������Ƃ��̂�OneTime�Ńv���C���[�v���n�u�ɖ��O��t���Ė��O�̕ϊ����s������
        Debug.Log("�ҋ@���[���ɎQ��");
        Debug.Log("Player_Porder:" + Porder);
        LobbyUI.SetActive(false);
        enterMatchWaitRoomUI.SetActive(true);
        MasterClientJudge();
        //�v���C���[�̃v���n�u�̃^�O���𓝈�@�K��������邩�v�m�F�@�K�����ꂽ�ꍇ�̓v���C���[�v���n�u�^�O�������I�u���Ƃ��瓦���鑀�����������
        Photon.Realtime.Player player2 = PhotonNetwork.LocalPlayer;
        p1 = player2.ActorNumber;
    }

    public override void OnPlayerEnteredRoom(Player player)//�����ŕϐ��̓������s���� �Q�������{�l�͍s���Ȃ�
    {
        //Invoke("CloneNameConversion", 0.5f);//OnPlayerEntered�������UpdateMemberList����ɍs���Ă��邽�߁A0.5f�x�点�ăN���[���̎擾���ł���悤�ɂ��Ă���
        MasterClientJudge();
    }

    // ���v���C���[���ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnPlayerLeftRoom(Player player)
    {
        Invoke(nameof(PlayerNum_Change), 0.5f);
        MasterClientJudge();
        Debug.Log("���̏���:" + Porder);
    }

    public void PlayerNum_Change()
    {
        if (GameObject.Find("Player1(Clone)"))
        {
            Debug.Log("Player1������܂�");
        }
        else
        {
            Debug.Log("Player1������܂���BPorder��" + Porder);
            switch (Porder)
            {
                case 2: Porder = 1; break;
                case 3: Porder = 2; break;
                case 4: Porder = 3; break;
            }

        }

        if (GameObject.Find("Player2(Clone)"))
        {
            Debug.Log("Player2������܂�");
        }
        else
        {
            Debug.Log("Player2������܂���BPorder��" + Porder);
            switch (Porder)
            {
                case 3: Porder = 2; break;
                case 4: Porder = 3; break;
            }
        }

        if (GameObject.Find("Player3(Clone)"))
        {
            Debug.Log("Player3������܂�");
        }
        else
        {
            Debug.Log("Player3������܂���BPorder��" + Porder);
            if (Porder == 4)
            {
                Porder = 3;
            }
        }
        PhotonNetwork.Destroy(PlayerClone);
        PlayerClone = PhotonNetwork.Instantiate("Player" + Porder.ToString(), new Vector3(170 - Porder * 2.5f, 30, 200), Quaternion.identity);
    }



    public void UpdateMemberList()
    {
        num = 0;
        joinedPlayer.text = "";

        foreach (var p in PhotonNetwork.PlayerList)
        {
            joinedPlayer.text += p.NickName + "\n";
            Pnum[num] = p.ActorNumber;  //��̔z���ID�����Ă���
            num++;
        }
        for (int i = 0; i < Pnum.Count; i++)
        {
            if (p1 == Pnum[i]) { Porder = i + 1; }//�v���C���[�����[�����ɓ������Ƃ���ID�����݂�
        }
        if (JoinRoom == true)//�����ɎQ�������Ƃ��Ɍ���
        {
            if (OneTime)
            {
                OneTime = false;
                Debug.Log(num);
                Camera1.SetActive(true);
                Debug.Log("����Porder:" + Porder);
                PlayerClone = PhotonNetwork.Instantiate("Player" + Porder.ToString(), new Vector3(170 - Porder * 2.5f, 30, 200), Quaternion.identity);
            }
        }
    }

    public override void OnLeftRoom()
    {
        JoinRoom = false;//�����ɓ������ۂ̈�x�݂̂ōs����悤�ɂ��邽��
        OneTime = true;//������x�s����悤�ɂ��邽��
        Debug.Log("�ҋ@���[������ޏo");
        LobbyUI.SetActive(true);
        enterMatchWaitRoomUI.SetActive(false);
    }

    public override void OnLeftLobby()
    {
        Debug.Log("���r�[����ޏo");
    }

    private void MasterClientJudge()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("���g���}�X�^�[�N���C�A���g�ł�");
            PlayButton.SetActive(true);
            //   Readybutton.SetActive(false);
            //   CompletionButton.SetActive(false);
        }
        else
        {
            Debug.Log("���g�����[�J���v���C���[�ł�");
            PlayButton.SetActive(false);
            //   Readybutton.SetActive(true);
        }
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



