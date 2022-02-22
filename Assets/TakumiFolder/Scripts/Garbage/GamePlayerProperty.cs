using Photon.Realtime;
using Random = UnityEngine.Random;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public static class GamePlayerProperty
{
    private const string EnterNum = "EnterNum"; // �X�R�A�̃L�[�̕�����
    private const string HueKey = "Hue"; // �F���l�̃L�[�̕�����

    private static Hashtable hashtable = new Hashtable();

    // �iHashtable�Ɂj�v���C���[�̃X�R�A������Ύ擾����
    public static bool TryGetEnterNum(this Hashtable hashtable, out int enternum)
    {
        if (hashtable[EnterNum] is int value)
        {
            enternum = value;
            return true;
        }
        enternum = 0;
        return false;
    }

    // �v���C���[�̃X�R�A���擾����
    public static int GetEnterNum(this Player player)
    {
        player.CustomProperties.TryGetEnterNum(out int enternum);
        return enternum;
    }

    //�����ɓ������v���C���[�̃J�X�^���v���p�e�B���X�V����
    public static void OnDealEnterNum(this Player player)
    {
        hashtable[EnterNum] = player.GetEnterNum() ; // �X�R�A�𑝂₷

        player.SetCustomProperties(hashtable);
        hashtable.Clear();
    }

    // �iHashtable�Ɂj�v���C���[�̐F���l������Ύ擾����
    //public static bool TryGetHue(this Hashtable hashtable, out float hue)
    //{
    //    if (hashtable[HueKey] is float value)
    //    {
    //        hue = value;
    //        return true;
    //    }
    //    hue = -1f;
    //    return false;
    //}

    //// �v���C���[�̐F���l������Ύ擾����
    //public static bool TryGetHue(this Player player, out float hue)
    //{
    //    return player.CustomProperties.TryGetHue(out hue);
    //}

    //// �i����̒e�ɓ��������j�v���C���[�̃J�X�^���v���p�e�B���X�V����
    //public static void OnTakeDamage(this Player player)
    //{
    //    hashtable[HueKey] = Random.value; // �F���l�������_���ɕω�������

    //    player.SetCustomProperties(hashtable);
    //    hashtable.Clear();
    //}
}