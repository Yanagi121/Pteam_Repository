using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomSceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject LobbyUI;//ロビーのUI

    [SerializeField]
    private GameObject enterMatchWaitRoomUI;//待機部屋のUI

    [SerializeField]
    private TextMeshProUGUI RoomNum;//部屋にいる人数の把握　未解決の

    [SerializeField]
    private TextMeshProUGUI joinedPlayer;

    [SerializeField]
    GameObject avatarName;

    [SerializeField]
    private GameObject PlayButton;//マスタークライアントのみGOボタンが押せる

    [SerializeField]
    private GameObject Readybutton;//マスタークライアント以外はReadyボタンが押せる

    [SerializeField]
    private GameObject CompletionButton;//準備ボタンが押された際に切り替わる

    [SerializeField]
    public bool enterMatchWaitRoomJudge;

    [SerializeField] int num = 0;

    [SerializeField] GameObject Camera1;

    [SerializeField] GameObject PlayerClone;//インスペクターに表示される生成されたプレハブの名前

    [SerializeField] int p1;

    public static int Porder;//プレイヤーの順番

    [SerializeField] List<int> Pnum;

    [SerializeField] int[] PN = { 0, 0, 0, 0 };

    public static bool OneTime = true;

    [SerializeField] bool JoinRoom;
    [SerializeField] Text PlayerNAME;

    // private bool EnterRoomOneTime = false;//一瞬最初に部屋に入ることでリストの更新を行って、シーン遷移後にRoomListの更新が行われるようにする

    private void Start()
    {
        // PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LocalPlayer.NickName = "Player" + Random.Range(1, 1000);//Avatarプレハブ（ネットワークオブジェクト）で作られたプレイヤーの名前を受け取り、Instantiateした際には変更を読み取る
        PhotonNetwork.IsMessageQueueRunning = true;
        CameraMove.transCamera = Camera.main.transform;
        Camera1.SetActive(false);
        Pnum.AddRange(PN);
        JoinRoom = false;
        Destroy(GameObject.Find("Cam2"));
    }

    // マスターサーバーへの接続が成功したら、ロビーに参加する
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        enterMatchWaitRoomJudge = false;
        // EnterRoomOneTime = true;
        Debug.Log("成功！");
    }

    public void Update()
    {
        RoomNum.text = PhotonNetwork.CountOfPlayersInRooms + "/" + PhotonNetwork.CountOfPlayers;
        UpdateMemberList();
        //if (EnterRoomOneTime == true)
        //{
        //    PhotonNetwork.JoinRandomOrCreateRoom();
        //    //PhotonNetwork.LeaveRoom();
        //    EnterRoomOneTime = false;
        //}
    }

    public override void OnJoinedLobby()//検証用
    {
        Debug.Log("ロビーに参加");
        LobbyUI.SetActive(true);
        enterMatchWaitRoomUI.SetActive(false);

    }

    public override void OnJoinedRoom()//ローカルプレイヤーのみに反応
    {
        JoinRoom = true;//メンバーリストの更新時かつルームに入ったときのみOneTimeでプレイヤープレハブに名前を付けて名前の変換を行うため
        Debug.Log("待機ルームに参加");
        Debug.Log("Player_Porder:" + Porder);
        LobbyUI.SetActive(false);
        enterMatchWaitRoomUI.SetActive(true);
        MasterClientJudge();

        // Invoke("CloneNameConversion", 0.5f);//ここはPorderが1以外のときに行われる　最初に部屋を作った人は必ずnullが出てしまう
        // PlayerClone = PhotonNetwork.Instantiate("NewPlayer", new Vector3( 170, 30, 200), Quaternion.identity);
        //プレイヤーのプレハブのタグ名を統一？　適応がされるか要確認　適応された場合はプレイヤープレハブタグがついたオブ軸とから逃げる操作を実装する
        Photon.Realtime.Player player2 = PhotonNetwork.LocalPlayer;
        p1 = player2.ActorNumber;
    }

    public override void OnPlayerEnteredRoom(Player player)//ここで変数の同期が行われる 参加した本人は行われない
    {
        //Invoke("CloneNameConversion", 0.5f);//OnPlayerEnteredよりも先にUpdateMemberListが先に行われているため、0.5f遅らせてクローンの取得ができるようにしている
        MasterClientJudge();
    }

    // 他プレイヤーが退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player player)
    {
        //PhotonNetwork.Destroy(PlayerClone);
        //if(Porder!=1) Porder--;
        Invoke(nameof(PlayerNum_Change), 0.5f);
        MasterClientJudge();
        Debug.Log("私の順番:" + Porder);
        //switch (Porder)
        //{
        //    case 1: changenum1 = 0; break;
        //    case 2: changenum2 = 0; break;
        //    case 3: changenum3 = 0; break;
        //    case 4: changenum4 = 0; break;
        //}
    }

    public void PlayerNum_Change()
    {
        if (GameObject.Find("Player1(Clone)"))
        {
            Debug.Log("Player1があります");
        }
        else
        {
            Debug.Log("Player1がありません。Porderは" + Porder);
            switch (Porder)
            {
                case 2: Porder = 1; break;
                case 3: Porder = 2; break;
                case 4: Porder = 3; break;
            }

        }

        if (GameObject.Find("Player2(Clone)"))
        {
            Debug.Log("Player2があります");
        }
        else
        {
            Debug.Log("Player2がありません。Porderは" + Porder);
            switch (Porder)
            {
                case 3: Porder = 2; break;
                case 4: Porder = 3; break;
            }
        }

        if (GameObject.Find("Player3(Clone)"))
        {
            Debug.Log("Player3があります");
        }
        else
        {
            Debug.Log("Player3がありません。Porderは" + Porder);
            if (Porder == 4)
            {
                Porder = 3;
            }
        }
        PhotonNetwork.Destroy(PlayerClone);
        PlayerClone = PhotonNetwork.Instantiate("Player" + Porder.ToString(), new Vector3(170 - Porder * 2.5f, 30, 200), Quaternion.identity);
    }

    //private void CloneNameConversion()
    //{
    //    Debug.Log("部屋内での割り当てが行われました");
    //    if (Porder == 1)//プレイヤーが入った際に自分のPorderが1であるとき
    //    {
    //        switch (changenum1) //行われるごとに回数が増える
    //        {
    //            case 0: break;//まだクローンがないため何も行わない
    //            case 1:
    //                OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
    //                OtherPlayerClone2.name = "Player2";//2人目が入ったときに名前のついてないクローンにPlayer2を振り当てる
    //                break;
    //            case 2:
    //                OtherPlayerClone3 = GameObject.Find("NewPlayer(Clone)");
    //                OtherPlayerClone3.name = "Player3";//3人目が入ったときに名前のついてないクローンにPlayer3を振り当てる
    //                break;
    //            case 3:
    //                OtherPlayerClone4 = GameObject.Find("NewPlayer(Clone)");
    //                OtherPlayerClone4.name = "Player4";//4人目が入ったときに名前のついてないクローンにPlayer4を振り当てる
    //                break;
    //        }
    //        changenum1++;
    //    }//Porder1の同期が完了　自身の同期はまだ

    //    if (Porder == 2)
    //    {
    //        switch (changenum2) //行われるごとに回数が増える //すでにいるプレイヤー1の取得
    //        {
    //            case 0:
    //                OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");
    //                OtherPlayerClone1.name = "Player1";//2人目が入ったときに名前のついてないクローンにPlayer2を振り当てる
    //                break;
    //            case 1:
    //                OtherPlayerClone3 = GameObject.Find("NewPlayer(Clone)");
    //                OtherPlayerClone3.name = "Player3";//3人目が入ったときに名前のついてないクローンにPlayer3を振り当てる
    //                break;
    //            case 2:
    //                OtherPlayerClone4 = GameObject.Find("NewPlayer(Clone)");
    //                OtherPlayerClone4.name = "Player4";//4人目が入ったときに名前のついてないクローンにPlayer4を振り当てる
    //                break;
    //        }
    //        changenum2++;
    //    }
    //    if (Porder == 3)
    //    {
    //        for (int i = 0; i < 2; i++)//すでにいるプレイヤー1,2の取得
    //        {
    //            switch (changenum3) //行われるごとに回数が増える
    //            {
    //                case 0:
    //                    OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");
    //                    OtherPlayerClone1.name = "Player1";//1人目が入ったときに名前のついてないクローンにPlayer2を振り当てる
    //                    break;
    //                case 1:
    //                    OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
    //                    OtherPlayerClone2.name = "Player2";//2人目が入ったときに名前のついてないクローンにPlayer3を振り当てる
    //                    break;
    //                case 2:
    //                    OtherPlayerClone4 = GameObject.Find("NewPlayer(Clone)");
    //                    OtherPlayerClone4.name = "Player4";//4人目が入ったときに名前のついてないクローンにPlayer4を振り当てる
    //                    break;
    //            }
    //            changenum3++;
    //        }

    //    }
    //    if (Porder == 4)//switchやelse if だと片方しか行われないためifにした？？
    //    {
    //        for (int i = 0; i < 3; i++)//すでにいるプレイヤー1,2,3の取得
    //        {

    //            switch (changenum4) //行われるごとに回数が増える
    //            {
    //                case 0:
    //                    OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");
    //                    OtherPlayerClone1.name = "Player1";//1人目が入ったときに名前のついてないクローンにPlayer2を振り当てる
    //                    break;
    //                case 1:
    //                    OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
    //                    OtherPlayerClone2.name = "Player2";//2人目が入ったときに名前のついてないクローンにPlayer3を振り当てる
    //                    break;
    //                case 2:
    //                    OtherPlayerClone3 = GameObject.Find("NewPlayer(Clone)");
    //                    OtherPlayerClone3.name = "Player3";//3人目が入ったときに名前のついてないクローンにPlayer4を振り当てる
    //                    break;
    //            }
    //            changenum4++;
    //        }
    //    }

    //}

    public void UpdateMemberList()
    {
        num = 0;
        joinedPlayer.text = "";

        foreach (var p in PhotonNetwork.PlayerList)
        {
            joinedPlayer.text += p.NickName + "\n";
            Pnum[num] = p.ActorNumber;  //空の配列にIDを入れていく
            num++;
        }
        for (int i = 0; i < Pnum.Count; i++)
        {
            if (p1 == Pnum[i]) { Porder = i + 1; }//プレイヤーがルーム内に入ったときのIDが現在の
        }
        if (JoinRoom == true)//部屋に参加したときに限る
        {
            if (OneTime)
            {
                //PlayerClone.name = "Player" + Porder;
                OneTime = false;
                Debug.Log(num);
                Camera1.SetActive(true);
                Debug.Log("私のPorder:" + Porder);
                //OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");//自分目線のみでの変更
                PlayerClone = PhotonNetwork.Instantiate("Player" + Porder.ToString(), new Vector3(170 - Porder * 2.5f, 30, 200), Quaternion.identity);
                // PlayerNAME = PlayerClone.GetComponentInChildren<Text>();
                //PlayerNAME.text = PhotonNetwork.LocalPlayer.NickName;
            }
        }
    }

    public override void OnLeftRoom()
    {
        JoinRoom = false;//部屋に入った際の一度のみで行えるようにするため
        OneTime = true;//もう一度行えるようにするため
        Debug.Log("待機ルームから退出");
        LobbyUI.SetActive(true);
        enterMatchWaitRoomUI.SetActive(false);
        //Camera1.SetActive(false);
    }

    public override void OnLeftLobby()
    {
        Debug.Log("ロビーから退出");
    }

    private void MasterClientJudge()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("自身がマスタークライアントです");
            PlayButton.SetActive(true);
            //   Readybutton.SetActive(false);
            //   CompletionButton.SetActive(false);
        }
        else
        {
            Debug.Log("自身がローカルプレイヤーです");
            PlayButton.SetActive(false);
            //   Readybutton.SetActive(true);
        }
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
}



