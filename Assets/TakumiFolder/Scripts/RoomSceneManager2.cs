using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomSceneManager2 : MonoBehaviourPunCallbacks
{
    [SerializeField] float delayMove = 0.1f;
    public bool enterMatchWaitRoomJudge;
    public static bool CameFind;
    [SerializeField] GameObject Player;
    public static bool SceneEnter = false; //ゲームシーンに入ったときに呼ばれる関数　
    [SerializeField] GameObject[] players=new GameObject [4];

    private void Start()
    {
        //Debug.developerConsoleVisible = false;
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
        for(int i = 0; i < 4; i++)
        {
            players[i].SetActive(false);
        }
    }

    // マスターサーバーへの接続が成功したら、ロビーに参加する
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;
    }

    public void Update()
    {
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
    // 他プレイヤーが退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log(player.NickName + "が退出しました");
        //switch (RoomSceneManager.Porder)
        //{
        //    case 1:players[0].SetActive(true);break;
        //    case 2:players[1].SetActive(true);break;
        //    case 3:players[2].SetActive(true);break;
        //    case 4:players[3].SetActive(true);break;
        //    default:break;     
        //}
    }
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



