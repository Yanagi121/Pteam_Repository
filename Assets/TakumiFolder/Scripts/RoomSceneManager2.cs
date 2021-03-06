using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSceneManager2 : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    //private GameObject LobbyUI;//ロビーのUI
    //[SerializeField]
    //private GameObject enterMatchWaitRoomUI;//待機部屋のUI

    //[SerializeField]
    //private TextMeshProUGUI RoomNum;//部屋にいる人数の把握　未解決の

    //[SerializeField]
    //private TextMeshProUGUI PlayerName;

    //[SerializeField]
    //private TextMeshProUGUI joinedPlayer;

    //[SerializeField]
    //GameObject avatarName;
    [SerializeField] float delayMove = 0.1f;
    public bool enterMatchWaitRoomJudge;
    public static bool CameFind;
    [SerializeField] GameObject Player;
    public static bool SceneEnter = false; //ゲームシーンに入ったときに呼ばれる関数　

    private void Start()
    {
        Invoke("Progress", delayMove);
        // avatarNameDisplay = avatarName.GetComponent<AvatarNameDisplay>();
        // PhotonNetwork.LocalPlayer.NickName = "Player" + avatarNameDisplay.nameLabel.text;//Avatarプレハブ（ネットワークオブジェクト）で作られたプレイヤーの名前を受け取り、Instantiateした際には変更を読み取る
        PhotonNetwork.IsMessageQueueRunning = true;
        ////要確認/// Invoke("CameraFind", 0.0f);//0.5f後に呼び出される必要性　確認 
        CameraFind();//↓代替
        SceneEnter = true;
        Player = GameObject.Find("Player" + RoomSceneManager.Porder);//プレイヤーを取得し初期移動
        Player.transform.position = new Vector3(167, 17, 197);
        CameraMove.GamePlayer = GameObject.Find("Player" + RoomSceneManager.Porder);//プレイヤー名のついたオブジェクトをCameraMoveが取得
    }

    // マスターサーバーへの接続が成功したら、ロビーに参加する
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;

    }

    public void Update()
    {
      //  RoomNum.text = PhotonNetwork.CountOfPlayersInRooms + "/" + PhotonNetwork.CountOfPlayers;
        // Debug.Log(PhotonNetwork.CountOfRooms);
        //UpdateMemberList();
    }
    void Progress()
    {
          CameraMove.TimeDelay = true;
    }



    public override void OnJoinedLobby()//検証用
    {
        Debug.Log("ロビーに参加");
      //  LobbyUI.SetActive(true);
      //  enterMatchWaitRoomUI.SetActive(false);
    }
    public override void OnJoinedRoom()//ローカルプレイヤーのみに反応
    {
        Debug.Log("待機ルームに参加");
        //  LobbyUI.SetActive(false);
        //  enterMatchWaitRoomUI.SetActive(true);
        //GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(176, 30, 262), Quaternion.identity) as GameObject;
        ///////////////////////////////////////////////////////////絶対修正
        //if (PhotonNetwork.IsMasterClient)
        //{
        //    Debug.Log("自身がマスタークライアントです");
        //    player.name = "Player" + 1;
        //}
        //else
        //{
        //    Debug.Log("自身がローカルプライヤーです");
        //    player.name = "Player" + 2;
        //}
        /////////////////////////////////////////////////////////////
        // PhotonNetwork.Instantiate("Avatar", new Vector3(0, 0, 0), Quaternion.identity);//他のネットワークオブジェクトがダメだったので可視化されているこれで確認したが駄目だった
        //Debug.Log("ルームに入ってない人"+PhotonNetwork.CountOfPlayersOnMaster);　未解決
        //Debug.Log("ルームに入っている人" + PhotonNetwork.CountOfPlayersInRooms); 未解決
    }



    public void OnPhotonPlayerConnected()
    {
        // Debug.Log(player.name + " is joined.");
        //UpdateMemberList();
    }
    //public void UpdateMemberList()
    //{
    //    joinedPlayer.text = "";
    //    foreach (var p in PhotonNetwork.PlayerList)
    //    {
    //        joinedPlayer.text += p.NickName + "\n";
    //        //PhotonNetwork.Instantiate("PlayerName", new Vector3(0, 0, 0), Quaternion.identity);
    //    }
    //}
    public override void OnLeftRoom()
    {
        Debug.Log("待機ルームから退出");
       // LobbyUI.SetActive(true);
       // enterMatchWaitRoomUI.SetActive(false);
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

    private void CameraFind()
    {
        CameFind = true;
    }
}



