using Photon.Pun;
using TMPro;
using UnityEngine;

// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField] public string nameLabel;
    public void Start()
    {
        // �v���C���[���ƃv���C���[ID��\������
        nameLabel =""+photonView.OwnerActorNr;
    }
}
