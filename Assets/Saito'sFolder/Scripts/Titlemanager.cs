using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Titlemanager : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        waitTest(this.GetCancellationTokenOnDestroy()).Forget();
    }

    async UniTask waitTest(CancellationToken token)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(2.5f), cancellationToken: token);
        panel.gameObject.GetComponent<Image>().DOFade(0f, 0.5f).SetLink(this.gameObject);

        Observable.EveryUpdate()
                  .Where(_ => Input.anyKey)
                  .Subscribe(_ => SceneManager.LoadScene("Saito'sFolder/Scenes/Master/Main"))
                  .AddTo(this);
    }
}