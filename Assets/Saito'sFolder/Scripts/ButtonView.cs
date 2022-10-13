using System;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;

    public IObservable<PointerEventData> ObservableEnterButton()
    {
        return _button.OnPointerEnterAsObservable();
    }
    
    public IObservable<PointerEventData> ObservableExitButton()
    {
        return _button.OnPointerExitAsObservable();
    }
    
    public IObservable<PointerEventData> ObservableDownButton()
    {
        return _button.OnPointerDownAsObservable();
    }
    
    public IObservable<PointerEventData> ObservableClickButton()
    {
        return _button.OnPointerClickAsObservable();
    }

    private Tweener _tweener;

    public void ButtonEnterAnimation()
    {
        if (_tweener != null)
        {
            _tweener.Kill();
            Debug.Log(_tweener);
            _tweener = null;
            _button.transform.localScale = Vector3.one;
        }

        _tweener = _button.transform.DOScale(
            Vector3.one * 1.1f,
            duration: 0.2f
        ).SetEase(Ease.OutExpo).SetLink(_button.gameObject);

        // Down時の共通処理
        Debug.Log("Button Push");
    }

    public void ButtonExitAnimation()
    {
        if (_tweener != null)
        {
            _tweener.Kill();
            Debug.Log(_tweener);
            _tweener = null;
            _button.transform.localScale = Vector3.one;
        }

        _tweener = _button.transform.DOPunchScale(
                Vector3.one * -0.1f,
                duration: 0.2f
            )
            .SetEase(Ease.InOutCubic).SetLink(_button.gameObject);

        // Up時の共通処理
        Debug.Log("Button Release");
    }
}
