using UnityEngine;

namespace Commons
{
    /// <summary>
    /// 画面のタップ判定を無効にするために被せるブロッキングを管理するManager
    /// </summary>
    public class BlockingManager : SingletonMonoBehaviour<BlockingManager>
    {
        /// <summary>
        /// ブロッキング
        /// </summary>
        [SerializeField]
        private BlockingView _blockingView;

        /// <summary>
        /// ブロッキング表示
        /// </summary>
        /// <returns>成功したかどうか</returns>
        public bool ShowBlocking()
        {
            if (Instance == null) return false;
            _blockingView.Show();
            return true;
        }

        /// <summary>
        /// ブロッキング非表示
        /// </summary>
        /// <returns>成功したかどうか</returns>
        public bool HideBlocking()
        {
            if (Instance == null) return false;
            _blockingView.Hide();
            return true;
        }
    }
}
