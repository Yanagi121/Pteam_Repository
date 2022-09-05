using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MVRP.VIEW
{
    public class ClickButton : MonoBehaviour
    {
        [FormerlySerializedAs("text")] [SerializeField]
        public Text _text;

        private int count;
        public UnityEvent _Event = null;

        // Start is called before the first frame update
        void Start()
        {
            //クリックしたら実行される
            this.gameObject.AddComponent<ObservablePointerClickTrigger>()
                .OnPointerClickAsObservable().Subscribe(_ =>
                {
                    _Event.AddListener(TestOnClick);
                    _Event.Invoke();
                },
                ex => Debug.LogError("押されました")
            ).AddTo(this.gameObject);
            
            this.gameObject.AddComponent<ObservablePointerDownTrigger>()
                .OnPointerDownAsObservable().Subscribe(_ =>
                    {
                        OnButtonDown();
                    },
                    ex => Debug.LogError("押されました")
                ).AddTo(this.gameObject);

            this.gameObject.AddComponent<ObservablePointerUpTrigger>()
                .OnPointerUpAsObservable().Subscribe(_ =>
                    {
                       OnButtonUp();
                    },
                    ex => Debug.LogError("押されました")
                ).AddTo(this.gameObject);
            
            this.gameObject.AddComponent<ObservablePointerExitTrigger>()
                .OnPointerExitAsObservable().Subscribe(_ =>
                    {
                        OnButtonExit();
                    },
                    ex => Debug.LogError("押されました")
                ).AddTo(this.gameObject);
            
            this.gameObject.AddComponent<ObservablePointerEnterTrigger>()
                .OnPointerEnterAsObservable().Subscribe(_ =>
                    {
                        OnButtonEnter();
                    },
                    ex => Debug.LogError("押されました")
                ).AddTo(this.gameObject);

            this.gameObject.AddComponent<ObservableSelectTrigger>()
                .OnSelectAsObservable().Subscribe(_ =>
                    {
                        OnButtonSelect();
                    },
                    ex => Debug.LogError("押されました")
                ).AddTo(this.gameObject);

            /*
            var mouseDownStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
            var mouseUpStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonUp(0));
    
            //長押しの判定
            //マウスクリックされたら3秒後にOnNextを流す
            mouseDownStream
                //3秒ごとにメッセージを発生させる
                .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(3)))
                //マウスのクリックを離したら、メッセージ発信を終了する
                .TakeUntil(mouseUpStream)
                .RepeatUntilDestroy(this.gameObject)
                .Subscribe(_ => Debug.Log("長押し"))
                .AddTo(this);
            
            //常に発信するイベント
            this.UpdateAsObservable().
                Where(_ => Input.GetKeyDown(KeyCode.Space)) //Spaceキーが押されていて
                .TakeUntilDestroy(this)
                .ThrottleFirst(TimeSpan.FromSeconds(2)) //2秒の間隔で発信する
                .Subscribe(_ =>
                {
                    Debug.Log("Space Key Down!");
                    _text.text="Space!";
                }); //実行されるイベントハンドラー
                */
        }
        
        
        #region Buttonで実行したい共通処理

        private void OnButtonExit()
        {
            // Exit時の共通処理
            Debug.Log("Button  Exit");
        }

        private void OnButtonEnter()
        {
            // Enter時の共通処理
            Debug.Log("Button Enter");
        }

        private void OnButtonDown()
        {
            // Down時の共通処理
            Debug.Log("Button Push");
        }

        private void OnButtonUp()
        {
            // Up時の共通処理
            Debug.Log("Button Release");
        }

        private void OnButtonClick()
        {
            // Click時の共通処理
            Debug.Log("Button Click");
        }

        private void OnButtonSelect()
        {
            // Select時の共通処理
            Debug.Log("This gameObject Selected!");
        }
        
        /// <summary>
        /// クリック時に呼び出される関数(登録)
        /// </summary>
        public void TestOnClick()
        {
            Debug.Log("Event OnClick!");
        }
        
        #endregion
    }
}