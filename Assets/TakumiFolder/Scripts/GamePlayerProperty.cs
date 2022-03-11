using Photon.Realtime;
using Random = UnityEngine.Random;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public static class GamePlayerProperty
{
    private const string EnterNum = "EnterNum"; // スコアのキーの文字列
    private const string HueKey = "Hue"; // 色相値のキーの文字列

    private static Hashtable hashtable = new Hashtable();

    // （Hashtableに）プレイヤーのスコアがあれば取得する
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

    // プレイヤーのスコアを取得する
    public static int GetEnterNum(this Player player)
    {
        player.CustomProperties.TryGetEnterNum(out int enternum);
        return enternum;
    }

    //部屋に入ったプレイヤーのカスタムプロパティを更新する
    public static void OnDealEnterNum(this Player player)
    {
        hashtable[EnterNum] = player.GetEnterNum() ; // スコアを増やす

        player.SetCustomProperties(hashtable);
        hashtable.Clear();
    }

    // （Hashtableに）プレイヤーの色相値があれば取得する
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

    //// プレイヤーの色相値があれば取得する
    //public static bool TryGetHue(this Player player, out float hue)
    //{
    //    return player.CustomProperties.TryGetHue(out hue);
    //}

    //// （相手の弾に当たった）プレイヤーのカスタムプロパティを更新する
    //public static void OnTakeDamage(this Player player)
    //{
    //    hashtable[HueKey] = Random.value; // 色相値をランダムに変化させる

    //    player.SetCustomProperties(hashtable);
    //    hashtable.Clear();
    //}
}