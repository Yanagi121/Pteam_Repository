using Photon.Pun;
using TMPro;
using UnityEngine;

// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI nameLabel;
    public void Start()
    {
        // �v���C���[���ƃv���C���[ID��\������
        nameLabel.text =""+photonView.OwnerActorNr;
        Debug.Log("�l�b�g���[�N�I�u�W�F�N�g��p����User��id�擾:"+nameLabel.text);
    }
}
