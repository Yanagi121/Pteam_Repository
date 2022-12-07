using System;
using Commons.Utility;
using DG.Tweening;
using UniRx;
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
        
        [SerializeField] private Image _transitionImage;
        
        private Subject<Unit> _fadeInSubject;
        public IObservable<Unit> FadeInCallBack => _fadeInSubject;
        
        private Subject<Unit> _fadeOutSubject;
        public IObservable<Unit> FadeOutCallBack => _fadeOutSubject;

        public void Initialized()
        {
            _fadeInSubject = new Subject<Unit>();
            _fadeOutSubject = new Subject<Unit>();
        }

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

        public void Show()
        {
            _transitionImage.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _transitionImage.gameObject.SetActive(false);
        }

        public void TransitionEffectFadeIn()
        {
            MainMenuAnimationUtility.FadeInTween(_transitionImage,_fadeInSubject).SetLink(this.gameObject);
        }
        
        public void TransitionEffectFadeOut()
        {
            MainMenuAnimationUtility.FadeOutTween(_transitionImage,_fadeOutSubject).SetLink(this.gameObject);
        }
        
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
            
            _tweener=MainMenuAnimationUtility
                .ButtonEnterTween(_button).SetLink(_button.gameObject);
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
            
            _tweener=MainMenuAnimationUtility
                .ButtonExitTween(_button).SetLink(_button.gameObject);
            // Up時の共通処理
            Debug.Log("Button Release");
        }
    }
}