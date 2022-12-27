using System;
using System.Threading;
using Commons.Utility;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;

namespace Title.Saito
{
    public class TitleView : MonoBehaviour
    {
        [SerializeField] private Image _recommendationPanelImage;
        [SerializeField] private Image _transitionImage;
        [SerializeField] private Image _pushStartImage;

        private Subject<Unit> _subject;
        
        /// <summary>
        /// フェードインが終わったときに呼ばれる
        /// </summary>
        public IObservable<Unit> OnCallBack => _subject;

        public void Initialize()
        {
            _subject = new Subject<Unit>();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public IObservable<Unit> InputKeySpace()
        {
            return InputAsRx.InputAsObservable.GetKey(KeyCode.Space);
        }

        /// <summary>
        /// パネルをフェードアウトさせる
        /// </summary>
        public async UniTask PanelFadeOut(CancellationToken token, float duration = 2.5f)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
            TitleAnimationUtility.PanelFadeOutTween(_recommendationPanelImage).SetLink(this.gameObject);
        }
        
        /// <summary>
        /// フェードインのアニメーション
        /// </summary>
        public void TransitionEffectFadeIn()
        {
            TitleAnimationUtility.TransitionEffectTween(_transitionImage,_subject).SetLink(this.gameObject);
        }

        /// <summary>
        /// 画像をフェード表現する
        /// </summary>
        public void FadeImageLoop()
        {
            TitleAnimationUtility.FadeImageLoopTween(_pushStartImage).SetLink(this.gameObject);
        }
    }
}
