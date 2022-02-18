using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject LobbyUI;//ロビーのUI
    [SerializeField]
    private GameObject enterMatchWaitRoomUI;//待機部屋のUI

    [SerializeField]
    private TextMeshProUGUI RoomNum;//部屋にいる人数の把握　未解決の

    [SerializeField]
    private TextMeshProUGUI PlayerName;

    [SerializeField]
    private TextMeshProUGUI joinedPlayer;

    [SerializeField]
    GameObject avatarName;
   

    [SerializeField] 
    private GameObject GoButton;//マスタークライアント以外はGOボタンが押せない

    [SerializeField]
    private int PlayerNum;

    public bool enterMatchWaitRoomJudge;

    [SerializeField]int num;
    [SerializeField] int num2;

    [SerializeField] GameObject Camera1;
    [SerializeField] GameObject Camera2;
    [SerializeField] GameObject Camera3;
    [SerializeField] GameObject Camera4;

    GameObject player;

    //  private string id;
    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LocalPlayer.NickName = "Player"+ Random.Range(1, 1000);//Avatarプレハブ（ネットワークオブジェクト）で作られたプレイヤーの名前を受け取り、Instantiateした際には変更を読み取る
        PhotonNetwork.IsMessageQueueRunning = true;
        CameraMove.transCamera = Camera.main.transform;
        Camera1.SetActive(false);
        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);

    }

    // マスターサーバーへの接続が成功したら、ロビーに参加する
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;
        
    }

    public void Update()
    {
        RoomNum.text = PhotonNetwork.CountOfPlayersInRooms + "/" + PhotonNetwork.CountOfPlayers;
        // Debug.Log(PhotonNetwork.CountOfRooms);
        UpdateMemberList();
    }

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

        //PhotonNetwork.Instantiate("NewPlayer", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);
        //PhotonNetwork.Instantiate("MainCamera", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);
         player=PhotonNetwork.Instantiate("NewPlayer", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity) ;
        //  Instantiate(Camera1, new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity) ;
        //プレイヤーのプレハブのタグ名を統一？　適応がされるか要確認　適応された場合はプレイヤープレハブタグがついたオブ軸とから逃げる操作を実装する
        photonView.RPC(nameof(RoomID), RpcTarget.AllBuffered, num);
        

        //camera.name = PhotonNetwork.LocalPlayer.NickName+"Camera";

        ///////////////////////////////////////////////////////////絶対修正
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("自身がマスタークライアントです");
            GoButton.SetActive(true);
           // player.name = "Player1";
           // camera.name = "Camera1";
        }
        else
        {
            Debug.Log("自身がローカルプライヤーです");
            GoButton.SetActive(false);
           // player.name = "Player2";
        }
        /////////////////////////////////////////////////////////////
        // PhotonNetwork.Instantiate("Avatar", new Vector3(0, 0, 0), Quaternion.identity);//他のネットワークオブジェクトがダメだったので可視化されているこれで確認したが駄目だった
        //Debug.Log("ルームに入ってない人"+PhotonNetwork.CountOfPlayersOnMaster);　未解決
        //Debug.Log("ルームに入っている人" + PhotonNetwork.CountOfPlayersInRooms); 未解決
    }

    

    public void OnPhotonPlayerConnected()
    {
       // Debug.Log(player.name + " is joined.");
        UpdateMemberList();
    }
    public void UpdateMemberList()
    {
        num=0;
        joinedPlayer.text = "";

        foreach (var p in PhotonNetwork.PlayerList)
        {
            joinedPlayer.text += p.NickName + "\n";
            num++;
            //PhotonNetwork.Instantiate("PlayerName", new Vector3(0, 0, 0), Quaternion.identity);
        }
        Debug.Log("プレイヤー"+joinedPlayer);
        //Debug.Log(num);
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

    [PunRPC]
    private void RoomID(int num)
    {
        switch (num)
        {
            case 0: player.name = "Player1"; Camera1.SetActive(true); break;
            case 1: player.name = "Player2"; Camera2.SetActive(true); break;
            case 2: player.name = "Player3"; Camera3.SetActive(true); break;
            case 3: player.name = "Player4"; Camera4.SetActive(true); break;
            default: Debug.Log("人数超過・エラー"); break;
        }
    }
}



