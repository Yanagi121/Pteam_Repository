using Photon.Pun;
using TMPro;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI nameLabel;
    private void Start()
    {
        // プレイヤー名とプレイヤーIDを表示する
        nameLabel.text =$" {photonView.Owner.NickName}{photonView.OwnerActorNr}";
        //RpcSendMessage("こんにちは");
        //photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, "こんにちは");

    }
    //[PunRPC]
    //private void RpcSendMessage(string message)
    //{
    //    Debug.Log(message);
    //}
}
