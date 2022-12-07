using System;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Help.Saito
{
    public class HelpPresenter : MonoBehaviour
    {
        private HelpModel _model;
        [SerializeField] private HelpView _view;

        [SerializeField] private AssetReference _scene;
        
        // Start is called before the first frame update
        void Start()
        {
            Initialized();
            _view.TransitionEffectFadeOut();
            Bind();
            SetEvents();
            SetSubscribe();
        }
        
           private void Initialized()
        {
            _model = new HelpModel();
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

        private void SetSubscribe()
        {
            _view.ObservableClickButton()
                .ThrottleFirst(TimeSpan.FromSeconds(2f))
                .Subscribe(_ => _model.UpdateBool(true))
                .AddTo(this);
        }
    }
}