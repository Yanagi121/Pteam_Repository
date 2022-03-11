using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Button))]
public class RoomListEntry : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameLabel = default;
    [SerializeField]
    private TextMeshProUGUI messageLabel = default;
    [SerializeField]
    private TextMeshProUGUI playerCounter = default;

    private RectTransform rectTransform;
    private Button button;
    private string roomName;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        button = GetComponent<Button>();
    }

    private void Start()
    {
        // ���X�g�v�f���N���b�N���ꂽ��A�Ή��������[�����̃��[���ɎQ������
        button.onClick.AddListener(() => PhotonNetwork.JoinRoom(roomName));//  =>...�����_�����Ă�炵�� �Ƃ肠���������̌^�̋L�q���ȗ�����炵��

        // button.onClick.AddListener(() => PhotonNetwork.JoinRoom(roomName));
    }
    public void Activate(RoomInfo info)//RoomListView�ŌĂяo�����
    {
        roomName = info.Name;//Name�Ȃ�
        nameLabel.text = (string)info.CustomProperties["DisplayName"];//CustomProperties���[�����v���C���[�ɐݒ�ł���Hash�l�@�l�ύX�ŃR�[���o�b�N���Ă΂��
        messageLabel.text = (string)info.CustomProperties["Message"];
        playerCounter.SetText("{0}/{1}", info.PlayerCount, info.MaxPlayers);
        // ���[���̎Q���l���������łȂ��������A�N���b�N�ł���悤�ɂ���
        button.interactable = (info.PlayerCount < info.MaxPlayers);
        gameObject.SetActive(true);
    }



    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public RoomListEntry SetAsLastSibling()
    {
        rectTransform.SetAsLastSibling();
        return this;
    }

}