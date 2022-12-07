using System;

namespace Commons.Enum
{
    public static class InGameEnum
    {
        /// <summary>
        /// 状態
        /// </summary>
        [Flags]
        public enum State
        {
            None       = 0,
            WaitStart  = 1,      // 開始待ち
            Move        = 1 << 1, // 飛行中
            Hit        = 1 << 2, // パイプへの衝突
            Falling    = 1 << 3, // パイプへの衝突後の墜落中
            Dead       = 1 << 4, // 墜落（地面への衝突）

            AlreadyHit = Hit | Falling | Dead, // 既に衝突済み
        }
    }
}