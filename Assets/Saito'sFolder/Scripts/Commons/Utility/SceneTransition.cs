using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Commons.Utility
{
    /// <summary>
    /// シーン遷移を行うUtilityクラス
    /// </summary>
    public static class SceneTransition
    {
        /// <summary>
        /// シーンを遷移する(Addressable方式)
        /// </summary>
        public static async UniTask LoadScene(AssetReference scene,Action CallBack=default)
        {
            await scene.LoadSceneAsync().Task;
            CallBack?.Invoke();
        }
    }
}