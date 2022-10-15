using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Image _image;

    private bool flag = false;
    public bool Flag => flag;

    public void UpdateActive()
    {
        _panel.gameObject.SetActive(false);
        flag = true;
    }

    public async UniTask PanelFade(CancellationToken token)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(2.5f), cancellationToken: token);
        _panel.gameObject.GetComponent<Image>().DOFade(0f, 0.5f).SetEase(Ease.Linear).SetLink(this.gameObject)
            .OnComplete(UpdateActive);
    }
    
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
