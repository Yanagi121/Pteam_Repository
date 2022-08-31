using System.Collections;
using System.Collections.Generic;
using Saito.Title.Models;
using Saito.Title.Views;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

namespace Saito.Title.Presenter
{
    public class TitlePresenter : MonoBehaviour
    {
        [SerializeField] private SceneAsset Scene = null;

        //[SerializeField] private TitleModel _model;
        [SerializeField] private ButtonView _view;
        
        // Start is called before the first frame update
        void Start()
        {
            
            
            this.UpdateAsObservable()
                .Where(_ => Input.anyKey )
                .Subscribe(_ =>
                        SceneManager.LoadScene(Scene.name),
                    ex=>Debug.LogError(ex),
                    () => Debug.Log("OnCompleted")
                ).AddTo(this);
        }
        
    }
}