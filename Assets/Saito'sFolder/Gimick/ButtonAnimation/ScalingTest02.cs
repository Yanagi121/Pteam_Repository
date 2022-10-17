using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UniRx.Triggers;
using UniRx;
using UnityEngine.Events;

namespace Saito
{
    public class ScalingTest02 : MonoBehaviour
{
        private Tweener tweener = null;
        //private Vector3 baseScale;

        //private void Awake()
        //{
        //  baseScale = this.transform.localScale;
        //}

        void Start()
        {
            this.gameObject.AddComponent<ObservablePointerEnterTrigger>()
                .OnPointerEnterAsObservable().Subscribe(_ => { OnButtonEnter(); },
                    ex => Debug.LogError(ex)
                ).AddTo(this.gameObject);

            this.gameObject.AddComponent<ObservablePointerExitTrigger>()
                .OnPointerExitAsObservable().Subscribe(_ => { OnButtonDown();/*;*/ },
                    ex => Debug.LogError(ex)
                ).AddTo(this.gameObject);
            
            this.gameObject.AddComponent<ObservablePointerDownTrigger>()
                .OnPointerDownAsObservable().Subscribe(_ => { OnButtonExit(); },
                    ex => Debug.LogError(ex)
                ).AddTo(this.gameObject);
        }


        #region Buttonで実行したい共通処理

        private void OnButtonEnter()
        {
            if (tweener != null)
            {
                tweener.Kill();
                Debug.Log(tweener);
                tweener = null;
                transform.localScale = Vector3.one;
            }

            tweener = transform.DOPunchScale(
                Vector3.one * 1.1f,
                duration: 0.2f
            ).SetEase(Ease.OutExpo).Play().SetLink(this.gameObject);

            // Down時の共通処理
            Debug.Log("Button Push");
        }

        private void OnButtonExit()
        {
            if (tweener != null)
            {
                tweener.Kill();
                Debug.Log(tweener);
                tweener = null;
                transform.localScale = Vector3.one;
            }

            tweener = transform.DOPunchScale(
                    Vector3.one * -0.1f,
                    duration: 0.2f
                )
                .SetEase(Ease.InOutCubic).Play().SetLink(this.gameObject);

            // Up時の共通処理
            Debug.Log("Button Release");
        }

        private void OnButtonDown()
        {
            if (tweener != null)
            {
                tweener.Kill();
                Debug.Log(tweener);
                tweener = null;
                transform.localScale = Vector3.one;
            }
            tweener=transform.DOScale(Vector3.one,duration:0.5f) .SetEase(Ease.InOutQuart).Play().SetLink(this.gameObject);
        }

        #endregion
    }
}
