using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Saito
{
    public class SceneTransition : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset _scene;

        public void SetDestSceneName()
        {
            destSceneName = _scene.name;
        }

#endif

        [SerializeField] string destSceneName;

        void Start()
        {
#if UNITY_EDITOR
            this.GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => SceneManager.LoadScene(_scene.name)).AddTo(this);

#else
 this.GetComponent<Button>().OnClickAsObservable()
            .Subscribe(_ => SceneManager.LoadScene(destSceneName)).AddTo(this);

#endif
        }
    }
}