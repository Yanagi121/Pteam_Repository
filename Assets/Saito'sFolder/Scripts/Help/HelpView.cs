using System;
using Commons.Utility;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using Commons.Const;
using UnityEngine.UI;

namespace Help.Saito
{
    public class HelpView : MonoBehaviour
    {
        [SerializeField]
        private Button _nextButton;

        [SerializeField]
        private Button _backButton;

        [SerializeField]
        
        private Button _returnButton;
        /// <summary>
        /// メインメニューに戻るボタン
        /// </summary>
        public Button ReturnButton => _returnButton;
        
        //
        [SerializeField] private Image _transitionImage;
        
        //遊びかたの画像群
        [SerializeField] private GameObject _articlePanel;

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
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableClickNextButton()
        {
            return _nextButton.OnPointerClickAsObservable();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<PointerEventData> ObservableClickBackButton()
        {
            return _backButton.OnPointerClickAsObservable();
        }

        /// <summary>
        ///ボタンクリック時のObservableを返す
        /// </summary>
        public IObservable<PointerEventData> ObservableClickReturnButton()
        {
            return _returnButton.OnPointerClickAsObservable();
        }

        /// <summary>
        ///ボタンホバー時のObservableを返す
        /// </summary>
        public IObservable<PointerEventData> ObservableEnterReturnButton()
        {
            return _returnButton.OnPointerEnterAsObservable();
        }

        /// <summary>
        /// ボタン逆ホバー時のObservableを返す
        /// </summary>
        public IObservable<PointerEventData> ObservableExitReturnButton()
        {
            return _returnButton.OnPointerExitAsObservable();
        }

        /// <summary>
        /// ボタン押し込み時のObservableを返す
        /// </summary>
        public IObservable<PointerEventData> ObservableDownReturnButton()
        {
            return _returnButton.OnPointerDownAsObservable();
        }
        
        /// <summary>
        /// シーン演出のパネルをアクティブ
        /// </summary>
        public void Show()
        {
            _transitionImage.gameObject.SetActive(true);
        }

        /// <summary>
        /// シーン演出のパネルを非アクティブ
        /// </summary>
        public void Hide()
        {
            _transitionImage.gameObject.SetActive(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void PanelShow(float pageNextNum)
        {
            switch (pageNextNum)
            {
                case InGameConst.ARTICLE_LEFT:
                    _articlePanel.transform.localPosition = new Vector3(InGameConst.LeftArticleX, 0.0f, 0.0f);
                    
                    //とりあえず、、、これは修正が必要
                    _backButton.GetComponent<Button>().interactable = false;
                    _nextButton.GetComponent<Button>().interactable = true;

                    break;
                case  InGameConst.ARTICLE_CENTER:
                    _articlePanel.transform.localPosition = new Vector3(InGameConst.CenterArticleX, 0.0f, 0.0f);
                    
                    _backButton.GetComponent<Button>().interactable = true;
                    _nextButton.GetComponent<Button>().interactable = true;
                    
                    break;
                case  InGameConst.ARTICLE_RIGHT:
                    _articlePanel.transform.localPosition = new Vector3(InGameConst.RightArticleX, 0.0f, 0.0f);
                    
                    _backButton.GetComponent<Button>().interactable = true;
                    _nextButton.GetComponent<Button>().interactable = false;
                    
                    break;
            }
        }

        /// <summary>
        /// フェードインのアニメーション
        /// </summary>
        public void TransitionEffectFadeIn()
        {
            HelpAnimationUtility.FadeInTween(_transitionImage,_fadeInSubject).SetLink(this.gameObject);
        }
        
        /// <summary>
        /// フェードアウトのアニメーション
        /// </summary>
        public void TransitionEffectFadeOut()
        {
            HelpAnimationUtility.FadeOutTween(_transitionImage,_fadeOutSubject).SetLink(this.gameObject);
        }
        
        private Tweener _tweener;
        
        /// <summary>
        /// ホバー時のボタンアニメーション
        /// </summary>
        public void ButtonEnterAnimation(Button _button)
        {
            if (_tweener != null)
            {
                _tweener.Kill();
                Debug.Log(_tweener);
                _tweener = null;
                _button.transform.localScale = Vector3.one;
            }
            
            _tweener=HelpAnimationUtility
                .ButtonScaleUpTween(_button).SetLink(_button.gameObject);
        }

        /// <summary>
        /// ボタンからマウスカーソルが出た時のアニメーション
        /// </summary>
        public void ButtonExitAnimation(Button _button)
        {
            if (_tweener != null)
            {
                _tweener.Kill();
                Debug.Log(_tweener);
                _tweener = null;
                _button.transform.localScale = Vector3.one;
            }
            
            _tweener=HelpAnimationUtility
                .ButtonPunchTween(_button).SetLink(_button.gameObject);
        }
    }
}