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
        //�܂����[���ɎQ�����ĂȂ��Ƃ��͍X�V���Ȃ�
        if(!PhotonNetwork.InRoom){ return; }
        //�܂��J�n�������ݒ肳��ĂȂ��Ƃ��͍X�V���Ȃ�
        if(!PhotonNetwork.CurrentRoom.TryGetStartTime(out int timestamp)) { return; }

        //�Q�[���J�n��������̌o�ߎ��Ԃ����߂āA�e�L�X�g�ɕ\������
        float elapsedTime=Mathf.Max(unchecked(PhotonNetwork.ServerTimestamp-timestamp)/1000f);
        timeLabel.text = elapsedTime.ToString("f2");//�����_�ȉ�2���\��
    }
}
