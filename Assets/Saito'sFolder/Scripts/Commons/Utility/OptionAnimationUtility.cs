using Commons.Const;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Commons.Utility
{
    /// <summary>
    /// オプションのアニメーションのUtilityクラス
    /// </summary>
    public static class OptionAnimationUtility 
    {
        /// <summary>
        /// フェードインのTween
        /// </summary>
        public static Tween FadeInTween(Image panel,Subject<Unit> OnCallBack)
        {
            return panel.DOFade(1.0f, InGameConst.FadeAnimationDuration)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallBack?.OnNext(Unit.Default);
                });
        }
        
        /// <summary>
        /// フェードアウトのTween
        /// </summary>
        public static Tween FadeOutTween(Image panel,Subject<Unit> OnCallBack)
        {
            return panel.DOFade(0.0f, InGameConst.FadeAnimationDuration)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallBack?.OnNext(Unit.Default);
                });
        }
        
        /// <summary>
        /// ボタン拡大のTween
        /// </summary>
        public static Tweener ButtonEnterTween(Button button)
        {
            return  button.transform.DOScale(
                Vector3.one * 1.1f,
                duration: 0.2f
            ).SetEase(Ease.OutExpo);
        }
        
        /// <summary>
        /// ボタン拡大・縮小を繰り返すTween
        /// </summary>
        public static Tweener ButtonExitTween(Button button)
        {
            return  button.transform.DOPunchScale(
                    Vector3.one * -0.1f,
                    duration: 0.2f
                )
                .SetEase(Ease.InOutCubic);
        }
    }
}