using Photon.Pun;
using TMPro;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI nameLabel;
    public void Start()
    {
        // プレイヤー名とプレイヤーIDを表示する
        nameLabel.text =""+photonView.OwnerActorNr;
        Debug.Log("ネットワークオブジェクトを用いたUserのid取得:"+nameLabel.text);
    }
}
