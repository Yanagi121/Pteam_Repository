using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSceneManager : MonoBehaviourPunCallbacks
{
    private MatchwaitingRoomManager matchwaitingRoomManager;//ルームに参加したときにルームの名前をルーム内で表示させるため、下の変数から受け取る
    private RoomListView roomListView;//RoomListViewで受け取ったルーム名を、上の変数に受け渡すための変数

    [SerializeField]
    private Button BackLobbyButton = default;
    [SerializeField]
    private TextMeshProUGUI Player = default;

    [SerializeField]
    private GameObject LobbyUI;//ロビーのUI
    [SerializeField]
    private GameObject enterMatchWaitRoomUI;//待機部屋のUI

    //[SerializeField]private GameObject EnterMatchWaitroomObj;//シーン遷移後にルームに入った記録を残しておく用　//いったん没
    //private EnterMatchWaitRoom enterMatchWaitRoom;
    public bool enterMatchWaitRoomJudge;
    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        var localPlayer = PhotonNetwork.LocalPlayer;
        Debug.Log(localPlayer);//プレイヤー名は保存されている
        PhotonNetwork.NickName = "Player";
        var nameLabel = GetComponent<TextMeshPro>();
        //SceneManager.sceneLoaded += SceneLoaded;// イベントにイベントハンドラーを追加

    }

    // マスターサーバーへの接続が成功したら、ロビーに参加する
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;
        
    }

    //private void Update()
    //{
    //    if (enterMatchWaitRoomJudge == true)
    //    {
    //        PhotonNetwork.Instantiate("Avatar", new Vector3(0, 0, 0), Quaternion.identity);//本来生成・破壊は望ましくないと思うので、時間があったら表示・非表示設定にしておきたい
    //        enterMatchWaitRoomJudge = false;
    //    }
    //}

    //void SceneLoaded(Scene nextScene, LoadSceneMode mode)//シーンの切り替わりを検知させてenterMatchWaitRoomJudge = trueにし、プレイヤー名が出るようにする
    //{
    //    Debug.Log(nextScene.name);
    //    enterMatchWaitRoomJudge = true;
    //    Debug.Log(mode);
    //}

    public override void OnJoinedLobby()//検証用
    {
        Debug.Log("ロビーに参加");
        LobbyUI.SetActive(true);
        enterMatchWaitRoomUI.SetActive(false);
    }
    public override void OnJoinedRoom()//ローカルプレイヤーのみに反応
    {
        Debug.Log("待機ルームに参加");
        LobbyUI.SetActive(false);
        enterMatchWaitRoomUI.SetActive(true);
        PhotonNetwork.Instantiate("Avatar", new Vector3(0, 0, 0), Quaternion.identity);//本来生成・破壊は望ましくないと思うので、時間があったら表示・非表示設定にしておきたい
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("待機ルームから退出");
        LobbyUI.SetActive(true);
        enterMatchWaitRoomUI.SetActive(false);
    }

    // ルームの作成が成功した時に呼ばれるコールバック
    public override void OnCreatedRoom()
    {
        Debug.Log("ルーム作成に成功しました");
    }

    // ルームの作成が失敗した時に呼ばれるコールバック
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"ルーム作成に失敗しました: {message}");
    }

    public override void OnLeftRoom()
    {
        Debug.Log("ルームから退出しました");
    }

    ////他のプレイヤーが参加した時に呼ばれるコールバック
    //public override void OnPlayerEnteredRoom(Player player)
    //{
    //    Debug.Log(player.NickName + "が参加しました");
    //}

    ////他のプレイヤーが退出したときに呼ばれるコールバック
    //public override void OnPlayerLeftRoom(Player player)
    //{
    //    Debug.Log(player.NickName + "が退出しました");
    //}

}
