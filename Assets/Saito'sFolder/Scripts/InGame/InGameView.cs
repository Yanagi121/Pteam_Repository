using System;
using InputAsRx;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace InGame.Saito
{
    /// <summary>
    /// 
    /// </summary>
    public class InGameView : MonoBehaviour
    {
        //
        [SerializeField] private GameObject _optionObject;
        [SerializeField] private GameObject _soundObject;

        //Buttons
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _soundButton;
        [SerializeField] private Button _returnButton;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _optionObject.gameObject.SetActive(false);
            _soundObject.gameObject.SetActive(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnClickContinueButton()
        {
            return _continueButton.OnClickAsObservable();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnClickSoundButton()
        {
            return _soundButton.OnClickAsObservable();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnClickReturnButton()
        {
            return _returnButton.OnClickAsObservable();
        }

        /// <summary>
        /// 
        /// </summary>
        public void HideOption()
        {
            _optionObject.SetActive(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateViewSound(bool isView)
        {
            _soundObject.SetActive(isView);
        }
    }    
}

