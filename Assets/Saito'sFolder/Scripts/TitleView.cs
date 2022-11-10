using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;

namespace Title.Saito
{
    public class TitleView : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Image _image;

        /// <summary>
        /// パネルがフェードアウトを終えた際のコールバック
        /// </summary>
        public Subject<Unit> Callback = new Subject<Unit>();

        /// <summary>
        /// パネルをフェードアウトさせる
        /// </summary>
        /// <param name="token"></param>
        public async UniTask PanelFade(CancellationToken token, float duration = 2.5f)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(duration), cancellationToken: token);
            _panel.gameObject.GetComponent<Image>().DOFade(0f, 0.5f).SetEase(Ease.Linear)
                .SetLink(this.gameObject).OnComplete(() =>
                {
                    Callback?.OnNext(Unit.Default);
                    Debug.Log("フェードアウトが完了しました");
                });
        }

        /// <summary>
        /// 画像をフェード表現する
        /// </summary>
        public void FadeImageLoop()
        {
            _image.DOFade(0.0f, 1f)
                .SetEase(Ease.InCubic).SetLoops(-1, LoopType.Yoyo).SetLink(this.gameObject);
        }

        /*
        public void FadeObj(float duration,Ease ease,LoopType type,TweenCallback complete=null)
        {
            _image.DOFade(0.0f, duration)
                .SetEase(ease).SetLoops(-1, type).SetLink(this.gameObject).OnComplete(complete);
        }*/
    }
  
}
