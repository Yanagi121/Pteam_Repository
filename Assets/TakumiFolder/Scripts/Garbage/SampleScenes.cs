using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

//MonoBehaviourPunCallbacks���p�����APhoton�̃R�[���o�b�N���󂯓����悤�ɂ���
public class SampleScenes : MonoBehaviourPunCallbacks    
{
    void Start()
    {
        //PhotonSereverSettings�ɐݒ肵�����e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����

        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.SerializationRate = 10;
        PhotonNetwork.UseRpcMonoBehaviourCache = true;
        // PhotonNetwork.LocalPlayer.NickName = "Player";
        // PhotonNetwork.playerName = "guest" + UnityEngine.Random.Range(1000, 9999);
        SceneManager.LoadScene("RoomScene");
    }

    //�}�X�^�[�T�[�o�[(�v���C���[���}�b�`���O���s���A���r�[�̂悤�Ȃ���)�ւ̐ڑ������������ۂɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        string displayName = $"{PhotonNetwork.NickName}�̕���";
        PhotonNetwork.JoinOrCreateRoom("room", GameRoomProperty.CreateRoomOptions(displayName), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        var v = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("GamePlayer", v, Quaternion.identity);        //�l�b�g���[�N�I�u�W�F�N�g����邽�߂ɕK�v�Ȏ菇�̈��
        //���݂̃T�[�o�[�������A�Q�[���̊J�n�����ɐݒ肷��
        if (PhotonNetwork.IsMasterClient && !PhotonNetwork.CurrentRoom.HasStartTime())
        {
            PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
        }
    }

    //���̃v���C���[���Q���������ɌĂ΂��R�[���o�b�N
    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.Log(player.NickName + "���Q�����܂���");
    }

    //���̃v���C���[���ޏo�����Ƃ��ɌĂ΂��R�[���o�b�N
    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log(player.NickName + "���ޏo���܂���");
    }

    //���M�͂Ȃ������[���^�}�b�`���O�ɕK�v�ȃX�N���v�g������Ǝv����ꏊ�@���R:�p����MonoBehaviourPunCallbacks��
    //�p�����Ă��邱�ƁA�}�X�^�[�T�[�o�[�֘A�̋L�q����Ă���̂����̃X�N���v�g�ł��邩��  ���Ƃ���������ɓ������\�b�h������
    //��������

    
}
