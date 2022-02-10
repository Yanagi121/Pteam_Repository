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
        // リスト要素がクリックされたら、対応したルーム名のルームに参加する
        button.onClick.AddListener(() => PhotonNetwork.JoinRoom(roomName));//  =>...ラムダ式ってやつらしい とりあえず引数の型の記述を省略するらしい

        // button.onClick.AddListener(() => PhotonNetwork.JoinRoom(roomName));
    }
    public void Activate(RoomInfo info)//RoomListViewで呼び出される
    {
        roomName = info.Name;//Nameなんぞ
        nameLabel.text = (string)info.CustomProperties["DisplayName"];//CustomPropertiesルームかプレイヤーに設定できるHash値　値変更でコールバックも呼ばれる
        messageLabel.text = (string)info.CustomProperties["Message"];
        playerCounter.SetText("{0}/{1}", info.PlayerCount, info.MaxPlayers);
        // ルームの参加人数が満員でない時だけ、クリックできるようにする
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