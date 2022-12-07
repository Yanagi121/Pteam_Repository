using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Commons.Utility
{
    public static class SceneTransition
    {
        public static async UniTask LoadScene(AssetReference scene,Action CallBack=null)
        {
            await scene.LoadSceneAsync().Task;
            CallBack?.Invoke();
        }
    }
}