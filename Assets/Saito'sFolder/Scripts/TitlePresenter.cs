using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Title.Saito
{
    public class TitlePresenter : MonoBehaviour
    {
        [SerializeField] private TitleModel _model;
        [SerializeField] private TitleView _view;

        private async void Start()
        {
            try
            {
                _view.FadeImageLoop();
                _view.PanelFade(this.GetCancellationTokenOnDestroy()).Forget();
                Initialized();
                Bind();
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

        /// <summary>
        /// 全体の初期化処理
        /// </summary>
        private void Initialized()
        {
            _model.Initialized();
        }

        private void Bind()
        {
            //model=>view
            ObservableEvery().Where(_ => Input.GetKeyDown(KeyCode.Space) && _model.Flag)
                .Subscribe(_ => SceneTransition())
                .AddTo(this);

            //view=>model
            _view.Callback
                .Subscribe(_ => _model.ValueUpdate(true)).AddTo(this);
        }

        /// <summary>
        /// UpdateのObservableを返す
        /// </summary>
        /// <returns></returns>
        private IObservable<long> ObservableEvery()
        {
            return Observable.EveryUpdate();
        }

        [SerializeField] private AssetReference _scene;

        /// <summary>
        /// シーン遷移をする
        /// </summary>
        private async void SceneTransition()
        {
            await _scene.LoadSceneAsync(LoadSceneMode.Single).Task;
        }
    }
}
