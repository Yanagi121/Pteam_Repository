using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSceneManager2 : MonoBehaviourPunCallbacks
{
    [SerializeField] float delayMove = 0.1f;
    public bool enterMatchWaitRoomJudge;
    public static bool CameFind;
    [SerializeField] GameObject Player;
    public static bool SceneEnter = false; //�Q�[���V�[���ɓ������Ƃ��ɌĂ΂��֐��@
    [SerializeField] GameObject[] players=new GameObject [4];

    private void Start()
    {
        //Debug.developerConsoleVisible = false;
        Invoke("Progress", delayMove);
        // avatarNameDisplay = avatarName.GetComponent<AvatarNameDisplay>();
        // PhotonNetwork.LocalPlayer.NickName = "Player" + avatarNameDisplay.nameLabel.text;//Avatar�v���n�u�i�l�b�g���[�N�I�u�W�F�N�g�j�ō��ꂽ�v���C���[�̖��O���󂯎��AInstantiate�����ۂɂ͕ύX��ǂݎ��
        PhotonNetwork.IsMessageQueueRunning = true;
        ////�v�m�F/// Invoke("CameraFind", 0.0f);//0.5f��ɌĂяo�����K�v���@�m�F 
        CameraFind();//�����
        SceneEnter = true;
        Player = GameObject.Find("Player" + RoomSceneManager.Porder);//�v���C���[���擾�������ړ�
        Player.transform.position = new Vector3(167, 17, 197);
        CameraMove.GamePlayer = GameObject.Find("Player" + RoomSceneManager.Porder);//�v���C���[���̂����I�u�W�F�N�g��CameraMove���擾
        for(int i = 0; i < 4; i++)
        {
            players[i].SetActive(false);
        }
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ�������������A���r�[�ɎQ������
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;
    }

    public void Update()
    {
    }
    void Progress()
    {
          CameraMove.TimeDelay = true;
    }



    public override void OnJoinedLobby()//���ؗp
    {
        Debug.Log("���r�[�ɎQ��");
    }
    public override void OnJoinedRoom()//���[�J���v���C���[�݂̂ɔ���
    {
        Debug.Log("�ҋ@���[���ɎQ��");
    }
    // ���v���C���[���ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log(player.NickName + "���ޏo���܂���");
        //switch (RoomSceneManager.Porder)
        //{
        //    case 1:players[0].SetActive(true);break;
        //    case 2:players[1].SetActive(true);break;
        //    case 3:players[2].SetActive(true);break;
        //    case 4:players[3].SetActive(true);break;
        //    default:break;     
        //}
    }
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

    private void CameraFind()
    {
        CameFind = true;
    }
}



