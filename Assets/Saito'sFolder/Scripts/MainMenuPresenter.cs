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
            scene.ReleaseAsset();
        }
    }
}
