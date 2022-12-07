using System;
using DG.Tweening;
using InputAsRx;
using UniRx;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneEffect : MonoBehaviour
{
    private event Action OnCallback;
    [SerializeField] private Image _maskImage;
    [SerializeField] private Image _bgImage;

    // Start is called before the first frame update
    void Start()
    {
        OnCallback += () => Debug.Log("アニメーションが終了しました");

        InputAsObservable
            .GetKeyDown(KeyCode.E)
            .Subscribe(_=>ReductionAnimation()).AddTo(this);

        InputAsObservable
            .GetKeyDown(KeyCode.Space)
            .Subscribe(_ => ScalingAnimation()).AddTo(this);
    }

    public void ScalingAnimation()
    {
        var tween = DOTween.Sequence()
            .OnStart(() =>
            {
                _maskImage.transform.DOLocalRotate(new Vector3(0, 0, 360f), 2f, RotateMode.FastBeyond360)
                    .SetEase(Ease.OutCubic);
            })
            .Join(_bgImage.DOFade(0.0f, 0.5f))
            .Join(_maskImage.transform.DOScale(Vector3.one * 30f, 2f))
            .OnComplete(() => OnCallback()).SetLink(this.gameObject)
            .Play();
    }

    public void ReductionAnimation()
    {
        var tween = DOTween.Sequence()
            .OnStart(() =>
            {
                _maskImage.transform.DOLocalRotate(new Vector3(0, 0, 360f), 2f, RotateMode.FastBeyond360)
                    .SetEase(Ease.OutCubic);
            })
            .Join(_bgImage.DOFade(1.0f, 0.5f))
            .Join(_maskImage.transform.DOScale(Vector3.one, 2f))
            .OnComplete(() => OnCallback()).SetLink(this.gameObject)
            .Play();
    }
}
