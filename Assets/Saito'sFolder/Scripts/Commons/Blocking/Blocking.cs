using System;

namespace Commons
{
    /// <summary>
    /// 画面のタップ判定を無効にするために被せるブロッキングを展開する
    /// </summary>
    public class Blocking : IDisposable
    {
        /// <summary>
        /// Dispose済みかどうか
        /// </summary>
        private bool _isDisposed = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Blocking()
        {
            bool isSuccess = BlockingManager.Instance.ShowBlocking();
            if (isSuccess == false)
            {
                _isDisposed = true;
            }
        }

        /// <summary>
        /// Dispose処理
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed) return;
            _isDisposed = true;
            BlockingManager.Instance.HideBlocking();
        }
    }
}
