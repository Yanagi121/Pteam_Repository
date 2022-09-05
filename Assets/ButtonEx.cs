using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UiEx
{
    [RequireComponent(typeof(Image))]
    //[RequireComponent(typeof(Text))]
    [AddComponentMenu("UI/ExButton", 14)]
    public class ButtonEx : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
        ,IPointerEnterHandler,IPointerExitHandler,ISelectHandler
    {
        [FormerlySerializedAs("PressedSprite"),Header("押した際のボタン画像")] [SerializeField] private Sprite pressedSprite=null;
        [FormerlySerializedAs("ButtonEnabled"),Header("ボタンを押した後、押せないようにするか")] [SerializeField] private bool buttonEnabled;
        [FormerlySerializedAs("OnClick"),Header("押した際に呼び出される関数")] [SerializeField] private UnityEvent onClick=null;
        
        private Sprite _defaultSprite;

        #region 準備

        private void Awake()
        {
            _defaultSprite = this.gameObject.GetComponent<Image>().sprite;
            //onClickに実行したい関数を登録する
            onClick.AddListener(TestOnClick);
        }

        private void Start()
        {
            EventSystem.current.SetSelectedGameObject (this.gameObject);
            var a=this.gameObject.AddComponent<Selectable>().navigation;
            a.mode = Navigation.Mode.Explicit;
        }

        /*
        public void Conect()
        {
            Navigation buttonRight = LeftButton.navigation;
            buttonRight.mode = Navigation.Mode.Explicit;
            buttonRight.selectOnLeft = RightButton;
            buttonRight.selectOnRight = CenterButton;
            LeftButton.navigation = buttonRight;
        
            Navigation buttonLeft = RightButton.navigation;
            buttonLeft.mode = Navigation.Mode.Explicit;
            buttonLeft.selectOnLeft = CenterButton;
            buttonLeft.selectOnRight = LeftButton;
            RightButton.navigation = buttonLeft;
      
        }
        */
        
        /// <summary>
        /// オブジェクトアクティブ時に呼ばれる
        /// </summary>
        private void OnEnable()
        {
            this.gameObject.SetActive(true);
            Debug.Log("Enable");
        }

        /// <summary>
        /// オブジェクトが非有効時に呼ばれる
        /// </summary>
        private void OnDisable()
        {
            Debug.Log("Disable");
        }

        #endregion

        /// <summary>
        /// オブジェクトをクリックした時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            //押された際に、登録された関数を実行する
            onClick.Invoke();
            OnButtonClick();
        }

        /// <summary>
        /// オブジェクト内でポインタを押したとき時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            OnButtonDown();
        }

        /// <summary>
        /// オブジェクト内でポインタ放した時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            OnButtonUp();
        }

        /// <summary>
        /// オブジェクト内にポインタを入れた時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnButtonEnter();
        }

        /// <summary>
        /// オブジェクト内から、外にマウスを外した時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            OnButtonExit();
        }

        /// <summary>
        /// オブジェクト選択時に呼ばれるメソッド
        /// </summary>
        /// <param name="eventData"></param>
        public void OnSelect(BaseEventData eventData)
        {
            OnButtonSelect();
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
            this.gameObject.GetComponent<Image>().sprite = pressedSprite;
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
            this.gameObject.GetComponent<Image>().sprite = _defaultSprite;
            Debug.Log("Button Click");
            if (buttonEnabled) this.gameObject.GetComponent<ButtonEx>().enabled = false;
        }
        
        /// <summary>
        /// クリック時に呼び出される関数(登録)
        /// </summary>
        public void TestOnClick()
        {
            Debug.Log("Event OnClick!");
        }

        private void OnButtonSelect()
        {
            // Select時の共通処理
            Debug.Log("This gameObject Selected!");
        }

        #endregion
    }
}
