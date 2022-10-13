using System.Collections;
using System.Collections.Generic;
using Saito;
using UniRx;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class MainMenuPresenter : MonoBehaviour
{
    [SerializeField] private ButtonView _view;

    //データが必要な際に備える
    //[SerializeField] private Model _model;

    void Start()
    {
        //ボタンがホバーされたら
        _view.ObservableEnterButton()
            .Subscribe(_=>_view.ButtonEnterAnimation()).AddTo(this);
        
        //ボタンから外れたら
        _view.ObservableExitButton()
            .Subscribe(_=>_view.ButtonExitAnimation()).AddTo(this);

        _view.ObservableDownButton()
            .Subscribe(_=>_view.ButtonExitAnimation()).AddTo(this);
        
        //ボタンがクリックされたら
        _view.ObservableClickButton()
            .Subscribe(_ =>
            {
                Debug.Log(_scene);
                //SceneTransition(_scene);
            }).AddTo(this);
    }

    [SerializeField] private AssetReference _scene;
    private void SceneTransition(AssetReference name)
    {
       var s= Addressables.LoadSceneAsync(name);
       Addressables.UnloadSceneAsync(s);
    }
}
