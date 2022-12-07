using System;
using Commons.Utility;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Option.Saito
{
    public class OptionView : MonoBehaviour
    {
       [SerializeField] private Button _button;
        public Button Button => _button;
        
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

        public IObservable<PointerEventData> ObservableClickButton()
        {
            return _button.OnPointerClickAsObservable();
        }

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
            OptionAnimationUtility.FadeInTween(_transitionImage,_fadeInSubject).SetLink(this.gameObject);
        }
        
        public void TransitionEffectFadeOut()
        {
            OptionAnimationUtility.FadeOutTween(_transitionImage,_fadeOutSubject).SetLink(this.gameObject);
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
            
            _tweener=OptionAnimationUtility
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
            
            _tweener=OptionAnimationUtility
                .ButtonExitTween(_button).SetLink(_button.gameObject);
            // Up時の共通処理
            Debug.Log("Button Release");
        }
    }
}