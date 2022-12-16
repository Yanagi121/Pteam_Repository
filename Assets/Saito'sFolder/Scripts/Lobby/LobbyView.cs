using System;
using Commons.Utility;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lobby.Saito
{
    public class LobbyView : MonoBehaviour
    {
       [SerializeField] private Button _button;
       /// <summary>
       /// メインメニューに戻るボタン
       /// </summary> 
       public Button Button => _button;

        private Subject<Unit> _fadeInSubject;
        /// <summary>
        /// フェードインが終わったときに呼ばれる
        /// </summary>
        public IObservable<Unit> FadeInCallBack => _fadeInSubject;

        private Subject<Unit> _fadeOutSubject;
        /// <summary>
        /// フェードアウトが終わったとき呼ばれる
        /// </summary>
        public IObservable<Unit> FadeOutCallBack => _fadeOutSubject;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            _fadeInSubject = new Subject<Unit>();
            _fadeOutSubject = new Subject<Unit>();
        }

        
        /// <summary>
        ///ボタンクリック時のObservableを返す
        /// </summary>
        public IObservable<PointerEventData> ObservableClickButton()
        {
            return _button.OnPointerClickAsObservable();
        }

        /// <summary>
        ///ボタンホバー時のObservableを返す
        /// </summary>
        public IObservable<PointerEventData> ObservableEnterButton()
        {
            return _button.OnPointerEnterAsObservable();
        }

        /// <summary>
        /// ボタン逆ホバー時のObservableを返す
        /// </summary>
        public IObservable<PointerEventData> ObservableExitButton()
        {
            return _button.OnPointerExitAsObservable();
        }

        /// <summary>
        /// ボタン押し込み時のObservableを返す
        /// </summary>
        public IObservable<PointerEventData> ObservableDownButton()
        {
            return _button.OnPointerDownAsObservable();
        }
        
           
        /// <summary>
        /// シーン演出のパネルをアクティブ
        /// </summary>
        public void Show()
        {
            _bgImage.gameObject.SetActive(true);
        }

        /// <summary>
        /// シーン演出のパネルを非アクティブ
        /// </summary>
        public void Hide()
        {
            _bgImage.gameObject.SetActive(false);
        }
        
        [SerializeField] private Image _bgImage;
        [SerializeField] private Image _maskImage;
        
        /// <summary>
        /// フェードインのアニメーション
        /// </summary>
        public void TransitionEffectFadeIn()
        {
            LobbyAnimationUtility.ReductionAnimation(_maskImage,_bgImage,_fadeInSubject).SetLink(this.gameObject);
        }
        
        /// <summary>
        /// フェードアウトのアニメーション
        /// </summary>
        public void TransitionEffectFadeOut()
        {
            LobbyAnimationUtility.ScalingAnimation(_maskImage,_bgImage,_fadeOutSubject).SetLink(this.gameObject);
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
            
            _tweener=LobbyAnimationUtility
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
            
            _tweener=LobbyAnimationUtility
                .ButtonExitTween(_button).SetLink(_button.gameObject);
            // Up時の共通処理
            Debug.Log("Button Release");
        }
    }
}