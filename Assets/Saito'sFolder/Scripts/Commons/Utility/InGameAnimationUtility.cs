using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Commons.Utility
{
    public static class InGameAnimationUtility
    {
        public static Tween TransitionEffectTween(Image panel,Subject<Unit> OnCallBack)
        {
            return panel.DOFade(1.0f, 0.5f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallBack.OnNext(Unit.Default);
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