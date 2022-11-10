using System;
using DG.Tweening;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainMenu.Saito
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _inGameButton;
        public Button InGameButton => _inGameButton;

        [SerializeField] private Button _helpButton;
        public Button HelpButton => _helpButton;

        [SerializeField] private Button _optionButton;
        public Button OptionButton => _optionButton;
        

        /// <summary>
        /// ボタンクリック時にObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableClickInGameButton()
        {
            return _inGameButton.OnPointerClickAsObservable();
        }

        /// <summary>
        /// ホバー時にObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableEnterInGameButton()
        {
            return _inGameButton.OnPointerEnterAsObservable();
        }

        /// <summary>
        /// マウスカーソルがボタンから外れた時にObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableExitInGameButton()
        {
            return _inGameButton.OnPointerExitAsObservable();
        }

        public IObservable<PointerEventData> ObservableDownInGameButton()
        {
            return _inGameButton.OnPointerDownAsObservable();
        }
 
        /// <summary>
        /// ボタンクリック時にObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableClickHelpButton()
        {
            return _helpButton.OnPointerClickAsObservable();
        }

        /// <summary>
        /// ホバー時にObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableEnterHelpButton()
        {
            return _helpButton.OnPointerEnterAsObservable();
        }

        /// <summary>
        /// マウスカーソルがボタンから外れた時にObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableExitHelpButton()
        {
            return _helpButton.OnPointerExitAsObservable();
        }

        public IObservable<PointerEventData> ObservableDownHelpButton()
        {
            return _helpButton.OnPointerDownAsObservable();
        }
 
        /// <summary>
        /// ボタンクリック時にObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableClickOptionButton()
        {
            return _optionButton.OnPointerClickAsObservable();
        }

        /// <summary>
        /// ホバー時にObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableEnterOptionButton()
        {
            return _optionButton.OnPointerEnterAsObservable();
        }

        /// <summary>
        /// マウスカーソルがボタンから外れた時にObservableを返す
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableExitOptionButton()
        {
            return _optionButton.OnPointerExitAsObservable();
        }
        
        public IObservable<PointerEventData> ObservableDownOptionButton()
        {
            return _optionButton.OnPointerDownAsObservable();
        }

        #region ButtonAnimation

        private Tweener _tweener;

        /// <summary>
        /// ホバー時のボタンアニメーション
        /// </summary>
        /// <param name="_button"></param>
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

        /// <summary>
        /// ボタンからマウスカーソルが出た時のアニメーション
        /// </summary>
        /// <param name="_button"></param>
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

        #endregion
    }
}