using System;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainMenu
{
//参考になりそう：https://developers.cyberagent.co.jp/blog/archives/4262/
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _inGameButton;
        public Button InGameButton => _inGameButton;

        [SerializeField] private Button _helpButton;
        public Button HelpButton => _helpButton;

        [SerializeField] private Button _optionButton;
        public Button OptionButton => _optionButton;

        /*
        public Action OnInGameButtonClickedListener;
        public Action OnHelpButtonClickedListener;
        public Action OnOptionButtonClickedListener;
        */

        /*
        public void Initialized()
        {
        }
        */

        public IObservable<PointerEventData> ObservableClickInGameButton()
        {
            return _inGameButton.OnPointerClickAsObservable();
        }

        public IObservable<PointerEventData> ObservableEnterInGameButton()
        {
            return _inGameButton.OnPointerEnterAsObservable();
        }

        public IObservable<PointerEventData> ObservableExitInGameButton()
        {
            return _inGameButton.OnPointerExitAsObservable();
        }

        public IObservable<PointerEventData> ObservableClickHelpButton()
        {
            return _helpButton.OnPointerClickAsObservable();
        }

        public IObservable<PointerEventData> ObservableEnterHelpButton()
        {
            return _helpButton.OnPointerEnterAsObservable();
        }

        public IObservable<PointerEventData> ObservableExitHelpButton()
        {
            return _helpButton.OnPointerExitAsObservable();
        }

        public IObservable<PointerEventData> ObservableClickOptionButton()
        {
            return _optionButton.OnPointerClickAsObservable();
        }

        public IObservable<PointerEventData> ObservableEnterOptionButton()
        {
            return _optionButton.OnPointerEnterAsObservable();
        }

        public IObservable<PointerEventData> ObservableExitOptionButton()
        {
            return _optionButton.OnPointerExitAsObservable();
        }
        
        public IObservable<PointerEventData> ObservableDownOptionButton()
        {
            return _optionButton.OnPointerDownAsObservable();
        }
        public IObservable<PointerEventData> ObservableDownHelpButton()
        {
            return _helpButton.OnPointerDownAsObservable();
        }
        public IObservable<PointerEventData> ObservableDownInGameButton()
        {
            return _inGameButton.OnPointerDownAsObservable();
        }

        private Tweener _tweener;

        public void ButtonEnterAnimation(Button _button)
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

        public void ButtonExitAnimation(Button _button)
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
}