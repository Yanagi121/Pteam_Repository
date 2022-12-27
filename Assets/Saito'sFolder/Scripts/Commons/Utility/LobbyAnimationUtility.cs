using Commons.Const;
using  UnityEngine.UI;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Commons.Utility
{
    /// <summary>
    /// ロビーのアニメーションのUtilityクラス
    /// </summary>
    public static class LobbyAnimationUtility
    {
        /// <summary>
        /// ロゴ拡大のTween
        /// </summary>
        public static Tween ScalingAnimation(Image _maskImage,Image _bgImage,Subject<Unit> OnCallBack)
        {
            return DOTween.Sequence()
                .OnStart(() =>
                {
                    _maskImage.transform.DOLocalRotate(new Vector3(0, 0, 360f), InGameConst.LogoAnimationDuration, RotateMode.FastBeyond360)
                        .SetEase(Ease.OutCubic);
                })
                .Join(_bgImage.DOFade(0.0f, InGameConst.FadeAnimationDuration))
                .Join(_maskImage.transform.DOScale(Vector3.one * 30f, InGameConst.LogoAnimationDuration))
                .OnComplete(() => OnCallBack.OnNext(Unit.Default));
        }

        /// <summary>
        /// ロゴ縮小のTween
        /// </summary>
        public static Tween ReductionAnimation(Image _maskImage,Image _bgImage,Subject<Unit> OnCallBack)
        {
            return DOTween.Sequence()
                .OnStart(() =>
                {
                    _maskImage.transform.DOLocalRotate(new Vector3(0, 0, 360f), InGameConst.LogoAnimationDuration, RotateMode.FastBeyond360)
                        .SetEase(Ease.OutCubic);
                })
                .Join(_bgImage.DOFade(1.0f, InGameConst.FadeAnimationDuration))
                .Join(_maskImage.transform.DOScale(Vector3.one, InGameConst.LogoAnimationDuration))
                .OnComplete(() => OnCallBack.OnNext(Unit.Default));
        }
        
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