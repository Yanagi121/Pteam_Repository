using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace InGame.Saito
{
    public class InGameView : MonoBehaviour
    {
        [SerializeField] private AssetReferenceSprite _hakaseAsset;
        [SerializeField] private AssetReferenceSprite _startAsset;
        [SerializeField] private AssetReferenceSprite _finishAsset;

        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private Image _hakaseImage;
        [SerializeField] private Image _startImage;
        [SerializeField] private Image _finishImage;

        [SerializeField] private Transform _transform;

        private bool isFinish = false;

        //sequenceでまとめてアニメーションを操作する
        private async UniTask Start()
        {
            Initialized();
            CountDownAnimation(3, 1, () => isFinish = true);
            await UniTask.WaitUntil(() => isFinish, cancellationToken: this.GetCancellationTokenOnDestroy());
            
            SetActive(_startImage.gameObject, true);
            await UniTask.Delay(TimeSpan.FromSeconds(2f));
            SetActive(_startImage.gameObject, false);

            _text.transform.position = _transform.position; //移動
            CountDownAnimation(100, 1, () => SetActive(_finishImage.gameObject, true));
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _text.text = "";
            
            SpriteSet(_hakaseAsset, _hakaseImage);
            SpriteSet(_startAsset, _startImage);
            SpriteSet(_finishAsset, _finishImage);

            SetActive(_hakaseImage.gameObject, false);
            SetActive(_startImage.gameObject, false);
            SetActive(_finishImage.gameObject, false);
        }

        /// <summary>
        /// オブジェクトのアクティブ状態を設定
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="flag"></param>
        public void SetActive(GameObject obj, bool flag)
        {
            obj.SetActive(flag);
        }

        /// <summary>
        /// テキストをカウントダウン形式でアニメーション
        /// </summary>
        /// <param name="value"></param>
        /// <param name="end"></param>
        /// <param name="OnResult"></param>
        public void CountDownAnimation(int value, int end, TweenCallback OnResult = null)
        {
            _text.DOCounter(value, end, value + 1)
                .SetEase(Ease.Linear).SetLink(this.gameObject).OnComplete(OnResult);
        }

        /// <summary>
        /// 画像を設定
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="image"></param>
        private async void SpriteSet(AssetReferenceSprite asset, Image image)
        {
            var sprite = await asset.LoadAssetAsync<Sprite>().Task;
            image.sprite = sprite;
            asset.ReleaseAsset();
        }
    }    
}

