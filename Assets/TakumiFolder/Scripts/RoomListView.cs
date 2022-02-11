using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ScrollRect))]
public class RoomListView : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomListEntry roomListEntryPrefab = default; // RoomListEntry��Prefab�̎Q��

    [SerializeField]
    public TMP_InputField RoomNameInput = default;//�Q�l���� null����Ȃ��Ă����炵��

    [SerializeField]
    private TMP_InputField MessageInput = default;

    [SerializeField]
    public TMP_InputField PlayerNameInput = default;

    [SerializeField]
    private Button CreateRoomButton = default;

    [SerializeField]
    private Button PlayerNameButton = default;

    //�ҋ@���UI
    [SerializeField]
    private Button LeftRoomButton = default;

    [SerializeField]
    private Button GOButton = default;

    //DontDestroyOnLoad�p
    [SerializeField]
    private GameObject RoomSceneManagerOb;

    private ScrollRect scrollRect;
    private Dictionary<string, RoomListEntry> activeEntries = new Dictionary<string, RoomListEntry>();//Dictionary�N���X�̐錾�y�я������@Dictionary�N���X��Key�i�����j��Valu�i�l�̌������\�j
    private Stack<RoomListEntry> inactiveEntries = new Stack<RoomListEntry>();//�f�[�^�̌^���w�肵�Đ錾���āA�C���X�^���X�̐���

    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
        
    }
    private void Start()
    {
        RoomNameInput.onValueChanged.AddListener(OnRoomNameInputFieldValueChanged);
        CreateRoomButton.onClick.AddListener(OnCreateRoomButtonClick);
        PlayerNameInput.onValueChanged.AddListener(PlayerNameInputFieldValueChanged);//���O�����
        LeftRoomButton.onClick.AddListener(LeftRoom);
        GOButton.onClick.AddListener(PlayScene);
    }

    private void OnRoomNameInputFieldValueChanged(string value)//���[������1�����ȏ�Ȃ���΍쐬�s�ƂȂ�H
    {
        CreateRoomButton.interactable = (value.Length > 0);
    }
    private void PlayerNameInputFieldValueChanged(string value)//�v���C���[����1�����ȏ�Ȃ���΍쐬�s�H�H
    {
        PlayerNameButton.interactable = (value.Length > 0);
        PhotonNetwork.NickName = value;
    }
    private void LeftRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    private void PlayScene()
    {
        PhotonNetwork.IsMessageQueueRunning = false;//�`���[�g���A����1  PhotonNetwork.IsMessageQueueRunning = true;�̓v���C���[��ʂōs���邩�m�F
        //DontDestroyOnLoad(RoomSceneManagerOb);
        SceneManager.LoadScene("RoomScene");//����
    }

    private void OnCreateRoomButtonClick()
    {
        // ���[���쐬�������́A���͂ł��Ȃ��悤�ɂ���
        //canvasGroup.interactable = false;
        PhotonNetwork.CreateRoom(
            null, // �����I�Ƀ��j�[�N�ȃ��[�����𐶐�����
             new RoomOptions()
             {
                 MaxPlayers = 4,
                 CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() {
                                 { "DisplayName",RoomNameInput.text },//PhotonNetwork.NickName
                                 { "Message", MessageInput.text }
                     },
                 CustomRoomPropertiesForLobby = new[] { "DisplayName", "Message" }
             });
      //  Debug.Log(PhotonNetwork.PlayerList);
        //PhotonNetwork.JoinOrCreateRoom("Room" + , new RoomOptions(), TypedLobby.Default);
    }

    // ���[�����X�g���X�V���ꂽ���ɌĂ΂��R�[���o�b�N
    public override void OnRoomListUpdate(List<RoomInfo> roomList)//���[���̒��ɂ��郊�X�g�̃f�[�^���������ɓ����
    {
        foreach (var info in roomList)//var�^�̕ϐ�info�ɁAroomList�̗v�f�����ԂɎ��o���Ċi�[���Ă���BroomList�̖����f�[�^���o��܂ŌJ��Ԃ�
        {

            RoomListEntry entry;
            if (activeEntries.TryGetValue(info.Name, out entry))
            {
               
                if (!info.RemovedFromList)
                {
                    // ���X�g�v�f���X�V����
                    entry.Activate(info);//RoomListEntry��Activate�Ń��X�g�X�V�@���łɂ���Activate�֐��͉�����������̂�return�ŕԂ��Ȃ��Ă����̂��䂷��
                }
                else
                {
                    // ���X�g�v�f���폜����
                    activeEntries.Remove(info.Name);
                    entry.Deactivate();
                    inactiveEntries.Push(entry);
                }
            }
            else if (!info.RemovedFromList)
            {
                // ���X�g�v�f��ǉ�����
                entry = (inactiveEntries.Count > 0)
                    ? inactiveEntries.Pop().SetAsLastSibling(): Instantiate(roomListEntryPrefab, scrollRect.content);//��ґ���̒l��Ԃ��@�@�����䂷���@�E�͐���
                //Stack�N���X��Pop()...�f�[�^�̎��o���@Push()...�f�[�^�̓o�^

                entry.Activate(info);//���X�g�X�V
                activeEntries.Add(info.Name, entry);//activeEntries�̃��X�g��info.Name��entry�N���X�������Ă���H�H
            }
        }
    }

}