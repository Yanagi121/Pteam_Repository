using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeLoop : MonoBehaviour
{
    [SerializeField] private Image _image;
    // Start is called before the first frame update
    void Start()
    {
        
        LogoImageFadeLoop(this.GetCancellationTokenOnDestroy()).Forget();
    }

    public async UniTask LogoImageFadeLoop(CancellationToken token)
    {
        var sequence = DOTween.Sequence();
        
        await UniTask.Delay(TimeSpan.FromSeconds(2.5f), cancellationToken: token);
        _image.gameObject.GetComponent<Image>().DOFade(0f, 0.5f)
            .SetEase(Ease.Linear).SetLink(this.gameObject).SetLoops(-1,LoopType.Yoyo);
    }
}
