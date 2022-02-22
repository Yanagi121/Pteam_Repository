using Photon.Pun;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameRoomHUD : MonoBehaviour
{
    private TextMeshProUGUI timeLabel;
    private void Awake()
    {
        timeLabel = GetComponent<TextMeshProUGUI>();
    }

    private  void Update()
    {
        //まだルームに参加してないときは更新しない
        if(!PhotonNetwork.InRoom){ return; }
        //まだ開始時刻が設定されてないときは更新しない
        if(!PhotonNetwork.CurrentRoom.TryGetStartTime(out int timestamp)) { return; }

        //ゲーム開始時刻からの経過時間を求めて、テキストに表示する
        float elapsedTime=Mathf.Max(unchecked(PhotonNetwork.ServerTimestamp-timestamp)/1000f);
        timeLabel.text = elapsedTime.ToString("f2");//小数点以下2桁表示
    }
}
