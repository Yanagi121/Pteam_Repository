using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

//MonoBehaviourPunCallbacksを継承し、Photonのコールバックを受け入れるようにする
public class SampleScenes : MonoBehaviourPunCallbacks    
{
    void Start()
    {
        //PhotonSereverSettingsに設定した内容を使ってマスターサーバーへ接続する

        PhotonNetwork.ConnectUsingSettings();

        PhotonNetwork.SerializationRate = 10;
        PhotonNetwork.UseRpcMonoBehaviourCache = true;
        // PhotonNetwork.LocalPlayer.NickName = "Player";
        // PhotonNetwork.playerName = "guest" + UnityEngine.Random.Range(1000, 9999);
        SceneManager.LoadScene("RoomScene");
    }

    //マスターサーバー(プレイヤーがマッチングを行う、ロビーのようなもの)への接続が成功した際に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        string displayName = $"{PhotonNetwork.NickName}の部屋";
        PhotonNetwork.JoinOrCreateRoom("room", GameRoomProperty.CreateRoomOptions(displayName), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        var v = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("GamePlayer", v, Quaternion.identity);        //ネットワークオブジェクトを作るために必要な手順の一つ
        //現在のサーバー時刻を、ゲームの開始時刻に設定する
        if (PhotonNetwork.IsMasterClient && !PhotonNetwork.CurrentRoom.HasStartTime())
        {
            PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
        }
    }

    //他のプレイヤーが参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.Log(player.NickName + "が参加しました");
    }

    //他のプレイヤーが退出したときに呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log(player.NickName + "が退出しました");
    }

    //自信はないがルーム型マッチングに必要なスクリプトが入ると思われる場所　理由:継承でMonoBehaviourPunCallbacksを
    //継承していること、マスターサーバー関連の記述されているのもこのスクリプトであるから  あとそもそも上に同じメソッドがある
    //ちがった

    
}
