using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomSceneManager2 : MonoBehaviourPunCallbacks
{
    [SerializeField] float delayMove=5;//�Q�[���J�n���̒�~���Ԃ̎w�肪�\

    public bool enterMatchWaitRoomJudge;
    public static bool CameFind;
    [SerializeField] GameObject Player;
    public static bool SceneEnter = false; //�Q�[���V�[���ɓ������Ƃ��ɌĂ΂��֐��@
    [SerializeField] GameObject[] players=new GameObject [4];

    private void Start()
    {
        //PhotonNetwork.LeaveLobby();
        Invoke("Progress", delayMove);
        PhotonNetwork.IsMessageQueueRunning = true;
        ////�v�m�F/// Invoke("CameraFind", 0.0f);//0.5f��ɌĂяo�����K�v���@�m�F 
        CameraFind();//�����
        SceneEnter = true;
        Player = GameObject.Find("Player" + RoomSceneManager.Porder);//�v���C���[���擾�������ړ�
        Player.transform.position = new Vector3(167, 17, 197);
        CameraMove.GamePlayer = GameObject.Find("Player" + RoomSceneManager.Porder);//�v���C���[���̂����I�u�W�F�N�g��CameraMove���擾
        for(int i = 0; i < 4; i++)
        {
            players[i].SetActive(true);
        }
    }


    // �}�X�^�[�T�[�o�[�ւ̐ڑ�������������A���r�[�ɎQ������
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"�T�[�o�[�Ƃ̐ڑ����ؒf����܂���: {cause.ToString()}");
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

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("���[�����l��:" + (PhotonNetwork.CountOfPlayersInRooms + 1));
    }

    // ���v���C���[���ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log(player.NickName + "���ޏo���܂���");
    }
    public override void OnLeftRoom()
    {
        Debug.Log("�ҋ@���[������ޏo");
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



