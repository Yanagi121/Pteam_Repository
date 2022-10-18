using System;
using Cysharp.Threading.Tasks;
using DG.Tweening.Core;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] private TitleView _view;

    private async void Start()
    {
        try
        {
            _view.PanelFade(this.GetCancellationTokenOnDestroy()).Forget();
            _view.FadeImageLoop();
            
            ObservableEvery()
                .Where(_ => Input.anyKey&&_view.Flag)
                .Subscribe(_ => SceneTransition())
                .AddTo(this);
        }
        catch (NullReferenceException ex)
        {
            //警告メッセージを表示する
            Debug.LogWarning($"<color=red>オブジェクトがnullである可能性があります。{this.name}の取得メソッド、publicを確認してください。:{ex}</color>");
        }
        //メソッドの引数がnullだったら
        catch (ArgumentNullException ex)
        {
            //警告メッセージを表示する
            Debug.LogWarning($"<color=red>メソッドの引数がnullです。{this.name}にあるメソッドの引数を確認してください。：{ex}</color>");
        }
        //メソッドの引数が不正だったら
        catch (ArgumentException ex)
        {
            //警告メッセージを表示する
            Debug.LogWarning($"<color=red>メソッドの引数が不正です。{this.name}にあるメソッドの引数を確認してください。：{ex}</color>");
        }
        //今迄の例外にヒットしなかった場合
        catch (Exception ex)
        {
            throw ex;
        }
    }

        private IObservable<long> ObservableEvery()
        {
            return Observable.EveryUpdate();
        }
        
        [SerializeField] private AssetReference _scene;
        private async void SceneTransition()
        {
            await _scene.LoadSceneAsync(LoadSceneMode.Single).Task;
        }

        void OnDisable() {
            //_scene?.ReleaseAsset();
            Debug.Log("OnDisable");
        }
    
}