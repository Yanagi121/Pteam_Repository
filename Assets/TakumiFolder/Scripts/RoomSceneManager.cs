using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

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

    [SerializeField] int num = 0;
    [SerializeField] int num2;

    [SerializeField] GameObject Camera1;
    //[SerializeField] GameObject Camera2;
    //[SerializeField] GameObject Camera3;
    //[SerializeField] GameObject Camera4;

    [SerializeField] GameObject PlayerClone;//インスペクターに表示される生成されたプレハブの名前

    string p;

    [SerializeField] int p1;
    public static int Porder;//プレイヤーの順番

    [SerializeField] List<int> Pnum;
    [SerializeField] bool Pbool;
    [SerializeField] int[] PN = { 0, 0, 0, 0 };

    [SerializeField] int RoomNumber;

    public static bool OneTime = true;

    [SerializeField] bool JoinRoom;
    [SerializeField] GameObject OtherPlayerClone1;
    [SerializeField] GameObject OtherPlayerClone2;
    [SerializeField] GameObject OtherPlayerClone3;
    [SerializeField] GameObject OtherPlayerClone4;
    [SerializeField] int changenum1,changenum2,changenum3,changenum4=0;//プレイヤーのクローンの名前を変えた回数

    //  private string id;
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

        //num = photonView.OwnerActorNr % 4;
        // Pbool = Pnum.Contains(4);
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
       
        JoinRoom = true;//メンバーリストの更新時かつルームに入ったときのみOneTimeでプレイヤープレハブに名前を付けて名前の変換を行うため
        Debug.Log("待機ルームに参加");
        LobbyUI.SetActive(false);
        enterMatchWaitRoomUI.SetActive(true);
        Invoke("CloneNameConversion", 0.5f);//ここはPorderが1以外のときに行われる　最初に部屋を作った人は必ずnullが出てしまう
        // photonView.RPC(nameof(AISATU), RpcTarget.AllBuffered, "こんにちは");
        //PhotonNetwork.Instantiate("NewPlayer", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);
        //PhotonNetwork.Instantiate("MainCamera", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);
        PlayerClone = PhotonNetwork.Instantiate("NewPlayer", new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity);

        
        //OtherPlayerClone = GameObject.Find("NewPlayer(Clone)");
        //player.name = "Player" + Porder;

        //// Camera.SetActive(true);
        //  Instantiate(Camera1, new Vector3(Random.Range(160, 180), 30, Random.Range(250, 270)), Quaternion.identity) ;
        //プレイヤーのプレハブのタグ名を統一？　適応がされるか要確認　適応された場合はプレイヤープレハブタグがついたオブ軸とから逃げる操作を実装する
        Photon.Realtime.Player player2 = PhotonNetwork.LocalPlayer;
        // Debug.Log("PlayerNo" + player2.ActorNumber);
        p1 = player2.ActorNumber;


        // photonView.RPC(nameof(PlayerNameShare), RpcTarget.AllBuffered, player.name);


        //camera.name = PhotonNetwork.LocalPlayer.NickName+"Camera";

        ///////////////////////////////////////////////////////////　　マスタークライアントが抜けてしまった場合を想定していないため要修正
        if (PhotonNetwork.IsMasterClient)
        {
            // Debug.Log("自身がマスタークライアントです");
            GoButton.SetActive(true);
            // player.name = "Player1";
            // camera.name = "Camera1";
        }
        else
        {
            // Debug.Log("自身がローカルプライヤーです");
            GoButton.SetActive(false);
            // player.name = "Player2";
        }
    }
    public override void OnPlayerEnteredRoom(Player player)//ここで変数の同期が行われる 参加した本人は行われない
    {
        //PlayerPrefab.name = "Player" + Porder;
        // Camera1.SetActive(true);
        // Debug.Log("OnPlayerEnteredRoomのPorder:"+Porder);
        Invoke("CloneNameConversion", 0.5f);//OnPlayerEnteredよりも先にUpdateMemberListが先に行われているため、0.5f遅らせてクローンの取得ができるようにしている

    }

    private void CloneNameConversion()
    {
        if (Porder == 1)
        {
            switch (changenum1) //行われるごとに回数が増える
            {
                case 0:break;//まだクローンがないため
                case 1:
                    OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone2.name = "Player2";//2人目が入ったときに名前のついてないクローンにPlayer2を振り当てる
                    break;
                case 2:
                    OtherPlayerClone3 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone3.name = "Player3";//3人目が入ったときに名前のついてないクローンにPlayer3を振り当てる
                    break;
                case 3:
                    OtherPlayerClone4 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone4.name = "Player4";//4人目が入ったときに名前のついてないクローンにPlayer4を振り当てる
                    break;
            }
            changenum1++;
        }//Porder1の同期が完了　自身の同期はまだ

        if(Porder==2)
        {
            
            switch (changenum2) //行われるごとに回数が増える
            {
                case 0:
                    OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone1.name = "Player1";//2人目が入ったときに名前のついてないクローンにPlayer2を振り当てる
                    break;
                case 1:
                    OtherPlayerClone3 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone3.name = "Player3";//3人目が入ったときに名前のついてないクローンにPlayer3を振り当てる
                    break;
                case 2:
                    OtherPlayerClone4 = GameObject.Find("NewPlayer(Clone)");
                    OtherPlayerClone4.name = "Player4";//4人目が入ったときに名前のついてないクローンにPlayer4を振り当てる
                    break;
            }
            changenum2++;
        }
        if (Porder == 3)
        {
            for(int i = 0; i < 2; i++)//すでにいるプレイヤー1,2の取得
            {
                switch (changenum3) //行われるごとに回数が増える
                {
                    case 0:
                        OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone1.name = "Player1";//1人目が入ったときに名前のついてないクローンにPlayer2を振り当てる
                        break;
                    case 1:
                        OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone2.name = "Player2";//2人目が入ったときに名前のついてないクローンにPlayer3を振り当てる
                        break;
                    case 2:
                        OtherPlayerClone4 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone4.name = "Player4";//4人目が入ったときに名前のついてないクローンにPlayer4を振り当てる
                        break;
                }
                changenum3++;
            }
            
        }
        if (Porder == 4)//switchやelse if だと片方しか行われないためifにした？？
        {
            for (int i = 0; i < 3; i++)//すでにいるプレイヤー1,2,3の取得
            {

                switch (changenum4) //行われるごとに回数が増える
                {
                    case 0:
                        OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone1.name = "Player1";//1人目が入ったときに名前のついてないクローンにPlayer2を振り当てる
                        break;
                    case 1:
                        OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone2.name = "Player2";//2人目が入ったときに名前のついてないクローンにPlayer3を振り当てる
                        break;
                    case 2:
                        OtherPlayerClone3 = GameObject.Find("NewPlayer(Clone)");
                        OtherPlayerClone3.name = "Player3";//3人目が入ったときに名前のついてないクローンにPlayer4を振り当てる
                        break;
                }
                changenum4++;
            }
        }
    }



    public void UpdateMemberList()
    {
        num = 0;
        joinedPlayer.text = "";

        foreach (var p in PhotonNetwork.PlayerList)
        {
            joinedPlayer.text += p.NickName + "\n";
            // Pnum.Insert(num,p.ActorNumber);
            Pnum[num] = p.ActorNumber;  //空の配列にIDを入れていく
            num++;
            //PhotonNetwork.Instantiate("PlayerName", new Vector3(0, 0, 0), Quaternion.identity);
        }
        for (int i = 0; i < Pnum.Count; i++)
        {
            if (p1 == Pnum[i]) { Porder = i + 1; }//プレイヤーがルーム内に入ったときのIDが現在の
        }
        if (JoinRoom == true)//部屋に参加したときに限る
        {
            if (OneTime)
            {
                //photonView.RPC(nameof(RoomID), RpcTarget.AllBuffered, PlayerPrefab); 
                PlayerClone.name = "Player" + Porder;
                OneTime = false;
                //Debug.Log("aaaaaa");
                Camera1.SetActive(true);
                Debug.Log("Porder:" + Porder);
                OtherPlayerClone1 = GameObject.Find("NewPlayer(Clone)");//自分目線のみでの変更
                if (Porder == 1)
                {
                  //　 OtherPlayerClone2 = GameObject.Find("NewPlayer(Clone)");
                  //  OtherPlayerClone2.name = "Player1";
                    //
                }
            }
        }

        //Debug.Log("プレイヤー"+Porder);
        // Debug.Log(num);
    }
    public override void OnLeftRoom()
    {
        JoinRoom = false;//部屋に入った際の一度のみで行えるようにするため
        OneTime = true;//もう一度行えるようにするため
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
    private void RoomID(GameObject playerprefab)
    {
        Debug.Log("Porder:" + Porder);
        playerprefab.name = "Player" + Porder;
    }
    [PunRPC]
    private void AISATU(string s)
    {
        Debug.Log(s);
    }



    //[PunRPC]
    //private void PlayerNameShare(string p) 
    //{
    //    switch (p)
    //    {
    //        case "Player1":break;
    //        case "Player2": break;
    //        case "Player3": break;
    //        case "Player4": break;
    //    }
    //}

}



