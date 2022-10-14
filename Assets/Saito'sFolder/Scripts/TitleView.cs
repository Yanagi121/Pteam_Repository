using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    
    private bool flag = false;
    public bool Flag => flag;
    
    private void UpdateActive()
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
}
