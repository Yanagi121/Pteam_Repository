using System;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuPresenter : MonoBehaviour
    {
        [SerializeField] private MainMenuView _view;

        void Start()
        {
            try
            {
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
                _view.ObservableClickInGameButton()
                    .Subscribe(_ => SceneTransition(_inGameScene))
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
                _view.ObservableClickOptionButton()
                    .Subscribe(_ => SceneTransition(_optionScene))
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
                _view.ObservableClickHelpButton()
                    .Subscribe(_ => SceneTransition(_helpScene))
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

        /*
        private void Bind()
        {
        }
        */

        /*
        private void  Event()
        {
        }
        */

        [SerializeField] private AssetReference _inGameScene;
        [SerializeField] private AssetReference _optionScene;
        [SerializeField] private AssetReference _helpScene;

        private async void SceneTransition(AssetReference scene)
        {
            var s=await scene.LoadSceneAsync(LoadSceneMode.Single).Task;
            //scene.ReleaseAsset();
        }
    }
}
