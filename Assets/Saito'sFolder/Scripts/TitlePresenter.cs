using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] private TitleView _view;

    private void Start()
    {
        _view.PanelFade(this.GetCancellationTokenOnDestroy()).Forget();
        
        ObservableEvery()
            .Where(_ => Input.anyKey&&_view.Flag)
            .Subscribe(_ => SceneTransition())
            .AddTo(this);
    }

        private IObservable<long> ObservableEvery()
        {
            return Observable.EveryUpdate();
        }
        
        [SerializeField] private AssetReference _scene;
        private async void SceneTransition()
        {
            await _scene.LoadSceneAsync(LoadSceneMode.Single).Task;
            _scene.ReleaseAsset();
        }
}