using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomSceneManager2 : MonoBehaviourPunCallbacks
{
    [SerializeField] float delayMove=5;//ゲーム開始時の停止時間の指定が可能

    public bool enterMatchWaitRoomJudge;
    public static bool CameFind;
    [SerializeField] GameObject Player;
    public static bool SceneEnter = false; //ゲームシーンに入ったときに呼ばれる関数　
    [SerializeField] GameObject[] players=new GameObject [4];

    private void Start()
    {
        //PhotonNetwork.LeaveLobby();
        Invoke("Progress", delayMove);
        PhotonNetwork.IsMessageQueueRunning = true;
        ////要確認/// Invoke("CameraFind", 0.0f);//0.5f後に呼び出される必要性　確認 
        CameraFind();//↓代替
        SceneEnter = true;
        Player = GameObject.Find("Player" + RoomSceneManager.Porder);//プレイヤーを取得し初期移動
        Player.transform.position = new Vector3(167, 17, 197);
        CameraMove.GamePlayer = GameObject.Find("Player" + RoomSceneManager.Porder);//プレイヤー名のついたオブジェクトをCameraMoveが取得
        for(int i = 0; i < 4; i++)
        {
            players[i].SetActive(true);
        }
    }


    // マスターサーバーへの接続が成功したら、ロビーに参加する
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"サーバーとの接続が切断されました: {cause.ToString()}");
    }

    void Progress()
    {
          CameraMove.TimeDelay = true;
    }

    public override void OnJoinedLobby()//検証用
    {
        Debug.Log("ロビーに参加");
    }

    public override void OnJoinedRoom()//ローカルプレイヤーのみに反応
    {
        Debug.Log("待機ルームに参加");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("ルーム内人数:" + (PhotonNetwork.CountOfPlayersInRooms + 1));
    }

    // 他プレイヤーが退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log(player.NickName + "が退出しました");
    }
    public override void OnLeftRoom()
    {
        Debug.Log("待機ルームから退出");
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



