using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titlemanager : MonoBehaviour
{
    [SerializeField] private GameObject panel; 
    
    private void Start()
    {
        waitTest(this.GetCancellationTokenOnDestroy()).Forget();
    }

    async UniTask waitTest(CancellationToken token)  
    {
        await UniTask.Delay(TimeSpan.FromSeconds(2.5f),cancellationToken: token);  
        panel.gameObject.SetActive(false);
        
        
          Observable.EveryUpdate()
                    .Where(_ => Input.anyKey)
                    .Subscribe(_ => SceneManager.LoadScene("Saito'sFolder/Scenes/Master/Main"))
                    .AddTo(this);
    }
}
