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
            None = 0,
            ARTICLE_LEFT = 1,
            ARTICLE_CENTER = 2,
            ARTICLE_RIGHT = 3
        }
    }
}