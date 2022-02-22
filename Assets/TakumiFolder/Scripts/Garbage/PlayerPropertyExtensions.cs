using Photon.Realtime;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public static class PlayerPropertyExtensions
{
    private const string PLAYER_ASSIGN_NUMBER = "n";

    private static Hashtable _hashtable = new Hashtable();

    //����������������������������������������������������������������������������������
    //�@�v���C���[�̔ԍ�
    //����������������������������������������������������������������������������������

    //Hashtable�Ƀv���C���[�Ɋ���U��ꂽ�ԍ�������Ύ擾����
    private static bool TryAndGetPlayerNum(this Hashtable hashtable, out int playerAssignNumber)
    {
        if (hashtable[PLAYER_ASSIGN_NUMBER] is int value)
        {
            playerAssignNumber = value;
            return true;
        }

        playerAssignNumber = 0;
        return false;
    }

    //�v���C���[�ԍ����擾����
    public static int GetPlayerNum(this Player player)
    {
        player.CustomProperties.TryAndGetPlayerNum(out int playerNum);
        return playerNum;
    }

    //�v���C���[�̊��蓖�Ĕԍ��̃J�X�^���v���p�e�B���X�V����
    public static void UpdatePlayerNum(this Player player, int assignNum)
    {
        _hashtable[PLAYER_ASSIGN_NUMBER] = assignNum;
        player.SetCustomProperties(_hashtable);
        _hashtable.Clear();
    }
}