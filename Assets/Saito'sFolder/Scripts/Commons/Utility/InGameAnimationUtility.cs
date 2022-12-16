using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Commons.Utility
{
    /// <summary>
    /// インゲームのアニメーションのUtilityクラス
    /// </summary>
    public static class InGameAnimationUtility
    {
        
        public static Tween FadeInTween(RawImage panel,Subject<Unit> OnCallBack)
        {
            return panel.DOFade(1.0f, 1.0f)
                .SetEase(Ease.InCubic).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallBack?.OnNext(Unit.Default);
                });
        }
        
        public static Tween FadeInTween(Button panel,Subject<Unit> OnCallBack)
        {
            return panel.image.DOFade(1.0f, 1.0f)
                .SetEase(Ease.InCubic).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallBack?.OnNext(Unit.Default);
                });
        }

        public static Tween PunchAnimation(RawImage panel)
        {
            return panel.transform.DOPunchPosition(new Vector3(15f, 0, 0), 1f, 5, 1f)
                .SetEase(Ease.InCubic,5);
        }

        public static Tween FadeOutTween(RawImage panel,Subject<Unit> OnCallBack)
        {
            return panel.DOFade(0.0f, 0.5f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallBack?.OnNext(Unit.Default);
                });
        }
        
        public static Tweener ButtonEnterTween(Button button)
        {
            return  button.transform.DOScale(
                Vector3.one * 1.1f,
                duration: 0.2f
            ).SetEase(Ease.OutExpo);
        }
        
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