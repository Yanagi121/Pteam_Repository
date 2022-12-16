using System;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Option.Saito
{
    public class OptionPresenter : MonoBehaviour
    {
        //Model
        private OptionModel _model;
        
        //View
        [SerializeField] private OptionView _view;

        [SerializeField] private OptionManager _manager;

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
            _model = new OptionModel();
            _view.Initialize();
            _manager.Initialize();
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
            _view.ObservableEnterButton()
                .Subscribe(_ => _view.ButtonEnterAnimation(_view.Button))
                .AddTo(this);
            _view.ObservableExitButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.Button))
                .AddTo(this);
            _view.ObservableDownButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.Button))
                .AddTo(this);
        }

        /// <summary>
        /// SetSubscribe
        /// </summary>
        private void SetSubscribe()
        {
            //ボタンがクリックされたらフラグを立てる
            _view.ObservableClickButton()
                .ThrottleFirst(TimeSpan.FromSeconds(2f))
                .Subscribe(_ => _model.UpdateBool(true))
                .AddTo(this);
        }
    }
}