using System;
using Commons.Utility;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Title.Saito
{
    public class TitlePresenter : MonoBehaviour
    {
        private TitleModel _model;
        [SerializeField] private TitleView _view;
        [SerializeField] private AssetReference _scene;

        private async void Start()
        {
            try
            {
                Initialized();
                SetEvent();
                SetSubscribe();
                
                _view.FadeImageLoop();
                _view.PanelFadeOut(this.GetCancellationTokenOnDestroy()).Forget();
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
            _model = new TitleModel();
            _view.Initialized();
        }

        private void SetEvent()
        {
            _view.OnCallBack
                .Subscribe(_=>SceneTransition.LoadScene(_scene)).AddTo(this);
        }
        
        private void SetSubscribe()
        {
            //model=>view
            _model.IsFadeProp
                .Where(_=>_model.IsFade)
                .DistinctUntilChanged().Subscribe(_=>_view.TransitionEffectFadeIn())
                .AddTo(this);

            //view=>model
            _view.InputKeySpace()
                .ThrottleFirst(TimeSpan.FromSeconds(2f))
                .Where(_ => !_model.IsFade)
                .Subscribe(_ => _model.BoolUpdate(true))
                .AddTo(this);
        }
    }
}
