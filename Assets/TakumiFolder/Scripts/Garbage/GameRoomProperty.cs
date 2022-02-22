using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public static class GameRoomProperty 
{
    private const string KeyDisplayName = "DisplayName";//�\���p���[�����̃L�[�̕�����
    private const string KeyStartTime = "StartTime";//�Q�[���J�n�����̃L�[�̕�����

    private static Hashtable hashtable = new Hashtable();

    //���[���̏����ݒ�I�u�W�F�N�g���쐬����
    public static RoomOptions CreateRoomOptions(string displayName)
    {
        return new RoomOptions()
        {
            //�J�X�^���v���p�e�B�̏����ݒ�
            CustomRoomProperties = new Hashtable()
            {
                {KeyDisplayName,displayName }
            },
            //���r�[����J�X�^���v���p�e�B���擾�ł���悤�ɂ���
            CustomRoomPropertiesForLobby = new string[]
            {
                KeyDisplayName
            }
        };
    }
    // �\���p���[�������擾����
    public static string GetDisplayName(this Room room)
    {
        return (string)room.CustomProperties[KeyDisplayName];
    }

    // �Q�[���J�n�������ݒ肳��Ă��邩���ׂ�
    public static bool HasStartTime(this Room room)
    {
        return room.CustomProperties.ContainsKey(KeyStartTime);
    }

    // �Q�[���J�n����������Ύ擾����
    public static bool TryGetStartTime(this Room room, out int timestamp)
    {
        if (room.CustomProperties[KeyStartTime] is int value)
        {
            timestamp = value;
            return true;
        }
        timestamp = 0;
        return false;
    }

    // �Q�[���J�n������ݒ肷��
    public static void SetStartTime(this Room room, int timestamp)
    {
        hashtable[KeyStartTime] = timestamp;

        room.SetCustomProperties(hashtable);
        hashtable.Clear();
    }
}
