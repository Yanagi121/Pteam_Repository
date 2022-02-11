using Photon.Pun;
using TMPro;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、photonViewプロパティを使えるようにする
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField] public string nameLabel;
    public void Start()
    {
        // プレイヤー名とプレイヤーIDを表示する
        nameLabel =""+photonView.OwnerActorNr;
    }
}
