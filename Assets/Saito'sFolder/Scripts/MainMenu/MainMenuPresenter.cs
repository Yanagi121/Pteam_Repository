using System;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MainMenu.Saito
{
    public class MainMenuPresenter : MonoBehaviour
    {
        [SerializeField] private MainMenuView _view;
        private MainMenuModel _model;

        [SerializeField] private AssetReference _inGameScene;
        [SerializeField] private AssetReference _optionScene;
        [SerializeField] private AssetReference _helpScene;

        private AssetReference _scene;

        void Start()
        {
            try
            {
                Initialized();
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

        private void Initialized()
        {
            _model = new MainMenuModel();
            _view.Initialized();
        }

        private void Bind()
        {
            _model.IsPushProp
                .DistinctUntilChanged()
                .Where(_=>_model.IsPush)
                .Subscribe(_ =>
                {
                    _view.Show();
                    _view.TransitionEffectFadeIn();
                }).AddTo(this);
        }

        private void SetEvents()
        {
            _view.FadeInCallBack.Subscribe(_ => Commons.Utility.SceneTransition.LoadScene(_scene)).AddTo(this);
            _view.FadeOutCallBack.Subscribe(_=>_view.Hide()).AddTo(this);

            //inGame
            _view.ObservableEnterInGameButton()
                .Subscribe(_ => _view.ButtonEnterAnimation(_view.InGameButton))
                .AddTo(this);
            _view.ObservableExitInGameButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.InGameButton))
                .AddTo(this);
            _view.ObservableDownInGameButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.InGameButton))
                .AddTo(this);

            //option
            _view.ObservableEnterOptionButton()
                .Subscribe(_ => _view.ButtonEnterAnimation(_view.OptionButton))
                .AddTo(this);
            _view.ObservableExitOptionButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.OptionButton))
                .AddTo(this);
            _view.ObservableDownOptionButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.OptionButton))
                .AddTo(this);


            //help
            _view.ObservableEnterHelpButton()
                .Subscribe(_ => _view.ButtonEnterAnimation(_view.HelpButton))
                .AddTo(this);
            _view.ObservableExitHelpButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.HelpButton))
                .AddTo(this);
            _view.ObservableDownHelpButton()
                .Subscribe(_ => _view.ButtonExitAnimation(_view.HelpButton))
                .AddTo(this);
        }

        private void SetSubscribe()
        {
            _view.ObservableClickInGameButton()
                .ThrottleFirst(TimeSpan.FromSeconds(2f))
                .Subscribe(_ =>
                {
                    _scene = _inGameScene;
                    _model.UpdateBool(true);
                })
                .AddTo(this);

            _view.ObservableClickOptionButton()
                .ThrottleFirst(TimeSpan.FromSeconds(2f))
                .Subscribe(_ =>
                {
                    _scene = _optionScene;
                    _model.UpdateBool(true);
                })
                .AddTo(this);

            _view.ObservableClickHelpButton().ThrottleFirst(TimeSpan.FromSeconds(2f))
                .Subscribe(_ =>
                {
                    _scene = _helpScene;
                    _model.UpdateBool(true);
                })
                .AddTo(this);
        }
    }
}