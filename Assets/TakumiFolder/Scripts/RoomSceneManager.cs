using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Button BackLobbyButton = default;
    [SerializeField]
    private TextMeshProUGUI Player = default;

    [SerializeField]
    private GameObject LobbyUI;//ロビーのUI
    [SerializeField]
    private GameObject enterMatchWaitRoomUI;//待機部屋のUI

    [SerializeField]
    private Text RoomNum;

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

    private void Update()
    {
        RoomNum.text = PhotonNetwork.CountOfPlayersInRooms + "/" + PhotonNetwork.CountOfPlayers;
       // Debug.Log(PhotonNetwork.CountOfRooms);
    }

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
        PhotonNetwork.Instantiate("Avatar", new Vector3(0, (PhotonNetwork.CountOfPlayersInRooms+1) * 100, 0), Quaternion.identity);//本来生成・破壊は望ましくないと思うので、時間があったら表示・非表示設定にしておきたい
        Debug.Log("ルームに入ってない人"+PhotonNetwork.CountOfPlayersOnMaster);
        Debug.Log("ルームに入っている人" + PhotonNetwork.CountOfPlayersInRooms);
    }
    public override void OnLeftRoom()
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
