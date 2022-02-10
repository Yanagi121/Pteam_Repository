using Photon.Pun;
using TMPro;
using UnityEngine;

// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI nameLabel;
    private void Start()
    {
        // �v���C���[���ƃv���C���[ID��\������
        nameLabel.text =$" {photonView.Owner.NickName}{photonView.OwnerActorNr}";
        //RpcSendMessage("����ɂ���");
        //photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, "����ɂ���");

    }
    //[PunRPC]
    //private void RpcSendMessage(string message)
    //{
    //    Debug.Log(message);
    //}
}
