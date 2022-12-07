using UnityEngine;

namespace Commons
{
    /// <summary>
    /// MonoBehaviourを継承したSingletonクラス
    /// </summary>
    public abstract class SingletonMonoBehaviour<T>
                            : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static T _instance;

        /// <summary>
        /// シングルトンインスタンス取得
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        //DebugUtility.LogError(typeof(T) + "をアタッチしているGameObjectはありません");
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// Awake
        /// </summary>
        protected virtual void Awake()
        {
            // 他のGameObjectにアタッチされている場合は破棄する
            if (this != Instance)
            {
                Destroy(this);
            }
        }
    }
}
