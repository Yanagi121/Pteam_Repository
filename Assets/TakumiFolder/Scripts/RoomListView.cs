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
    private RoomListEntry roomListEntryPrefab = default; // RoomListEntryのPrefabの参照

    [SerializeField]
    public TMP_InputField RoomNameInput = default;//参考資料 nullじゃなくていいらしい

    [SerializeField]
    private TMP_InputField MessageInput = default;

    [SerializeField]
    private Button CreateRoomButton = default;

    private ScrollRect scrollRect;
    private Dictionary<string, RoomListEntry> activeEntries = new Dictionary<string, RoomListEntry>();//Dictionaryクラスの宣言及び初期化　DictionaryクラスはKey（文字）でValu（値の検索が可能）

    private Stack<RoomListEntry> inactiveEntries = new Stack<RoomListEntry>();//データの型を指定して宣言して、インスタンスの生成

    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
        
    }
    private void Start()
    {
        RoomNameInput.onValueChanged.AddListener(OnRoomNameInputFieldValueChanged);
        CreateRoomButton.onClick.AddListener(OnCreateRoomButtonClick);
    }

    private void OnRoomNameInputFieldValueChanged(string value)//ルーム名が1文字以上なければ作成不可となる
    {
        
        CreateRoomButton.interactable = (value.Length > 0);
    }

    private void OnCreateRoomButtonClick()
    {
        // ルーム作成処理中は、入力できないようにする
        //canvasGroup.interactable = false;
        PhotonNetwork.CreateRoom(
            null, // 自動的にユニークなルーム名を生成する
             new RoomOptions()
             {
                 MaxPlayers = 4,
                 CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() {
                                 { "DisplayName",RoomNameInput.text },//PhotonNetwork.NickName
                                 { "Message", MessageInput.text }
                     },
                 CustomRoomPropertiesForLobby = new[] { "DisplayName", "Message" }
             });
        //PhotonNetwork.JoinOrCreateRoom("Room" + , new RoomOptions(), TypedLobby.Default);
    }
    // ルームリストが更新された時に呼ばれるコールバック
    public override void OnRoomListUpdate(List<RoomInfo> roomList)//ルームの中にあるリストのデータを仮引数に入れる
    {
        foreach (var info in roomList)//var型の変数infoに、roomListの要素を順番に取り出して格納している。roomListの末尾データが出るまで繰り返す
        {

            RoomListEntry entry;
            if (activeEntries.TryGetValue(info.Name, out entry))
            {
               
                if (!info.RemovedFromList)
                {
                    // リスト要素を更新する
                    entry.Activate(info);//RoomListEntryのActivateでリスト更新　ついでにこのActivate関数は仮引数があるのにreturnで返さなくていいのが謎すぎ
                }
                else
                {
                    // リスト要素を削除する
                    activeEntries.Remove(info.Name);
                    entry.Deactivate();
                    inactiveEntries.Push(entry);
                }
            }
            else if (!info.RemovedFromList)
            {
                // リスト要素を追加する
                entry = (inactiveEntries.Count > 0)
                    ? inactiveEntries.Pop().SetAsLastSibling(): Instantiate(roomListEntryPrefab, scrollRect.content);//二者択一の値を返す　　左が謎すぎ　右は生成
                //StackクラスのPop()...データの取り出し　Push()...データの登録

                entry.Activate(info);//リスト更新
                activeEntries.Add(info.Name, entry);//activeEntriesのリストにinfo.Nameとentryクラスを加えている？？
            }
        }
    }

}