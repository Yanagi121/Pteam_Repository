using  UnityEngine.UI;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Commons.Utility
{
    public static class LobbyAnimationUtility
    {
        public static Tween ScalingAnimation(Image _maskImage,Image _bgImage,Subject<Unit> OnCallBack)
        {
            return DOTween.Sequence()
                .OnStart(() =>
                {
                    _maskImage.transform.DOLocalRotate(new Vector3(0, 0, 360f), 2f, RotateMode.FastBeyond360)
                        .SetEase(Ease.OutCubic);
                })
                .Join(_bgImage.DOFade(0.0f, 0.5f))
                .Join(_maskImage.transform.DOScale(Vector3.one * 30f, 2f))
                .OnComplete(() => OnCallBack.OnNext(Unit.Default));
        }

        public static Tween ReductionAnimation(Image _maskImage,Image _bgImage,Subject<Unit> OnCallBack)
        {
            return DOTween.Sequence()
                .OnStart(() =>
                {
                    _maskImage.transform.DOLocalRotate(new Vector3(0, 0, 360f), 2f, RotateMode.FastBeyond360)
                        .SetEase(Ease.OutCubic);
                })
                .Join(_bgImage.DOFade(1.0f, 0.5f))
                .Join(_maskImage.transform.DOScale(Vector3.one, 2f))
                .OnComplete(() => OnCallBack.OnNext(Unit.Default));
        }
        
        public static Tween FadeInTween(Image panel,Subject<Unit> OnCallBack)
        {
            return panel.DOFade(1.0f, 0.5f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallBack?.OnNext(Unit.Default);
                });
        }
        
        public static Tween FadeOutTween(Image panel,Subject<Unit> OnCallBack)
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