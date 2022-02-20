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

    [SerializeField] int num = 0;
    [SerializeField] int num2;

    [SerializeField] GameObject Camera1;
    //[SerializeField] GameObject Camera2;
    //[SerializeField] GameObject Camera3;
    //[SerializeField] GameObject Camera4;

    [SerializeField] GameObject PlayerClone;//�C���X�y�N�^�[�ɕ\������鐶�����ꂽ�v���n�u�̖��O

    string p;

    [SerializeField] int p1;
    public static int Porder;//�v���C���[�̏���

    [SerializeField] List<int> Pnum;
    [SerializeField] bool Pbool;
    [SerializeField] int[] PN = { 0, 0, 0, 0 };

    [SerializeField] int RoomNumber;

    public static bool OneTime = true;

    [SerializeField] bool JoinRoom;
    [SerializeField] GameObject OtherPlayerClone1;
    [SerializeField] GameObject OtherPlayerClone2;
    [SerializeField] GameObject OtherPlayerClone3;
    [SerializeField] GameObject OtherPlayerClone4;
    [SerializeField] int changenum1,changenum2,changenum3,changenum4=0;//�v���C���[�̃N���[���̖��O��ς�����

    //  private string id;
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

        //num = photonView.OwnerActorNr % 4;
        // Pbool = Pnum.Contains(4);
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
        LobbyUI.SetActive(false);
        enterMatchWaitRoomUI.SetActive(true);
        Invoke("CloneNameConversion", 0.5f);//������Porder��1�ȊO�̂Ƃ��ɍs����@�ŏ��ɕ�����������l�͕K��null���o�Ă��܂�
        // photonView.RPC(nameof(AISATU), RpcTarget.AllBuffered, "����ɂ���");
        //PhotonNetwork.Instantiate("NewPlayer", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);
        //PhotonNetwork.Instantiate("MainCamera", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);
        PlayerClone = PhotonNetwork.Instantiate("NewPlayer", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);

        
        //OtherPlayerClone = GameObject.Find("NewPlayer(Clone)");
        //player.name = "Player" + Porder;

        //// Camera.SetActive(true);
        //  Instantiate(Camera1, new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity) ;
        //�v���C���[�̃v���n�u�̃^�O���𓝈�H�@�K��������邩�v�m�F�@�K�����ꂽ�ꍇ�̓v���C���[�v���n�u�^�O�������I�u���Ƃ��瓦���鑀�����������
        Photon.Realtime.Player player2 = PhotonNetwork.LocalPlayer;
        // Debug.Log("PlayerNo" + player2.ActorNumber);
        p1 = player2.ActorNumber;


        // photonView.RPC(nameof(PlayerNameShare), RpcTarget.AllBuffered, player.name);


        //camera.name = PhotonNetwork.LocalPlayer.NickName+"Camera";

        ///////////////////////////////////////////////////////////�@�@�}�X�^�[�N���C�A���g�������Ă��܂����ꍇ��z�肵�Ă��Ȃ����ߗv�C��
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
    }
    public override void OnPlayerEnteredRoom(Player player)//�����ŕϐ��̓������s���� �Q�������{�l�͍s���Ȃ�
    {
        //PlayerPrefab.name = "Player" + Porder;
        // Camera1.SetActive(true);
        // Debug.Log("OnPlayerEnteredRoom��Porder:"+Porder);
        Invoke("CloneNameConversion", 0.5f);//OnPlayerEntered�������UpdateMemberList����ɍs���Ă��邽�߁A0.5f�x�点�ăN���[���̎擾���ł���悤�ɂ��Ă���

    }

    private void CloneNameConversion()
    {
        if (Porder == 1)
        {
            switch (changenum1) //�s���邲�Ƃɉ񐔂�������
            {
                case 0:break;//�܂��N���[�����Ȃ�����
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

        if(Porder==2)
        {
            
            switch (changenum2) //�s���邲�Ƃɉ񐔂�������
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
        if (Porder == 3)
        {
            for(int i = 0; i < 2; i++)//���łɂ���v���C���[1,2�̎擾
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
        if (Porder == 4)//switch��else if ���ƕЕ������s���Ȃ�����if�ɂ����H�H
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
    }



    public void UpdateMemberList()
    {
        num = 0;
        joinedPlayer.text = "";

        foreach (var p in PhotonNetwork.PlayerList)
        {
            joinedPlayer.text += p.NickName + "\n";
            // Pnum.Insert(num,p.ActorNumber);
            Pnum[num] = p.ActorNumber;  //��̔z���ID�����Ă���
            num++;
            //PhotonNetwork.Instantiate("PlayerName", new Vector3(0, 0, 0), Quaternion.identity);
        }
        for (int i = 0; i < Pnum.Count; i++)
        {
            if (p1 == Pnum[i]) { Porder = i + 1; }//�v���C���[�����[�����ɓ������Ƃ���ID�����݂�
        }
        if (JoinRoom == true)//�����ɎQ�������Ƃ��Ɍ���
        {
            if (OneTime)
            {
                //photonView.RPC(nameof(RoomID), RpcTarget.AllBuffered, PlayerPrefab); 
                PlayerClone.name = "Player" + Porder;
                OneTime = false;
                //Debug.Log("aaaaaa");
                Camera1.SetActive(true);
                Debug.Log("Porder:" + Porder);
                OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");//�����ڐ��݂̂ł̕ύX
                if (Porder == 1)
                {
                  //�@ OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
                  //  OtherPlayerClone2.name = "Player1";
                    //
                }
            }
        }

        //Debug.Log("�v���C���["+Porder);
        // Debug.Log(num);
    }
    public override void OnLeftRoom()
    {
        JoinRoom = false;//�����ɓ������ۂ̈�x�݂̂ōs����悤�ɂ��邽��
        OneTime = true;//������x�s����悤�ɂ��邽��
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
    private void RoomID(GameObject playerprefab)
    {
        Debug.Log("Porder:" + Porder);
        playerprefab.name = "Player" + Porder;
    }
    [PunRPC]
    private void AISATU(string s)
    {
        Debug.Log(s);
    }



    //[PunRPC]
    //private void PlayerNameShare(string p) 
    //{
    //    switch (p)
    //    {
    //        case "Player1":break;
    //        case "Player2": break;
    //        case "Player3": break;
    //        case "Player4": break;
    //    }
    //}

}



