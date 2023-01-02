namespace Commons.Const
{
    //TODO:インゲームなのに他のシーンでも使われているので、細かく分ける
    /// <summary>
    /// インゲームの定数
    /// </summary>
    public static class InGameConst
    {
        //本来ならインスペクタで調整出来た方が良いかも
        
        //疑似Enum
        /// <summary>
        /// 
        /// </summary>
        public const float ARTICLE_LEFT=0.0f;
            
        /// <summary>
        /// 
        /// </summary>
        public const float ARTICLE_CENTER=1.0f;
            
        /// <summary>
        /// 
        /// </summary>
        public const float ARTICLE_RIGHT=2.0f;
        
        /// <summary>
        /// 
        /// </summary>
        public const float LeftArticleX = 1280.0f;

        /// <summary>
        /// 
        /// </summary>
        public const float CenterArticleX = 0.0f;
        
        /// <summary>
        /// 
        /// </summary>
        public const float RightArticleX = -1280.0f;

        /// <summary>
        /// フェードイン・アウトの時間
        /// </summary>
        public const float FadeAnimationDuration = 0.5f;
        
        /// <summary>
        /// ロゴを拡大・縮小するさいの時間
        /// </summary>
        public const float LogoAnimationDuration = 2.0f;
    }
}