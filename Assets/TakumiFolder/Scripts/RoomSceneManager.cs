using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
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

    public static bool OneTime = true;

    [SerializeField] bool JoinRoom;

    [SerializeField] GameObject OtherPlayerClone1;

    [SerializeField] GameObject OtherPlayerClone2;

    [SerializeField] GameObject OtherPlayerClone3;

    [SerializeField] GameObject OtherPlayerClone4;

    [SerializeField] int changenum1, changenum2, changenum3, changenum4 = 0;//�v���C���[�̃N���[���̖��O��ς�����

   // private bool EnterRoomOneTime = false;//��u�ŏ��ɕ����ɓ��邱�ƂŃ��X�g�̍X�V���s���āA�V�[���J�ڌ��RoomList�̍X�V���s����悤�ɂ���

    private void Start()
    {
        // PhotonServerSettings�ɐݒ肵�����e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LocalPlayer.NickName = "Player" + (Porder+1);//Avatar�v���n�u�i�l�b�g���[�N�I�u�W�F�N�g�j�ō��ꂽ�v���C���[�̖��O���󂯎��AInstantiate�����ۂɂ͕ύX��ǂݎ��
        PhotonNetwork.IsMessageQueueRunning = true;
        CameraMove.transCamera = Camera.main.transform;
        Camera1.SetActive(false);
        Pnum.AddRange(PN);
        JoinRoom = false;
        
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ�������������A���r�[�ɎQ������
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;
        // EnterRoomOneTime = true;
        Debug.Log("�����I");
    }

    public void Update()
    {
        RoomNum.text = PhotonNetwork.CountOfPlayersInRooms + "/" + PhotonNetwork.CountOfPlayers;
        UpdateMemberList();
        //if (EnterRoomOneTime == true)
        //{
        //    PhotonNetwork.JoinRandomOrCreateRoom();
        //    //PhotonNetwork.LeaveRoom();
        //    EnterRoomOneTime = false;
        //}
    }

    public override void OnJoinedLobby()//���ؗp
    {
        Debug.Log("���r�[�ɎQ��");
        LobbyUI.SetActive(true);
        enterMatchWaitRoomUI.SetActive(false);
        Debug.Log("AAAAAAAAA" + Porder + "AAAAAAAAA");
    }

    public override void OnJoinedRoom()//���[�J���v���C���[�݂̂ɔ���
    {
        JoinRoom = true;//�����o�[���X�g�̍X�V�������[���ɓ������Ƃ��̂�OneTime�Ńv���C���[�v���n�u�ɖ��O��t���Ė��O�̕ϊ����s������
        Debug.Log("�ҋ@���[���ɎQ��");
        LobbyUI.SetActive(false);
        enterMatchWaitRoomUI.SetActive(true);
        MasterClientJudge();
        Invoke("CloneNameConversion", 0.5f);//������Porder��1�ȊO�̂Ƃ��ɍs����@�ŏ��ɕ�����������l�͕K��null���o�Ă��܂�
        PlayerClone = PhotonNetwork.Instantiate("NewPlayer", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);
        //�v���C���[�̃v���n�u�̃^�O���𓝈�H�@�K��������邩�v�m�F�@�K�����ꂽ�ꍇ�̓v���C���[�v���n�u�^�O�������I�u���Ƃ��瓦���鑀�����������
        Photon.Realtime.Player player2 = PhotonNetwork.LocalPlayer;
        p1 = player2.ActorNumber;
    }

    public override void OnPlayerEnteredRoom(Player player)//�����ŕϐ��̓������s���� �Q�������{�l�͍s���Ȃ�
    {
        Invoke("CloneNameConversion", 0.5f);//OnPlayerEntered�������UpdateMemberList����ɍs���Ă��邽�߁A0.5f�x�点�ăN���[���̎擾���ł���悤�ɂ��Ă���
        MasterClientJudge();
    }

    // ���v���C���[���ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnPlayerLeftRoom(Player player)
    {
        MasterClientJudge();
        Debug.Log("���̏���:" + Porder);
        switch (Porder)
        {
            case 1: changenum1 = 0; break;
            case 2: changenum2 = 0; break;
            case 3: changenum3 = 0; break;
            case 4: changenum4 = 0; break;
        }
    }

    private void CloneNameConversion()
    {
        if (Porder == 1)
        {
            switch (changenum1) //�s���邲�Ƃɉ񐔂�������
            {
                case 0: break;//�܂��N���[�����Ȃ�����
                case 1:
                    OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone2.name = "Player2";//2�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player2��U�蓖�Ă�
                    break;
                case 2:
                    OtherPlayerClone3 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone3.name = "Player3";//3�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player3��U�蓖�Ă�
                    break;
                case 3:
                    OtherPlayerClone4 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone4.name = "Player4";//4�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player4��U�蓖�Ă�
                    break;
            }
            changenum1++;
        }//Porder1�̓����������@���g�̓����͂܂�

        else if (Porder == 2)
        {
            switch (changenum2) //�s���邲�Ƃɉ񐔂������� //���łɂ���v���C���[1�̎擾
            {
                case 0:
                    OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone1.name = "Player1";//2�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player2��U�蓖�Ă�
                    break;
                case 1:
                    OtherPlayerClone3 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone3.name = "Player3";//3�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player3��U�蓖�Ă�
                    break;
                case 2:
                    OtherPlayerClone4 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone4.name = "Player4";//4�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player4��U�蓖�Ă�
                    break;
            }
            changenum2++;
        }
        else if (Porder == 3)
        {
            for (int i = 0; i < 2; i++)//���łɂ���v���C���[1,2�̎擾
            {
                switch (changenum3) //�s���邲�Ƃɉ񐔂�������
                {
                    case 0:
                        OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone1.name = "Player1";//1�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player2��U�蓖�Ă�
                        break;
                    case 1:
                        OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone2.name = "Player2";//2�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player3��U�蓖�Ă�
                        break;
                    case 2:
                        OtherPlayerClone4 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone4.name = "Player4";//4�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player4��U�蓖�Ă�
                        break;
                }
                changenum3++;
            }

        }
        else if (Porder == 4)//switch��else if ���ƕЕ������s���Ȃ�����if�ɂ����H�H
        {
            for (int i = 0; i < 3; i++)//���łɂ���v���C���[1,2,3�̎擾
            {

                switch (changenum4) //�s���邲�Ƃɉ񐔂�������
                {
                    case 0:
                        OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone1.name = "Player1";//1�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player2��U�蓖�Ă�
                        break;
                    case 1:
                        OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone2.name = "Player2";//2�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player3��U�蓖�Ă�
                        break;
                    case 2:
                        OtherPlayerClone3 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone3.name = "Player3";//3�l�ڂ��������Ƃ��ɖ��O�̂��ĂȂ��N���[����Player4��U�蓖�Ă�
                        break;
                }
                changenum4++;
            }
        }
        else { }
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
                PlayerClone.name = "Player" + Porder;
                OneTime = false;
                Debug.Log(num);
                Camera1.SetActive(true);
                Debug.Log("Porder:" + Porder);
                OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");//�����ڐ��݂̂ł̕ύX
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
        //Camera1.SetActive(false);
        changenum1 = 0;
        changenum2 = 0;
        changenum3 = 0;
        changenum4 = 0;
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



