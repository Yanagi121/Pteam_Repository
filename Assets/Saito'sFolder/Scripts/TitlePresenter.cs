using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] private TitleView _view;

    private void Start()
    {
        _view.PanelFade(this.GetCancellationTokenOnDestroy()).Forget();
        
        Observable.EveryUpdate()
            .Where(_ => Input.anyKey&&_view.Flag)
            .Subscribe(_ => SceneManager.LoadScene("Saito'sFolder/Scenes/Master/Main"))
            .AddTo(this);
    }
}