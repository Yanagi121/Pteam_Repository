using Commons.Utility;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace InGame.Saito
{
    public class InGameFinishView : MonoBehaviour
    { 
        [SerializeField] private RawImage[] _images;
        [SerializeField] private Button _button;

        private Subject<Unit> OnCallBack;
            // Start is called before the first frame update
        private void Start()
        {
            OnCallBack=new Subject<Unit>();
            OnCallBack.Subscribe(_=>ImagePopUpAnimation());
            
            foreach (var image in _images)
            {
                InGameAnimationUtility.FadeInTween(image,default)
                    .SetLink(this.gameObject);
            }

            InGameAnimationUtility.FadeInTween(_button, OnCallBack)
                .SetLink(this.gameObject);
        }

        private void ImagePopUpAnimation()
        {
            foreach (var image in _images)
            {
                InGameAnimationUtility.PunchAnimation(image)
                    .SetLink(this.gameObject).SetEase(Ease.OutExpo);
            }
        }
    }
}