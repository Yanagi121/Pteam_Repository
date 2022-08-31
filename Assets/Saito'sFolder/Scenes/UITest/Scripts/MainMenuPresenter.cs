using System.Collections;
using System.Collections.Generic;
using Saito.MainMenu.Model;
using UnityEngine;
using UniRx;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Saito.MainMenu.Presenter
{
    public class MainMenuPresenter : MonoBehaviour
    {
        [SerializeField]
        private MainMenuModel _model;
        
        [SerializeField] private Button _gamePlayStartButton;
        [SerializeField] private Button _settingBtton;
        [SerializeField] private Button _creditButton;
        [SerializeField] private Button _backButton;

        // Start is called before the first frame update
        void Start()
        {
            //model => view
            
            
            //view => model
            _gamePlayStartButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    //modelスクリプトの処理を書く
                    Debug.Log("ClickButton");
                })
                .AddTo(this);

            _settingBtton
                .OnClickAsObservable()
                .Subscribe(_ => Debug.Log("ClickButton"))
                .AddTo(this);

            _creditButton
                .OnClickAsObservable()
                .Subscribe(_ => Debug.Log("ClickButton"))
                .AddTo(this);

            _backButton
                .OnClickAsObservable()
                .Subscribe(_ => Debug.Log("ClickButton"))
                .AddTo(this);
        }
    }
}