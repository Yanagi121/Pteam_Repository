using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class InGameView : MonoBehaviour
{
    [SerializeField] private AssetReferenceSprite _hakaseAsset;
    [SerializeField] private AssetReferenceSprite _startAsset;
    [SerializeField] private AssetReferenceSprite _finishAsset;

    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Image _hakaseImage;
    [SerializeField] private Image _startImage;
    [SerializeField] private Image _finishImage;

    private async void Start()
    {  
        Initialized();

        await UniTask.Delay(TimeSpan.FromSeconds(3),delayTiming:PlayerLoopTiming.Update,cancellationToken:this.GetCancellationTokenOnDestroy());
        CountDownAnimation();
        
        SetActive(_finishImage.gameObject,true);
    }

    private void Initialized()
    {
        SpriteSet(_hakaseAsset,_hakaseImage);
        SpriteSet(_startAsset,_startImage);
        SpriteSet(_finishAsset,_finishImage);
        
        SetActive(_hakaseImage.gameObject,false);
        SetActive(_startImage.gameObject,false);
        SetActive(_finishImage.gameObject,false);
    }

    private void SetActive(GameObject obj,bool flag)
    {
        obj.SetActive(flag);
    }

    private void CountDownAnimation()
    {
        _text.DOCounter(100, 0, 10)
            .SetEase(Ease.Linear).SetDelay(0.5f).SetLink(this.gameObject);
    }
    
    private async void SpriteSet(AssetReferenceSprite asset,Image image)
    {
        var sprite=await asset.LoadAssetAsync<Sprite>().Task;
        image.sprite=sprite;
        asset.ReleaseAsset();
    }
}
