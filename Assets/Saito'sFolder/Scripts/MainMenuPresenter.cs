using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPresenter : MonoBehaviour
{
    [SerializeField] private ButtonView _view;

    [SerializeField] private SceneAsset _scene;
    
    void Start()
    {
        _view.ObservableEnterButton()
            .Subscribe(_=>_view.ButtonEnterAnimation()).AddTo(this);
        
        _view.ObservableEnterButton()
            .Subscribe(_=>_view.ButtonExitAnimation()).AddTo(this);
        
        _view.ObservableClickButton()
            .Subscribe(_=>SceneManager.LoadScene(_scene.name)).AddTo(this);
    }
}
