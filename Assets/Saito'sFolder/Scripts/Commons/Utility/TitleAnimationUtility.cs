using Commons.Const;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Commons.Utility
{
    /// <summary>
    /// タイトルのアニメーションのUtilityクラス
    /// </summary>
    public static class TitleAnimationUtility
    {
        //TODO:Fadeのtweenを良く使うのでAnimationUtilityクラスとして分け、細分化する
        //TODO:durationを公開して、調整しやすいようにする
        
        /// <summary>
        /// フェードアウトのTween
        /// </summary>
        public static Tween PanelFadeOutTween(Image panel)
        {
           return panel.DOFade(0f, InGameConst.FadeAnimationDuration)
               .SetEase(Ease.Linear).OnComplete(() => { Debug.Log("フェードアウトが完了しました"); });
        }
        
        /// <summary>
        /// フェードインのTween
        /// </summary>
        public static Tween TransitionEffectTween(Image panel,Subject<Unit> OnCallback)
        {
            return panel.DOFade(1.0f, InGameConst.FadeAnimationDuration)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallback.OnNext(Unit.Default);
                });
        }

        /// <summary>
        /// フェードインを繰り返すTween
        /// </summary>
        public static Tween FadeImageLoopTween(Image image)
        {
            return image.DOFade(0.0f, 1f)
                .SetEase(Ease.InCubic).SetLoops(-1, LoopType.Yoyo);
        }
    }
}