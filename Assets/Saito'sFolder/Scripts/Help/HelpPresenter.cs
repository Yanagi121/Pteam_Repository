using System;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Help.Saito
{
    public class HelpPresenter : MonoBehaviour
    {
        //Model
        private HelpModel _model;

        //View
        [SerializeField] private HelpView _view;

        //遷移したいシーン先
        [SerializeField] private AssetReference _scene;

        // Start is called before the first frame update
        void Start()
        {
            try
            {
                Initialize();

                //シーン読み込み時にトランジションアニメーションを再生
                _view.TransitionEffectFadeOut();

                Bind();

                SetEvents();

                SetSubscribe();
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
        private void Initialize()
        {
            _model = new HelpModel();
            _view.Initialize();
        }

        /// <summary>
        /// Bind
        /// </summary>
        private void Bind()
        {
            //フラグが立ったらシーン移動
            _model.IsPushProp
                .DistinctUntilChanged()
                .Where(_ => _model.IsPush)
                .Subscribe(_ =>
                {
                    _view.Show();
                    _view.TransitionEffectFadeIn();
                }).AddTo(this);

            //
            _model.PageCurrentNumProp.Subscribe(value =>
                _view.PanelShow(_model.PageCurrentNum)).AddTo(this);
        }

        /// <summary>
        /// SetEvents
        /// </summary>
        private void SetEvents()
        {
            //ボタンが押されたらトランジションアニメーションを再生
            _view.FadeInCallBack.Subscribe(_ => Commons.Utility.SceneTransition.LoadScene(_scene)).AddTo(this);
            //トランジションアニメーションを再生したらパネルを非アクティブ
            _view.FadeOutCallBack.Subscribe(_=>_view.Hide()).AddTo(this);

            //ボタンのアニメーションを設定
            _view.ObservableEnterReturnButton()
                .Subscribe(_ => _view.ButtonEnterAnimation(_view.ReturnButton))
                .AddTo(this);
            _view.ObservableExitReturnButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.ReturnButton))
                .AddTo(this);
            _view.ObservableDownReturnButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.ReturnButton))
                .AddTo(this);
        }

        /// <summary>
        /// SetSubscribe
        /// </summary>
        private void SetSubscribe()
        {
            //ボタンがクリックされたらフラグを立てる
            _view.ObservableClickReturnButton()
                .ThrottleFirst(TimeSpan.FromSeconds(2f))
                .Subscribe(_ => _model.UpdateBool(true))
                .AddTo(this);
            
            _view.ObservableClickNextButton()
                .Subscribe(_=>_model.UpdatePageNum(_model.PageCurrentNum+1.0f)).AddTo(this);
            
            _view.ObservableClickBackButton()
                .Subscribe(_=>_model.UpdatePageNum(_model.PageCurrentNum-1.0f)).AddTo(this);
        }
    }
}