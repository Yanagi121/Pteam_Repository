namespace Commons.Const
{
    public static class InGameConst
    {
        // (+α)
        // レベルデザインに関係がある項目はSerializedObjectとかで外出しする実装にすると、
        // ステージ増やしやすくなったり、設定を弄りやすくなったりします。

        /// <summary>
        /// 画面縦幅（画面サイズは縦固定）
        /// </summary>
        public const float WindowHeight = 1334;

        /// <summary>
        /// 地面の高さ
        /// </summary>
        public const float GroundHeight = 755;

        /// <summary>
        /// 移動の速度
        /// </summary>
        public const float MoveSpeed = 285f;

        /// <summary>
        /// パイプの横幅
        /// </summary>
        public const float BombWidth = 40;

        /// <summary>
        /// パイプのスペース幅
        /// </summary>
        public const float BombSpace = 350f;

        /// <summary>
        /// パイプの横間隔
        /// </summary>
        public const float BombDistance = 500f;

        /// <summary>
        /// パイプの高さの最小値
        /// </summary>
        public const float BombMinHeight = 120f;

        /// <summary>
        /// プレイヤーの開始時のY座標
        /// </summary>
        public const float PlayerStartY = 700f;

        /// <summary>
        /// プレイヤーの開始演出中のY座標の下限値
        /// </summary>
        public const float PlayerReadyBottomLimitY = 600f;

        /// <summary>
        /// プレイヤーの加速度
        /// </summary>
        public const float PlayerSpeedAccelerate = -4000f;

        /// <summary>
        /// プレイヤーの角加速度
        /// </summary>
        public const float PlayerAngleSpeedAccelerate = -1000f;

        /// <summary>
        /// プレイヤーの上昇時の初速度
        /// </summary>
        public const float PlayerUpInitialSpeed = 1200f;

        /// <summary>
        /// プレイヤーの上昇時の初角速度
        /// </summary>
        public const float PlayerUpInitialAngleSpeed = 1000f;

        /// <summary>
        /// プレイヤーの下を向き始めるのを待機する時間
        /// </summary>
        public const float PlayerAngleDownWaitTime = 0.4f;

        /// <summary>
        /// プレイヤーの角度の最大値
        /// </summary>
        public const float PlayerMaxAngle = 40f;

        /// <summary>
        /// プレイヤーの角度の最小値
        /// </summary>
        public const float PlayerMinAngle = -80f;

        /// <summary>
        /// プレイヤーの当たり判定の半径
        /// </summary>
        public const float PlayerHitRadius = 40f;

        /// <summary>
        /// １回につき加算されるスコア
        /// </summary>
        public const int AdditionalScore = 1;
    }
}