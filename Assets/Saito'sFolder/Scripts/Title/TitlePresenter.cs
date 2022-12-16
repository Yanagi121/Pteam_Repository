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
        //Model
        private TitleModel _model;
        
        //View
        [SerializeField] private TitleView _view;
      
        //遷移したいシーン先
        [SerializeField] private AssetReference _scene;

        private async void Start()
        {
            try
            {
                Initialized();
                
                SetEvent();
                
                SetSubscribe();
                
                //画像をフェードループする
                _view.FadeImageLoop();
                
                //シーン読み込み時にトランジションアニメーションを再生
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
        /// Initialize
        /// </summary>
        private void Initialized()
        {
            _model = new TitleModel();
            _view.Initialize();
        }

        /// <summary>
        /// SetEvents
        /// </summary>
        private void SetEvent()
        {
            //トランジションアニメーションを再生したらパネルを非アクティブ
            _view.OnCallBack
                .Subscribe(_=>SceneTransition.LoadScene(_scene)).AddTo(this);
        }
        
        /// <summary>
        /// SetSubscribe
        /// </summary>
        private void SetSubscribe()
        {
            //フラグが立ったらシーン移動
            _model.IsFadeProp
                .Where(_=>_model.IsFade)
                .DistinctUntilChanged().Subscribe(_=>_view.TransitionEffectFadeIn())
                .AddTo(this);

            //ボタンがクリックされたらフラグを立てる
            _view.InputKeySpace()
                .ThrottleFirst(TimeSpan.FromSeconds(2f))
                .Where(_ => !_model.IsFade)
                .Subscribe(_ => _model.BoolUpdate(true))
                .AddTo(this);
        }
    }
}
