using UnityEngine;

namespace Commons
{
    /// <summary>
    ///  画面のタップ判定を無効にするために被せるブロッキングのView
    /// </summary>
    public class BlockingView : MonoBehaviour
    {
        /// <summary>
        /// 表示
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// 非表示
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
